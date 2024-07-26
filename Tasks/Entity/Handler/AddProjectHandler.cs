using System.Collections.Generic;

namespace Tasks.Entity.Handler;

public class AddProjectHandler : CommandHandler
{
    public AddProjectHandler(CommandHandler handler) : base(handler)
    {
    }

    protected override bool IsMatch(string command)
    {
        var commandList = command.Split(" ".ToCharArray(), 3);
        if (commandList.Length < 3) return false;
        if (commandList[0] != "add") return false;
        return commandList[1] == "project";
    }

    protected override string DoHandle(string command, List<Project> projects)
    {
        var commandList = command.Split(" ".ToCharArray(), 3);
        projects.Add(new Project(commandList[2]));
        return "";
    }
}