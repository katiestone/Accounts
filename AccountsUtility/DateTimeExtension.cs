using System;
using System.Collections.Generic;
using System.Text;

namespace AccountsUtility
{
    public static class DateTimeExtension
    {
        public static bool isSameMonth(this DateTime dateTime, DateTime date) {
            return dateTime.Year == date.Year && dateTime.Month == date.Month;
        }
    }
}
