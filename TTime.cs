using System;

namespace Lab10
{
    class TimeUnit
    {
        protected int hours = 0;
        protected int minutes = 0;

        public static int created = 0;
        public static int destroyed = 0;

        public int Hours
        {
            get { return hours; }
            set
            {
                if (value < 0)
                    value = Math.Abs(value + 24);
                hours = value % 24;
            }
        }
        public int Minutes
        {
            get { return minutes; }
            set
            {
                if (value < 0)
                    value = Math.Abs(value + 60);
                minutes = value % 60;
            }
        }

        public static readonly TimeUnit zero = new TimeUnit();

        public static TimeUnit operator - (TimeUnit left, int right)
        {
            var Ntime = new TimeUnit(left.hours,left.Minutes);
            int r = right;
            for (; r > 60; r -= 60)
                Ntime.Hours--;

            if(r > Ntime.Minutes)
            {
                Ntime.Hours--;
                Ntime.Minutes = 60 - r + Ntime.Minutes;
            }
            else
                Ntime.Minutes -= r;
            
            return Ntime;
        }
        public static TimeUnit operator - (TimeUnit left)
        {
            return zero;
        }
        public static TimeUnit operator --(TimeUnit left)
        {
            left -= 1;
            return left;
        }

        public static bool operator == (TimeUnit left, TimeUnit right)
        {
            return left.hours == right.hours && left.minutes == right.minutes;
        }
        public static bool operator != (TimeUnit left, TimeUnit right)
        {
            return !(left == right);
        }

        public static bool operator > (TimeUnit left, TimeUnit right)
        {
            if (left.hours > right.hours)
                return true;
            if (left.hours == right.hours && left.minutes > right.minutes)
                return true;
            return false;
        }
        public static bool operator < (TimeUnit left, TimeUnit right)
        {
            return left != right && !(left > right);
        }

        public void Randomise ( )
        {
            hours = Program.R.Next(24);
            minutes = Program.R.Next(60);
        }

        public TimeUnit ( )
        {
            created++;
            hours = 0;
            minutes = 0;
        }
        public TimeUnit (int hours, int minutes)
        {
            created++;
            Hours = hours;
            Minutes = minutes;
        }
        public TimeUnit(bool rand)
        {
            created++;
            if (rand)
                Randomise();
        }
        ~TimeUnit( )
        {
            destroyed++;
        }

        public static explicit operator int (TimeUnit t)
        {
            return t.hours*60 + t.minutes;
        }
        public static explicit operator bool (TimeUnit t)
        {
            return t == zero;
        }
        
        public override string ToString ()
        {
            return hours + ":" + $"{minutes:00}";
        }
        public override bool Equals (object obj)
        {
            return this == (TimeUnit)obj;
        }
        public override int GetHashCode ()
        {
            return hours.GetHashCode() & minutes.GetHashCode();
        }
    }
}