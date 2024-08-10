using ConferencePlanner.Data;
using Microsoft.EntityFrameworkCore;

namespace ConferencePlanner.DataLoader;

public class SessionByIdDataLoader(
    IBatchScheduler batchScheduler,
    IDbContextFactory<ApplicationDbContext> dbContextFactory
) : BatchDataLoader<int, Session>(batchScheduler)
{
    private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));

    protected override async Task<IReadOnlyDictionary<int, Session>> LoadBatchAsync(
        IReadOnlyList<int> keys,
        CancellationToken cancellationToken
    )
    {
        await using ApplicationDbContext dbContext = _dbContextFactory.CreateDbContext();

        return await dbContext.Sessions
            .Where(s => keys.Contains(s.Id))
            .ToDictionaryAsync(t => t.Id, cancellationToken);
    }
}