using System;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace Result
{
    class Program
    {
        public static async Task Main()
        {
            Console.WriteLine($"Started mining at {DateTime.UtcNow}");
            Console.WriteLine($"Primary Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            string result = await ShowTodaysInfo();
            Console.WriteLine(result);
            Console.WriteLine($"Finished mining at {DateTime.UtcNow}");

        }

        private static async Task<string> ShowTodaysInfo()
        {
            Console.WriteLine($" Worker Thread ID: {Thread.CurrentThread.ManagedThreadId}");

            string ret = $"Today is {DateTime.Today:D}\n" +
                         "Today's hours of leisure: " +
                         $"{await GetLeisureHours()}";
            return ret;
        }
        static async Task<int> GetLeisureHours()
        {
            // Task.FromResult is a placeholder for actual work that returns a string.  
            var today = await Task.FromResult<string>(DateTime.Now.DayOfWeek.ToString());

            // The method then can process the result in some way.  
            int leisureHours;
            if (today.First() == 'S')
                leisureHours = 16;
            else
                leisureHours = 5;

            return leisureHours;
        }
    }
}
