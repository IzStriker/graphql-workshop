using ConferencePlanner.Data;
using Microsoft.EntityFrameworkCore;

namespace ConferencePlanner.DataLoader;

public class SpeakerByIdDataLoader(
    IBatchScheduler batchScheduler,
    IDbContextFactory<ApplicationDbContext> dbContextFactory
) : BatchDataLoader<int, Speaker?>(batchScheduler)
{
    private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));

    protected override async Task<IReadOnlyDictionary<int, Speaker?>> LoadBatchAsync(
        IReadOnlyList<int> keys,
        CancellationToken cancellationToken
    )
    {
        await using ApplicationDbContext dbContext = _dbContextFactory.CreateDbContext();

        return await dbContext.Speakers
            .Where(s => keys.Contains(s.Id))
            .ToDictionaryAsync(t => t.Id, cancellationToken);
    }
}