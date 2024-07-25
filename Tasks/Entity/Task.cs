using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace Tasks.Entity
{
	public class Task
	{
		public long Id { get; }

		public string Description { get; }

		public bool IsDone { get; private set; }

		private static long _lastId = 1;

		public Task(string description, bool done)
		{
			Id = _lastId++;
			Description = description;
			IsDone = done;
		}

		public void Check()
		{
			IsDone = true;
		}

		public void Uncheck()
		{
			IsDone = false;
		}
	}
}
