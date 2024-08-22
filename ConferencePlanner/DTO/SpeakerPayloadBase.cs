using ConferencePlanner.Common;
using ConferencePlanner.Data;

namespace ConferencePlanner.DTO;

public class SpeakerPayloadBase : Payload
{
    protected SpeakerPayloadBase(Speaker speaker)
    {
        Speaker = speaker;
    }

    protected SpeakerPayloadBase(IReadOnlyList<UserError> errors)
        : base(errors)
    {
    }

    public Speaker? Speaker { get; }
}