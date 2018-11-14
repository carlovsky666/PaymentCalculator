//using System;

//namespace PaymentCalculator.Domain
//{
//    public class TimeDelete
//    {
//        public int Hour { get; }
//        public int Minute { get; }
//        TimeSpan time = new TimeSpan(0, 0, 0);
//        public TimeDelete(int hour, int minute)
//        {
//            if( hour < 0 || hour > 23 || minute < 0 || minute > 59)
//            {
//                throw new ArgumentOutOfRangeException();
//            }
//            Hour = hour;
//            Minute = minute;
//        }

//        public override string ToString()
//        {
//            return Hour.ToString() + ":" + Minute.ToString();
//        }

//        public static bool operator ==(TimeDelete time1, TimeDelete time2)
//        {
//            return (time1.Hour == time2.Hour && time1.Minute == time2.Minute);
//        }

//        public static bool operator !=(TimeDelete time1, TimeDelete time2)
//        {
//            return !(time1 == time2);
//        }

//        public static bool operator > (TimeDelete time1, TimeDelete time2)
//        {
//            return (time1.Hour > time2.Hour)|| (time1.Hour == time2.Hour && time1.Minute > time2.Minute);
//        }

//        public static bool operator <(TimeDelete time1, TimeDelete time2)
//        {
//            return (time1.Hour < time2.Hour) || (time1.Hour == time2.Hour && time1.Minute < time2.Minute);
//        }

//        public static bool operator >=(TimeDelete time1, TimeDelete time2)
//        {
//            return (time1 > time2) || (time1 == time2);
//        }

//        public static bool operator <=(TimeDelete time1, TimeDelete time2)
//        {
//            return (time1 < time2) || (time1 == time2);
//        }

        

//        //public static Time operator - (Time time1, Time time2)
//        //{
//        //    int hours = 0;
//        //    int minutes = 0;

//        //    if (time1 < time2)
//        //    {
//        //        throw new ArgumentException("Is not posible to rest a major time of a minor time");
//        //    }
//        //    if(time2.Minute > time1.Minute)
//        //    {
//        //        minutes = (int)(60 - time2.Minute);
//        //        hours = 
//        //    }
//        //}

//    }
//}
