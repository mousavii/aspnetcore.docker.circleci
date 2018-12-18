using System;

namespace adc.utility
{
    public class DateUtil : IDateUtil
    {
        public DateTime GetUtc()
        {
            return DateTime.Now.ToUniversalTime();
        }
    }
}
