using System.Collections.Generic;

namespace Tasks.Entity.Handler;

public class ErrorHandler : CommandHandler
{
    public ErrorHandler(CommandHandler handler) : base(handler)
    {
    }

    protected override bool IsMatch(string command)
    {
        return true;
    }

    protected override string DoHandle(string command, List<Project> projects)
    {
        return $"I don't know what the command \"{command}\" is.\n";
    }
}