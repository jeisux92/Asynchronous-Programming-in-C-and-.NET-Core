using System;

namespace Thread_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadDemoManager manager = new ThreadDemoManager();
            manager.Execute();
            Console.ReadKey();
        }
    }
}
