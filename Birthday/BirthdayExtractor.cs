using System;
using System.Collections.Generic;

namespace Birthday
{
    public interface IBirthdayDataProvider
    {
        List<BirthdayData> GetData();
    }

    public class BirthdayData
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string DateOfBirth { get; set; }
        public string Email { get; set; }
    }

    public class ResultData
    {
        public string FirstName { get; set; }
        public string Email { get; set; }
    }

    public class BirthdayExtractor
    {
        private readonly IBirthdayDataProvider _dataProvider;

        public BirthdayExtractor(IBirthdayDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public List<ResultData> Identify()
        {
            List<BirthdayData> data = _dataProvider.GetData();

            List<ResultData> resultDatas = new List<ResultData>();
            foreach (BirthdayData item in data)
            {
                DateTime date = DateTime.Parse(item.DateOfBirth);
                if (DateTime.Today.Day == date.Day && DateTime.Today.Month == date.Month)
                {
                    resultDatas.Add(new ResultData
                    {
                        FirstName = item.FirstName,
                        Email = item.Email
                    });
                }
            }

            return resultDatas;
        }
    }
}
