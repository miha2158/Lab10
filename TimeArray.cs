using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab10
{
    class TimeList
    {
        public List<TimeUnit> Data = new List<TimeUnit>(0);
        public int Count => Data.Count;
        public int Capacity
        {
            get { return Data.Capacity; }
            set {  Data.Capacity = value; }
        }

        public TimeUnit this[int i]
        {
            get { return Data[i]; }
            set { Data[i] = value; }
        }
        
        public TimeList ( )
        {
            Data = new List<TimeUnit>(0);
        }
        public TimeList(int capacity)
        {
            for (int i = 0; i < capacity; i++)
                Data.Add(new TimeUnit( ));
        }
        public TimeList (int capacity, bool rand)
        {
            if (rand)
                for (int i = 0; i < capacity; i++)
                    Data.Add(new TimeUnit(true));
        }
        public TimeList (IEnumerable<int> hours, IEnumerable<int> minutes)
        {

            if(hours.Count() != minutes.Count())
                return;
            int length = hours.Count( );

            for (int i = 0; i < length; i++)
                Data.Add(new TimeUnit(hours.ElementAt(i), minutes.ElementAt(i)));

        }



        public TimeUnit Min ( )
        {
            var result = Data[0];
            foreach (TimeUnit t in Data)
                if (t < result)
                    result = t;
            return result;
        }
        public static TimeUnit Min(TimeList tl)
        {
            return tl.Min( );
        }

        public override string ToString ()
        {
            string result = string.Empty;
            foreach (TimeUnit t in Data)
                result = result + t + "  ";
            return result;
        }
    }
}