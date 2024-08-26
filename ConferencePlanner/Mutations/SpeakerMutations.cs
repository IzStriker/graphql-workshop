using ConferencePlanner.Data;
using ConferencePlanner.DTO;
using ConferencePlanner.Extensions;

namespace ConferencePlanner.Mutations;

[ExtendObjectType("Mutation")]
public class SpeakerMutations
{
    [UseApplicationDbContext]
    public async Task<AddSpeakerPayload> AddSpeakerAsync(
       AddSpeakerInput input,
       ApplicationDbContext context
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

        var value = new AddSpeakerPayload(speaker);
        return value;
    }
}