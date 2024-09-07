using Microsoft.EntityFrameworkCore;
using ConferencePlanner.Data;
using ConferencePlanner.DataLoader;
using ConferencePlanner.Extensions;

namespace ConferencePlanner.Queries;

[ExtendObjectType("Query")]
public class TrackQueries
{
    // [UseApplicationDbContext]
    [UsePaging]
    public IQueryable<Track> GetTracks(
        ApplicationDbContext context
     ) => context.Tracks.OrderBy(t => t.Name);

    [UseApplicationDbContext]
    public Task<Track> GetTrackByNameAsync(
        string name,
        ApplicationDbContext context,
        CancellationToken cancellationToken
    ) => context.Tracks.FirstAsync(t => t.Name == name, cancellationToken: cancellationToken);

    [UseApplicationDbContext]
    public async Task<IEnumerable<Track>> GetTrackByNamesAsync(
        string[] names,
        ApplicationDbContext context,
        CancellationToken cancellationToken
    ) => await context.Tracks.Where(t => names.Contains(t.Name)).ToListAsync(cancellationToken: cancellationToken);

    public Task<Track> GetTrackByIdAsync(
        int id,
        TrackByIdDataLoader trackById,
        CancellationToken cancellationToken
    ) => trackById.LoadAsync(id, cancellationToken);

    public async Task<IEnumerable<Track>> GetTracksByIdAsync(
        int[] ids,
        TrackByIdDataLoader trackById,
        CancellationToken cancellationToken
    ) => await trackById.LoadAsync(ids, cancellationToken);
}