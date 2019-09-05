using System;
using System.Threading.Tasks;
namespace AsyncCoin
{
    class Program
    {
        static async Task Main(string[] args)
        {
            AsyncCoinManager coinManager = new AsyncCoinManager();
            await coinManager.AcquireAsyncCoin();
            Console.ReadLine();
        }
    }
}
