using System;
namespace basics
{
    public class Date
    {
        private int day;
        private int month;
        private int year;



        

    public int Day
        {
            get { return day; }
            set { day = value; }
        }

        public int Month
        {
            get { return month; }
            set { month = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }


        public Date(string input)
        {
            int[] longMonths = { 1, 3, 5, 7, 8, 10, 12 };
            int[] shortMonths = { 4, 6, 9, 11 };
            int _day;
            int _month;
            int _year;

            string[] dateArray = input.Split("/");

            if (dateArray.Length >= 4)
            {
                throw new System.ArgumentException("Invalid date format - Date is too long");
            }



            if (!(Int32.TryParse(dateArray[0], out _day) &&
            Int32.TryParse(dateArray[1], out _month) &&
            Int32.TryParse(dateArray[2], out _year)))
            {
                throw new System.ArgumentException("Invalid date format - Could not be parsed to an integer");
            }

            //day check
            //FEB
            if (isLeapYear(_year) && _month == 2 && _day > 29) throw new System.ArgumentException("Invalid date format - too many days for the given month"); 
            if (!isLeapYear(_year) && _month == 2 && _day > 28)  throw new System.ArgumentException("Invalid date format - too many days for the given month"); 
            //other months
            if ((Array.BinarySearch(longMonths, _month) > -1) && _day > 31) throw new System.ArgumentException("Invalid date format - too many days for the given month"); 
            if ((Array.BinarySearch(shortMonths, _month) > -1) && _day > 30) throw new System.ArgumentException("Invalid date format - too many days for the given month");

            //month check
            if (_month < 0 || _month > 12) throw new System.ArgumentException("Invalid date format - too many months");

            //year check
                if (_year < 0 ) throw new System.ArgumentException("Invalid date format - year can't be negative");

            day = _day;
            month = _month;
            year = _year;


            
            
        }



        static Boolean isLeapYear(int year)
        {
            if ((year % 4 == 0))
            {
                if ((year % 100 == 0))
                {
                    if ((year % 400 == 0))
                    {
                        return true;
                    }
                    return false;
                }
                return true;
            }

            return false;
        }


        public void addDay()
        {
            int[] longMonths = {1, 3, 5, 7, 8, 10, 12 };
            int[] shortMonths = { 4, 6, 9, 11 };

            if (!isLeapYear(year) && month == 2 && day == 28)
            {
                if (day > 28)
                {
                    throw new System.InvalidOperationException("Too many days for a given month");
                }
                day = 1;
                month++;
                return;
            } else if (month == 2 && day == 29)
            {
                if (day > 29)
                {
                    throw new System.InvalidOperationException("Too many days for a given month");
                }
                day = 1;
                month++;
                return;
            }

            if ((Array.BinarySearch(longMonths, month) > -1) && day == 31)
            {
                //month is long
                if (day > 30)
                {
                    throw new System.InvalidOperationException("Too many days for a given month");
                }
                if (month == 12)
                {
                    day = 1;
                    month = 1;
                    year++;
                    return;
                }
                day = 1;
                month++;
                return;
            }
            else if ((Array.BinarySearch(shortMonths, month) > -1) && day == 30)
            {
                //month is short
                if (day > 30)
                {
                    throw new System.InvalidOperationException("Too many days for a given month");
                }

                day = 1;
                month++;
                return;
            }

            day++;

        }

    }
}
