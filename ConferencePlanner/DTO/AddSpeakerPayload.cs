using ConferencePlanner.Common;
using ConferencePlanner.Data;

namespace ConferencePlanner.DTO;
public class AddSpeakerPayload : SpeakerPayloadBase
{
    public AddSpeakerPayload(Speaker speaker) : base(speaker)
    { }

    public AddSpeakerPayload(IReadOnlyList<UserError> errors) : base(errors)
    { }
}

