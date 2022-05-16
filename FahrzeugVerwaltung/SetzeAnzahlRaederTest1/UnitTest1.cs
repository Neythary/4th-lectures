using Fahrzeuge;
using Xunit;

namespace SetzeAnzahlRaederTest1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var auto = new Auto();

            const int expected = 4;

            auto.SetzeAnzahlRaeder(4);
            int result = auto.AnzahlRaeder;

            Assert.Equal(expected, result);
        }
    }
}