using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;


namespace Birthday
{
    public class BirthdayExtractorTests
    {
        [Test]
        public void Identify_WithTodayDate_ReturnPeopleWithBirthday()
        {
            IBirthdayDataProvider birthdayDataProvider = new FakeBirthdayDataProvider();
            BirthdayExtractor birthdayExtractor = new BirthdayExtractor(birthdayDataProvider);

            List<ResultData> result = birthdayExtractor.Identify();

            Assert.IsTrue(result.Any());
        }
    }
}
