using ConferencePlanner.Common;
using ConferencePlanner.Data;

namespace ConferencePlanner.DTO;

public class AddSessionPayload : SessionPayloadBase
{
    public AddSessionPayload(UserError error) : base([error])
    { }

    public AddSessionPayload(Session session) : base(session)
    { }

    public AddSessionPayload(IReadOnlyList<UserError> errors) : base(errors)
    { }
}