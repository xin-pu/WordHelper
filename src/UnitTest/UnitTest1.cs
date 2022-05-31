using WordHelper.Models;
using Xunit;
using Xunit.Abstractions;

namespace UnitTest
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public UnitTest1(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        private void print(object obj)
        {
            _testOutputHelper.WriteLine(obj.ToString());
        }

        [Fact]
        public void TestMethod1()
        {
            var bitmapItem = new BitmapItem(@"F:\Grab Predict\Train\JPEGImages\0.png");
            print(bitmapItem);
        }
    }
}