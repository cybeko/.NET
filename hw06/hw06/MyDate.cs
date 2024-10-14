using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw06
{
    internal class MyDate
    {
        private int _year;
        private int _month;
        private int _day;

        public int Year { get { return _year; } set { _year = value; } }
        public int Month { get { return _month; } set { _month = value; } }
        public int Day { get { return _day; } set { _day = value; } }
        public string Day_Of_Week
        {
            get
            {
                DateTime date = new DateTime(_year, _month, _day);
                return date.DayOfWeek.ToString();
            }
        }

        public MyDate() { }
        public MyDate(int year, int month, int day)
        {
            _year = year;
            _month = month;
            _day = day;
        }

        public int CompareDates(MyDate date1, MyDate date2)
        {
            int days1 = TotalDays(date1);
            int days2 = TotalDays(date2);

            return Math.Abs(days1 - days2);

        }

        private int TotalDays(MyDate date)
        {
            int totalDays = 0;

            for (int year = 0; year < date.Year; year++)
            {
                totalDays += IsLeapYear(year) ? 366 : 365;
            }

            for (int month = 1; month < date.Month; month++)
            {
                totalDays += DaysInMonth(month, date.Year);
            }

            totalDays += date.Day;

            return totalDays;
        }
        private bool IsLeapYear(int year)
        {
            return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
        }
        private int DaysInMonth(int month, int year)
        {
            switch (month)
            {
                case 1: return 31;
                case 2: return IsLeapYear(year) ? 29 : 28;
                case 3: return 31;
                case 4: return 30;
                case 5: return 31;
                case 6: return 30;
                case 7: return 31;
                case 8: return 31;
                case 9: return 30;
                case 10: return 31;
                case 11: return 30;
                case 12: return 31;
                default: throw new Exception("Invalid month");
            }
        }
        private MyDate DaysToDate(int totalDays)
        {
            int year = 0;

            while (totalDays >= (IsLeapYear(year) ? 366 : 365))
            {
                totalDays -= IsLeapYear(year) ? 366 : 365;
                year++;
            }

            int month = 1;

            while (totalDays >= DaysInMonth(month, year))
            {
                totalDays -= DaysInMonth(month, year);
                month++;
            }

            int day = totalDays;

            return new MyDate(year, month, day);
        }


        public MyDate ChangeDate(MyDate date1, int days)
        {
            int countdays = TotalDays(date1);
            countdays += days;
            return DaysToDate(countdays);
        }
        public string ShowDate(MyDate date1)
        {
            string str = $"{date1.Day}-{date1.Month}-{date1.Year}";
            return str;
        }
    }
}
