using Xunit;
using adc.utility;

namespace adc.tests
{
    public class UnitTest
    {
        [Fact]
        public void Test1()
        {
            var sut = new DateUtil();
            var utcTime = sut.GetUtc();
            Assert.NotNull(utcTime);
        }
    }
}
