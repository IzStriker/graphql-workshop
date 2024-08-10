using ConferencePlanner.Data;
using HotChocolate;

namespace ConferencePlanner;

public class Query
{
    public IQueryable<Speaker> GetSpeakers([Service] ApplicationDbContext context) => context.Speakers;

}