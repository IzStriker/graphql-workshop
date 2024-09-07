using ConferencePlanner.Data;
using ConferencePlanner.DataLoader;
using ConferencePlanner.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ConferencePlanner.Queries;

[ExtendObjectType("Query")]
public class SpeakerQueries
{
    // [UseApplicationDbContext]
    [UsePaging]
    public IQueryable<Speaker> GetSpeakers(
        ApplicationDbContext context
    ) => context.Speakers.OrderBy(t => t.Name);

    public Task<Speaker> GetSpeakerByIdAsync(
        int id,
        SpeakerByIdDataLoader dataLoader,
        CancellationToken cancellationToken
    ) => dataLoader.LoadAsync(id, cancellationToken);

    public async Task<IEnumerable<Speaker>> GetManySpeakersByIdAsync(
        int[] ids,
        SpeakerByIdDataLoader dataLoader,
        CancellationToken cancellationToken
    ) => await dataLoader.LoadAsync(ids, cancellationToken);
}