using System;
using Tasks.Entity;
using Tasks.Entity.Handler;

namespace Tasks
{
    public sealed class App
    {
        private const string PROMPT = "> ";
        
        private const string QUIT = "quit";
        public static void Main(string[] args)
        {
            TaskList taskList = new TaskList(new ShowHandler(
                                            new AddProjectHandler(
                                                new AddTaskHandler(
                                                    new CheckHandler(
                                                        new UncheckHandler(
                                                            new HelpHandler(
                                                                new ErrorHandler(null))))))));
            while (true)
            {
                Console.Write(PROMPT);
                var command = Console.ReadLine();
                if (command == QUIT) break;
                var res = taskList.Execute(command);
                Console.Write(res);
            }
        }
    }
}