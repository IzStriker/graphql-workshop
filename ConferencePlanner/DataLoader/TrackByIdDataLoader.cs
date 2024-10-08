using ConferencePlanner.Data;
using Microsoft.EntityFrameworkCore;

namespace ConferencePlanner.DataLoader;

public class TrackByIdDataLoader(
    IBatchScheduler batchScheduler,
    IDbContextFactory<ApplicationDbContext> dbContextFactory) : BatchDataLoader<int, Track?>(batchScheduler)
{
    private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory = dbContextFactory ??
            throw new ArgumentNullException(nameof(dbContextFactory));

    protected override async Task<IReadOnlyDictionary<int, Track?>> LoadBatchAsync(
        IReadOnlyList<int> keys,
        CancellationToken cancellationToken)
    {
        await using ApplicationDbContext dbContext =
            _dbContextFactory.CreateDbContext();

        return await dbContext.Tracks
            .Where(s => keys.Contains(s.Id))
            .ToDictionaryAsync(t => t.Id, cancellationToken);
    }
}