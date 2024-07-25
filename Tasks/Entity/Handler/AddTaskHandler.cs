using System;
using System.Collections.Generic;

namespace Tasks.Entity.Handler;

public class AddTaskHandler : CommandHandler
{
    public AddTaskHandler(CommandHandler handler) : base(handler)
    {
    }

    protected override bool IsMatch(string command)
    {
        var commandList = command.Split(" ".ToCharArray(), 4);
        if (commandList.Length < 4) return false;
        if (commandList[0] != "add") return false;
        return commandList[1] == "task";
    }

    protected override string DoHandle(string command, List<Project> projects)
    {
        var commandList = command.Split(" ".ToCharArray(), 4);
        
        Project targetProject = null;
        string projectName = commandList[2];
        foreach (var project in projects)
        {
            if (!project.Name.Equals(projectName)) continue;
            targetProject = project;
            break;
        }

        if (targetProject == null) return $"Could not find a project with the name \"{projectName}\".\n";
        
        targetProject?.AddTask(new Task(commandList[3], false));
        
        return "";
    }
}