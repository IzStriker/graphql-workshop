using ConferencePlanner.Data;
using ConferencePlanner.DataLoader;
using ConferencePlanner.Types;

namespace ConferencePlanner.Queries;

[ExtendObjectType("Query")]
public class SessionQueries
{
    // [UseApplicationDbContext]
    [UsePaging(typeof(NonNullType<SessionType>))]
    [UseFiltering(typeof(SessionFilterInputType))]
    [UseSorting]
    public IQueryable<Session> GetSessions(
      ApplicationDbContext context
    ) =>
      context.Sessions;

    public Task<Session> GetSessionByIdAsync(
        int id,
        SessionByIdDataLoader sessionById,
        CancellationToken cancellationToken
    ) => sessionById.LoadAsync(id, cancellationToken);

    public async Task<IEnumerable<Session>> GetSessionsByIdAsync(
        int[] ids,
        SessionByIdDataLoader sessionById,
        CancellationToken cancellationToken
    ) => await sessionById.LoadAsync(ids, cancellationToken);
}