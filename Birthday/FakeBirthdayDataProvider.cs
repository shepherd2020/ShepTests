using System;
using System.Collections.Generic;
using System.Text;

namespace Birthday
{
    public class FakeBirthdayDataProvider : IBirthdayDataProvider
    {
        public List<BirthdayData> GetData()
        {
            return new List<BirthdayData>
            {
                new BirthdayData
                {
                    DateOfBirth = "20/05/2021",
                    Email = "test.email1",
                    FirstName = "Test",
                    LastName = "Test"
                }
            };
        }
    }
}
