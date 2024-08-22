namespace ConferencePlanner.Common;

public abstract class Payload(IReadOnlyList<UserError>? errors = null)
{
    public IReadOnlyList<UserError> Errors { get; set; } = errors;
}