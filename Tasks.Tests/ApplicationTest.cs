using System;
using System.IO;
using NUnit.Framework;
using Tasks.Entity;
using Tasks.Entity.Handler;

namespace Tasks
{
	[TestFixture]
	public sealed class ApplicationTest
	{
		public const string PROMPT = "> ";

		private const string QUIT = "quit";

		private FakeConsole _console;
		
		private System.Threading.Thread _applicationThread;

		[SetUp]
		public void StartTheApplication()
		{
			this._console = new FakeConsole();
			
			var taskList = new TaskList(new ShowHandler(
											new AddProjectHandler(
												new AddTaskHandler(
													new CheckHandler(
														new UncheckHandler(
															new HelpHandler(
																new ErrorHandler(null))))))));
			
			this._applicationThread = new System.Threading.Thread(() =>
			{
				while (true)
				{
					this._console.Write(PROMPT);
					var command = this._console.ReadLine();
					if (command == QUIT) break;
					var res = taskList.Execute(command);
					this._console.Write(res);
				}
			});
			_applicationThread.Start();
		}

		[TearDown]
		public void KillTheApplication()
		{
			if (_applicationThread == null || !_applicationThread.IsAlive)
			{
				return;
			}

			_applicationThread.Abort();
			throw new Exception("The application is still running.");
		}

		[Test, Timeout(1000)]
		public void ItWorks()
		{
			Execute("show");

			Execute("add project secrets");
			Execute("add task secrets Eat more donuts.");
			Execute("add task secrets Destroy all humans.");

			Execute("show");
			ReadLines(
				"secrets",
				"    [ ] 1: Eat more donuts.",
				"    [ ] 2: Destroy all humans.",
				""
			);

			Execute("add project training");
			Execute("add task training Four Elements of Simple Design");
			Execute("add task training SOLID");
			Execute("add task training Coupling and Cohesion");
			Execute("add task training Primitive Obsession");
			Execute("add task training Outside-In TDD");
			Execute("add task training Interaction-Driven Design");

			Execute("check 1");
			Execute("check 3");
			Execute("check 5");
			Execute("check 6");

			Execute("show");
			ReadLines(
				"secrets",
				"    [x] 1: Eat more donuts.",
				"    [ ] 2: Destroy all humans.",
				"",
				"training",
				"    [x] 3: Four Elements of Simple Design",
				"    [ ] 4: SOLID",
				"    [x] 5: Coupling and Cohesion",
				"    [x] 6: Primitive Obsession",
				"    [ ] 7: Outside-In TDD",
				"    [ ] 8: Interaction-Driven Design",
				""
			);

			Execute("quit");
		}

		private void Execute(string command)
		{
			Read(PROMPT);
			Write(command);
		}

		private void Read(string expectedOutput)
		{
			var length = expectedOutput.Length;
			var actualOutput = _console.RetrieveOutput(expectedOutput.Length);
			Assert.AreEqual(expectedOutput, actualOutput);
		}

		private void ReadLines(params string[] expectedOutput)
		{
			foreach (var line in expectedOutput)
			{
				Read(line + Environment.NewLine);
			}
		}

		private void Write(string input)
		{
			_console.SendInput(input + Environment.NewLine);
		}
	}
}
