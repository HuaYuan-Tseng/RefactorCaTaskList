using System.Collections.Generic;

namespace Tasks.Entity.Handler;

public class UncheckHandler : CommandHandler
{
    public UncheckHandler(CommandHandler handler) : base(handler)
    {
    }

    protected override bool IsMatch(string command)
    {
        var commandList = command.Split(" ".ToCharArray(), 2);
        if (commandList.Length < 2) return false;
        return commandList[0] == "uncheck";
    }

    protected override string DoHandle(string command, List<Project> projects)
    {
        var commandList = command.Split(" ".ToCharArray(), 2);
        
        long id = long.Parse(commandList[1]);
        Project targetProject = null;
        foreach (var project in projects)
        {
            if (!project.IsExistTask(id)) continue;
            targetProject = project;
            break;
        }

        if (targetProject == null) return $"Could not find a task with an ID of {id}.\n";
        
        targetProject.CheckTask(id, false);
        
        return "";
    }
}