using ConferencePlanner.Data;
using ConferencePlanner.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ConferencePlanner.GraphQL;

public class Query
{
    [UseApplicationDbContext]
    public Task<List<Speaker>> GetSpeakers(ApplicationDbContext context) => context.Speakers.ToListAsync();
}