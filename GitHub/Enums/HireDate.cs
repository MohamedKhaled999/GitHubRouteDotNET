using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHub.Enums
{
    internal class HireDate
    {
        private int _day;
        private int _month;
        private int _year;



        public int Day
        {
            get { return _day; }
            set
            {
                if (value >= 1 && value <= 31)
                {
                    _day = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("invalid int");
                }
            }
        }
        public int Month { get { return _month; } set
            {
                if (value >= 1 )
                {
                    _month = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("invalid int");
                }
            }
        }
        public int Year { get { return _year; } set {
                if (value >= 1)
                {
                    _year = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("invalid int");
                }
            } 
        }

        public HireDate(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }
        public override string ToString()
        {
            return $"{Day} / {Month} / {Year}";
        }
    }
}
  