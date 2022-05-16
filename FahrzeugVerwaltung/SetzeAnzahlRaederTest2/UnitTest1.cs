using Xunit;
using Fahrzeuge;

namespace SetzeAnzahlRaederTest2
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var auto = new Auto();

            const int expected = -1;

            auto.SetzeAnzahlRaeder(-1);
            int result = auto.AnzahlRaeder;

            Assert.Equal(expected, result);

        }
    }
}