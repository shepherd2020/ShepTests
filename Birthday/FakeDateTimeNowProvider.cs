using System;
using System.Collections.Generic;
using System.Text;

namespace Birthday
{
    public class FakeDateTimeNowProvider : IDateTimeNowProvider
    {
        public DateTime Date => new DateTime(1980, 05, 20); 
    }
}
