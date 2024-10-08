using ConferencePlanner.Common;
using ConferencePlanner.Data;

namespace ConferencePlanner.DTO;
public class AddTrackPayload : TrackPayloadBase
{
    public AddTrackPayload(Track track) : base(track)
    { }

    public AddTrackPayload(IReadOnlyList<UserError> errors) : base(errors)
    { }
}