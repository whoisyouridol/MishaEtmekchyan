using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Day_09_Task_3
{
    class Clock
    {
        private int _Seconds;
        public int Seconds
        {
            get { return _Seconds; }
            set
            {
                if (value >= 0 && value <= 59)
                {
                    _Seconds = value;
                }
                else throw new InvalidDataException();
            }
        }

        private int _Minutes;
        public int Minutes
        {
            get { return _Minutes; }
            set
            {
                if (value >= 0 && value <= 59)
                {
                    _Minutes = value;
                }
                else throw new InvalidDataException();
            }
        }

        private int _Hours;
        public int Hours
        {
            get { return _Hours; }
            set
            {
                if (value >= 0 && value <= 23)
                {
                    _Hours = value;
                }
                else throw new InvalidDataException();
            }
        }
        //public void AddSeconds()
        //{
        //    if (_Seconds < 59)
        //    {
        //        _Seconds++;
        //    }
        //    else if(Minutes < 59)
        //    {
        //        _Seconds = 0;
        //        _Seconds++;
        //        _Minutes++;
        //    }
        //    else if(Hours < 23)
        //    {
        //        _Seconds = 0;
        //        _Minutes = 0;

        //        _Seconds++;
        //        _Minutes++;
        //        _Hours++;
        //    }
        //    else 
        //    {
        //        _Seconds = 0;
        //        _Minutes = 0;
        //        _Hours = 0;
        //    }
        //}
        //public void AddMinutes()
        //{
        //    if (_Minutes < 59)
        //    {
        //        _Minutes++;
        //    }
        //    else if (Hours < 23)
        //    {
        //        _Minutes = 0;
        //        _Minutes++;
        //        _Hours++;
        //    }
        //    else
        //    {
        //        _Seconds = 0;
        //        _Minutes = 0;
        //        _Minutes++;
        //        _Seconds++;
        //        _Hours = 0;
        //    }
        //}
        //public void AddHours()
        //{
        //    if (_Hours < 23)
        //    {
        //        _Hours++;
        //    }
        //    else
        //    {
        //        _Seconds = 0;
        //        _Minutes = 0;
        //        _Hours = 0;
        //    }
        //}

        public void AddHour()
        {
            time = time.AddHours(1);
        }
        public void AddMinute()
        {
            time = time.AddMinutes(1);
        }
        public void AddSecond()
        {
            time = time.AddSeconds(1);
        }
        private DateTime time;
        public void SetTime()
        {
            time = DateTime.Parse($"{_Hours}:{_Minutes}:{Seconds}");
        }
        public void GetCurrentTime()
        {
            Console.WriteLine(time.ToString("HH:mm:ss"));
        }
    }
}
