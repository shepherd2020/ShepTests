using System;
using System.Collections.Generic;

namespace Birthday
{
    public interface IBirthdayDataProvider
    {
        List<BirthdayData> GetData();
    }

    public interface IDateTimeNowProvider
    {
        DateTime Date { get; }
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
        private readonly IDateTimeNowProvider _dateTimeNowProvider;

        public BirthdayExtractor(IBirthdayDataProvider dataProvider, IDateTimeNowProvider dateTimeNow)
        {
            _dataProvider = dataProvider;
            _dateTimeNowProvider = dateTimeNow;
        }

        public List<ResultData> Identify()
        {
            List<BirthdayData> data = _dataProvider.GetData();

            List<ResultData> resultDatas = new List<ResultData>();
            foreach (BirthdayData item in data)
            {
                DateTime date = DateTime.Parse(item.DateOfBirth);
                if (_dateTimeNowProvider.Date.Day == date.Day && _dateTimeNowProvider.Date.Month == date.Month)
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
