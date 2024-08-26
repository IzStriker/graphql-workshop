using Microsoft.EntityFrameworkCore;
using ConferencePlanner.Data;
using ConferencePlanner.DataLoader;
using ConferencePlanner.Extensions;

namespace ConferencePlanner.Queries;

[ExtendObjectType("Query")]
public class SessionQueries
{
    [UseApplicationDbContext]
    public async Task<IEnumerable<Session>> GetSessionsAsync(
        ApplicationDbContext context,
        CancellationToken cancellationToken
    ) => await context.Sessions.ToListAsync(cancellationToken);

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