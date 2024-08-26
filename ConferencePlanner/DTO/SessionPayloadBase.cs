using ConferencePlanner.Common;
using ConferencePlanner.Data;

namespace ConferencePlanner.DTO;

public class SessionPayloadBase : Payload
{
    public Session? Session { get; set; }
    protected SessionPayloadBase(Session session)
    {
        Session = session;
    }

    protected SessionPayloadBase(IReadOnlyList<UserError> errors) : base(errors)
    { }
}