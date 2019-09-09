using System;
using Xunit;
using AsyncReturnTypeLibrary;
using System.Threading.Tasks;

namespace AsyncReturnTypes.xUnit
{
    public class AsyncExceptionManagerTest
    {
        private AsyncExceptionManager _exceptionMgr;

        public AsyncExceptionManagerTest()
        {
            _exceptionMgr = new AsyncExceptionManager();
        }

        [Fact]
        public void ExceptionManagerCanMineCoins()
        {
            var result = _exceptionMgr.MineCoinFromForbiddenServer();
            Assert.True(result.Contains("Success"), "Failed to mine.");
        }

        [Fact]
        public async Task ExceptionManagerCanMineCoinsAsync()
        {
            var result = await _exceptionMgr.MineCoinFromForbiddenServerAsync();
            Assert.True(result.Contains("Success"), "Failed to mine.");
            return;
        }

    }
}