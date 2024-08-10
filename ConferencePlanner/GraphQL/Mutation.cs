using ConferencePlanner.Data;
using ConferencePlanner.DTO;

namespace ConferencePlanner.GraphQL;

public class Mutation
{
    public async Task<AddSpeakerPayload> AddSpeakerAsync(
        AddSpeakerInput input,
        [Service] ApplicationDbContext context
    )
    {
        var speaker = new Speaker
        {
            Name = input.Name,
            Bio = input.Bio,
            WebSite = input.Bio
        };

        context.Speakers.Add(speaker);
        await context.SaveChangesAsync();

        return new AddSpeakerPayload(speaker);
    }
}