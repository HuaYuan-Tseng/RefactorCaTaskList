using System;

namespace Tasks
{
    public sealed class App
    {
        public static void Main(string[] args)
        {
            new TaskList(new RealConsole()).Run();
        }
    }
}