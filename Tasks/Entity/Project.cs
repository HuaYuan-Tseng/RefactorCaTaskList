namespace Tasks.Entity;
using System.Collections.Generic;

public class Project
{
    public string Name { get; }
    
    public List<Task> Tasks { get; }
    
    public Project(string name)
    {
        Name = name;
        Tasks = [];
    }

    public void AddTask(Task task)
    {
        Tasks.Add(task);
    }

    public bool IsExistTask(long id)
    {
        foreach (var task in Tasks)
        {
            if (task.Id == id) return true;
        }
        return false;
    }

    public void CheckTask(long id, bool isCheck)
    {
        Task targetTask = null;
        foreach (var task in Tasks)
        {
            if (task.Id != id) continue;
            targetTask = task;
            break;
        }

        if (isCheck)
        {
            targetTask?.Check();
        }
        else
        {
            targetTask?.Uncheck();
        }
    }
}