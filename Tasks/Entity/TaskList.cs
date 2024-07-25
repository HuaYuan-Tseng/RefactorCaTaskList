using System.Collections.Generic;
using Tasks.Entity.Handler;

namespace Tasks.Entity
{
	public sealed class TaskList
	{
		private readonly List<Project> _projects = [];

		private readonly CommandHandler _handler;
		
		public TaskList(CommandHandler handler)
		{
			_handler = handler;
		}

		public string Execute(string command)
		{
			return _handler.Handle(command, _projects);
		}
	}
}
