
using NUnit.Framework;

namespace RomanNumerals
{
    public class RomanNumeralsConverterTests
    {

        [Test]
        [TestCase("1", "I")]
        [TestCase("5", "V")]
        [TestCase("10", "X")]
        [TestCase("50", "L")]

        [TestCase("2", "II")]
        [TestCase("6", "VI")]
        [TestCase("11", "XI")]
        [TestCase("51", "LI")]

        [TestCase("4", "IV")]
        [TestCase("40", "XL")]
        [TestCase("14", "XIV")]

        [TestCase("29", "XXIX")]
        [TestCase("9", "IX")]
        
        [TestCase("49", "XLIX")]
        [TestCase("90", "XC")]
        public void ConvertNumber_WithGivenArabicNumber_ReturnsValidRomanNumber(string arabic, string roman)
        {
            //Arrange
            RomanNumeralsConverter sut = new RomanNumeralsConverter();

            //Act
            string result = sut.Convert(arabic);

            //Assert
            Assert.AreEqual(roman, result);
        }
    }
}
