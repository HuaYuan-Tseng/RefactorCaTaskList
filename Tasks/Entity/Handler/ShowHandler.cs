using System;
using System.Collections.Generic;
using System.Linq;

namespace Tasks.Entity.Handler;

public class ShowHandler : CommandHandler
{
    
    public ShowHandler(CommandHandler handler) : base(handler)
    {
    }

    protected override bool IsMatch(string command)
    {
        return command == "show";
    }

    protected override string DoHandle(string command, List<Project> projects)
    {
        var res = "";
        foreach (var project in projects)
        {
            res += project.Name + "\n";
            foreach (var task in project.Tasks)
            {
                res += $"    [{(task.IsDone ? 'x' : ' ')}] {task.Id.ToString()}: {task.Description}\n";
            }
            res += "\n";
        }
        return res;
    }
}