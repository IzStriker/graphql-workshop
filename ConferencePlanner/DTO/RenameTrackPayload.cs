using ConferencePlanner.Common;
using ConferencePlanner.Data;

namespace ConferencePlanner.DTO;
public class RenameTrackPayload : TrackPayloadBase
{
    public RenameTrackPayload(Track track) : base(track)
    { }

    public RenameTrackPayload(IReadOnlyList<UserError> errors) : base(errors)
    { }
}