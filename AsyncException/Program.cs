using System;
using System.Threading.Tasks;
namespace AsyncException
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //await DoSomethingAsync();
            await DoMultipleAsync();
        }


        public static async Task DoSomethingAsync()
        {
            Task<string> theTask = DelayAsync();

            try
            {
                string result = await theTask;
                Console.WriteLine("Result: " + result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Message: " + ex.Message);
            }
            Console.WriteLine("Task IsCanceled: " + theTask.IsCanceled);
            Console.WriteLine("Task IsFaulted:  " + theTask.IsFaulted);
            if (theTask.Exception != null)
            {
                Console.WriteLine("Task Exception Message: "
                    + theTask.Exception.Message);
                Console.WriteLine("Task Inner Exception Message: "
                    + theTask.Exception.InnerException.Message);
            }
        }

        private static async Task<string> DelayAsync()
        {
            await Task.Delay(100);
            throw new OperationCanceledException("canceled");
            //throw new Exception("Something happened.");
            return "Done";
        }

        public static async Task DoMultipleAsync()
        {
            Task theTask1 = ExcAsync(info: "First Task");
            Task theTask2 = ExcAsync(info: "Second Task");
            Task theTask3 = ExcAsync(info: "Third Task");

            Task allTasks = Task.WhenAll(theTask1, theTask2, theTask3);

            try
            {
                await allTasks;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                Console.WriteLine("Task IsFaulted: " + allTasks.IsFaulted);
                foreach (var inEx in allTasks.Exception.InnerExceptions)
                {
                    Console.WriteLine("Task Inner Exception: " + inEx.Message);
                }
            }
        }

        private static async Task ExcAsync(string info)
        {
            await Task.Delay(100);

            throw new Exception("Error-" + info);
        }
    }
}
