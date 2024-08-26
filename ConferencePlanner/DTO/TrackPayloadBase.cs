using ConferencePlanner.Common;
using ConferencePlanner.Data;

namespace ConferencePlanner.DTO;
public class TrackPayloadBase : Payload
{
    public Track? Track { get; }
    public TrackPayloadBase(Track track)
    {
        Track = track;
    }

    public TrackPayloadBase(IReadOnlyList<UserError> errors) : base(errors)
    { }
}