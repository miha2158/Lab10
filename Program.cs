using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;

namespace Lab10
{
    public class Program
    {
        public static Random R = new Random( );

        static void Main (string[] args)
        {
            #region subtract

            WriteLine("  0:00 - 1 = 23:59");
            var t1 = new TimeUnit( );
            WriteLine("t1 = {0}\n-1", t1--);
            WriteLine(t1);

            WriteLine( );
            WriteLine("  5:00 - 1 = 4:59");
            var t2 = new TimeUnit(5, 0);
            WriteLine("t2 = {0}\n-1", t2--);
            WriteLine(t2);

            WriteLine( );
            WriteLine("  15:15 - 1 = 15:14");
            var t3 = new TimeUnit(15, 15);
            WriteLine("t3 = {0}\n-1", t3--);
            WriteLine(t3);


            WriteLine( );
            WriteLine("  10:10 - 30 = 9:40");
            var t4 = new TimeUnit(10, 10);
            WriteLine("t4 = {0}\n-30", t4);
            t4 -= 30;
            WriteLine(t4);


            WriteLine( );
            WriteLine("  10:45 - 65 = 9:40");
            var t5 = new TimeUnit(10, 45);
            WriteLine("t5 = {0}\n-65",t5);
            t5 -= 65;
            WriteLine(t5);

            WriteLine( );
            WriteLine("  ???? - 1 = ????");
            var t6 = new TimeUnit(true);
            WriteLine("t6 = {0}\n-1", t2--);
            WriteLine(t6);

            #endregion

            WriteLine( );

            #region Compare

            WriteLine( );
            WriteLine("  t4 == t5 ?");
            WriteLine(t4 == t5);

            WriteLine( );
            WriteLine("  t2 == 0:00 ?");
            WriteLine(t2 == TimeUnit.zero);

            WriteLine( );
            WriteLine("  t1 != t5 ?");
            WriteLine(t1 != t5);

            WriteLine( );
            WriteLine("  t1 > t5 ?");
            WriteLine(t1 > t5);

            WriteLine( );
            WriteLine("  t2 < t5 ?");
            WriteLine(t2 < t5);

            #endregion

            WriteLine( );

            #region Lists

            var list = new TimeList( );
            WriteLine(list);
            WriteLine( );

            list = new TimeList(2);
            WriteLine(list);
            WriteLine( );

            list = new TimeList(3,true);
            WriteLine(list);
            WriteLine("Минимум: {0}",list.Min());
            WriteLine( );

            list = new TimeList(new[] { 9, 3, 3, 17, 23 }, new[] { 19, 34, 15, 55, 2 });
            WriteLine(list);
            WriteLine("Минимум: {0}", list.Min( ));
            WriteLine( );

            #endregion


            WriteLine("Количество созданных за время выполнения программы объектов типа TimeUnit: {0}",TimeUnit.created);
            WriteLine("Количество удалённых объектов типа TimeUnit: {0}", TimeUnit.destroyed);
            ReadKey(true);
        }
    }
}
