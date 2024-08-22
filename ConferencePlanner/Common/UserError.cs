namespace ConferencePlanner.Common;

public class UserError(string message, string code)
{
    public string Message { get; } = message;
    public string Code { get; } = code;
}