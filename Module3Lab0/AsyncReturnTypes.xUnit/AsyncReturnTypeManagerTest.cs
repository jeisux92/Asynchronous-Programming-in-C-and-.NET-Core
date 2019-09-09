using System;
using System.Threading.Tasks;
using AsyncReturnTypeLibrary;
using Xunit;

namespace AsyncReturnTypes.xUnit
{
    public class AsyncReturnTypeManagerTest
    {
        private AsyncReturnTypeManager _returnTypeMgr;

        public AsyncReturnTypeManagerTest()
        {
            _returnTypeMgr = new AsyncReturnTypeManager();
        }

        [Fact]
        public async void AsyncManagerCanPause5SecondsWithTask()
        {
            var startTime = DateTime.UtcNow;
            await _returnTypeMgr.PauseFiveSecondsAsync();
            var diffInSeconds = (DateTime.UtcNow - startTime).TotalSeconds;
            Assert.True(diffInSeconds >= 5, "Did not pause for at least five seconds");
        }

        [Fact]
        public async Task AsyncManagerCanCallWebService()
        {
            var startTime = DateTime.UtcNow;
            await _returnTypeMgr.CallWebServiceThatDoesNotReturnResults();
            var diffInSeconds = (DateTime.UtcNow - startTime).TotalSeconds;
            Assert.True(diffInSeconds >= 2, "Did not mine for at least two seconds");
        }

        [Fact]
        public async Task AsyncManagerCanCallWebServiceWithResult()
        {
            string resultString = await _returnTypeMgr.CallWebServiceThatReturnsString();
            Assert.True(resultString.Contains("AsyncCoin"), "Did not return correct results");
        }

        [Fact]
        public async Task AsyncManagerCanCaptureChangedCoinPrice()
        {
            var initialPrice = await _returnTypeMgr.GetCurrentCoinPrice();
            var cachedPrice = await _returnTypeMgr.GetCurrentCoinPrice();
            await Task.Delay(3500);
            var changedPrice = await _returnTypeMgr.GetCurrentCoinPrice();
            Assert.Equal(initialPrice, cachedPrice);
            Assert.NotEqual(cachedPrice, changedPrice);
        }

        [Fact]
        public void AsyncManagerCanReturnParallelResult()
        {
            int numberOfSeconds = _returnTypeMgr.MineAndGetAggregateSeconds(2);
            Assert.True(numberOfSeconds > 2, "The Parallel For loop did not mine for more than 2 seconds");
        }
    }
}
