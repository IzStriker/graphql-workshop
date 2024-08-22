using ConferencePlanner.Data;
using ConferencePlanner.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace ConferencePlanner.Types;

public class SpeakerType : ObjectType<Speaker>
{
    protected override void Configure(IObjectTypeDescriptor<Speaker> descriptor)
    {
        descriptor
            .ImplementsNode()
            .IdField(t => t.Id)
            .ResolveNode((ctx, id) => ctx.DataLoader<SpeakerByIdDataLoader>().LoadAsync(id, ctx.RequestAborted));


        descriptor
            .Field(t => t.SessionSpeakers)
            .ResolveWith<SpeakerResolvers>(t => t.GetSessionsAsync(default!, default!, default!, default))
            // .UseDbContext<ApplicationDbContext>()
            .Name("sessions");
    }

    public class SpeakerResolvers
    {
        public async Task<IEnumerable<Session?>> GetSessionsAsync(
            [Parent] Speaker speaker,
            ApplicationDbContext dbContext,
            SessionByIdDataLoader sessionById,
            CancellationToken cancellationToken
        )
        {
            int[] sessionIds = await dbContext.Speakers
                .Where(s => s.Id == speaker.Id)
                .Include(s => s.SessionSpeakers)
                .SelectMany(s => s.SessionSpeakers.Select(t => t.SessionId))
                .ToArrayAsync(cancellationToken: cancellationToken);

            return await sessionById.LoadAsync(sessionIds, cancellationToken);
        }
    }
}