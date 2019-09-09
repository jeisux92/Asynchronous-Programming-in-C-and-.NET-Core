using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncReturnTypeLibrary
{
    public class AsyncExceptionManager
    {
        public string MineCoinFromForbiddenServer()
        {
            var result = "Starting mining operation. ";
            var numberOfCoins = DontMineHere();
            if (numberOfCoins > 0)
            {
                result += $"Success! Acquired {numberOfCoins} coins";
            }
            return result;
        }

        private int DontMineHere()
        {
            throw new Exception("No, this is forbidden");
        }

        public async Task<string> MineCoinFromForbiddenServerAsync()
        {
            var result = "Starting mining operation. ";
            Task<int> forbiddenTask = DontMineHereAsync();
            try
            {
                var numberOfCoins = await forbiddenTask;
                if (numberOfCoins > 0)
                {
                    result += $"Success! Acquired {numberOfCoins} coins";
                }
            }
            catch (System.Exception)
            {
                throw;
            }

            return result;
        }

        private async Task<int> DontMineHereAsync()
        {
            throw new Exception("No, this is forbidden");

        }
    }
}