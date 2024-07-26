using System.Collections.Generic;

namespace Tasks.Entity.Handler;

public class HelpHandler : CommandHandler
{
    public HelpHandler(CommandHandler handler) : base(handler)
    {
    }

    protected override bool IsMatch(string command)
    {
        return (command == "help") ? true : false;
    }

    protected override string DoHandle(string command, List<Project> projects)
    {
        var res = "Commands:\n";
        res += "\tshow\n";
        res += "\tadd project <project name>\n";
        res += "\tadd task <project name> <task description>\n";
        res += "\tcheck <task ID>\n";
        res += "\tuncheck <task ID>\n";
        return res;
    }
}