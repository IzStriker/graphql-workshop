using ConferencePlanner.Data;
using ConferencePlanner.DTO;
using ConferencePlanner.Extensions;

namespace ConferencePlanner.GraphQL;

public class Mutation
{
    [UseApplicationDbContext]
    public async Task<AddSpeakerPayload> AddSpeakerAsync(
        AddSpeakerInput input,
        [Service] ApplicationDbContext context
    )
    {
        var speaker = new Speaker
        {
            Name = input.Name,
            Bio = input.Bio,
            WebSite = input.WebSite
        };

        context.Speakers.Add(speaker);
        await context.SaveChangesAsync();

        return new AddSpeakerPayload(speaker);
    }
}