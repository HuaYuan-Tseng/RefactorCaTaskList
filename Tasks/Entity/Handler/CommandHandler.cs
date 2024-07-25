using System.Collections.Generic;
using System.Reflection.Metadata;

namespace Tasks.Entity.Handler;

public abstract class CommandHandler
{
    private readonly CommandHandler _nextHandler;

    protected CommandHandler(CommandHandler handler)
    {
        _nextHandler = handler;
    }

    public string Handle(string command, List<Project> projects)
    {
        var res = "";
        
        res = IsMatch(command) ? DoHandle(command, projects) : _nextHandler.Handle(command, projects);
        
        return res;
    }

    protected abstract bool IsMatch(string command);

    protected abstract string DoHandle(string command, List<Project> projects);
}