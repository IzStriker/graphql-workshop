using ConferencePlanner.Data;
using ConferencePlanner.DataLoader;
using ConferencePlanner.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ConferencePlanner.GraphQL;

public class Query
{
    [UseApplicationDbContext]
    public Task<List<Speaker>> GetSpeakers(ApplicationDbContext context) => context.Speakers.ToListAsync();

    public Task<Speaker> GetSpeakerAsync(
        int id,
        SpeakerByIdDataLoader dataLoader,
        CancellationToken cancellationToken
    ) => dataLoader.LoadAsync(id, cancellationToken);

}