using ConferencePlanner.Common;
using ConferencePlanner.Data;
using ConferencePlanner.DTO;
using ConferencePlanner.Extensions;

namespace ConferencePlanner.Mutations;

[ExtendObjectType("Mutation")]
public class SessionMutations
{
    [UseApplicationDbContext]
    public async Task<AddSessionPayload> AddSessionAsync(
        AddSessionInput input,
        ApplicationDbContext context,
        CancellationToken cancellationToken
    )
    {
        if (string.IsNullOrEmpty(input.Title))
        {
            return new AddSessionPayload(
                new UserError("The title cannot be empty.", "TITLE_EMPTY")
            );
        }

        if (input.SpeakerIds.Count == 0)
        {
            return new AddSessionPayload(
                new UserError("No speaker assigned.", "NO_SPEAKER")
            );
        }

        var session = new Session
        {
            Title = input.Title,
            Abstract = input.Abstract,
        };

        foreach (int speakerId in input.SpeakerIds)
        {
            session.SessionSpeakers.Add(new SessionSpeaker
            {
                SpeakerId = speakerId
            });
        }

        context.Sessions.Add(session);
        await context.SaveChangesAsync(cancellationToken);

        return new AddSessionPayload(session);
    }

    [UseApplicationDbContext]
    public async Task<ScheduleSessionPayload> ScheduleSessionAsync(
        ScheduleSessionInput input,
                ApplicationDbContext context
    )
    {
        if (input.EndTime < input.StartTime)
        {
            return new ScheduleSessionPayload(
                new UserError("endTime has to be larger than startTime.", "END_TIME_INVALID")
            );
        }

        Session session = await context.Sessions.FindAsync(input.SessionId);

        if (session is null)
        {
            return new ScheduleSessionPayload(
                new UserError("Session not found.", "SESSION_NOT_FOUND")
            );
        }

        session.TrackId = input.TrackId;
        session.StartTime = input.StartTime;
        session.EndTime = input.EndTime;

        await context.SaveChangesAsync();

        return new ScheduleSessionPayload(session);
    }
}