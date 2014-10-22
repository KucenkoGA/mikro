using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab3
{
    class Program
    {
        object obj = new object();

        static int Count_Threads,
            Count_Cars,
            Interval_Car_Time = 5,   // сек.
            Time_Service_Min = 2,
            Time_Service_Max = 6;
        static double All_Time;      //мин
        static int[] Car_Kass;
        static int[] Car_Kass_Serviced;
        static Random r = new Random();
        static DateTime dt_start;
        static Timer t;

        static void Car_Kass_Write()
        {
            if (((new TimeSpan(DateTime.Now.Ticks) - (new TimeSpan(dt_start.Ticks))).TotalMilliseconds) > All_Time * 60 * 1000)
            {
                t.Dispose();
                Console.WriteLine("\nОсталось необслуженных маш.:");
                for (int i = 0; i < Count_Threads; i++)
                    Console.WriteLine("Касса {0}: {1}", i, Car_Kass[i]);
                Console.WriteLine("Обслуженных маш.:");
                for (int i = 0; i < Count_Threads; i++)
                    Console.WriteLine("Касса {0}: {1}", i, Car_Kass_Serviced[i]);
            }
            else
            {
                Console.WriteLine("Состояние сервиса:");
                Console.WriteLine("Текущее время - {0} милисек.; общее время измерения - {1} милисек.", (new TimeSpan(DateTime.Now.Ticks) - (new TimeSpan(dt_start.Ticks))).TotalMilliseconds, All_Time * 60 * 1000);
                for (int i = 0; i < Count_Threads; i++)
                    Console.WriteLine("Касса {0}: {1}", i, Car_Kass[i]);
            }
        }

        static void Del_Car(object source)
        {
            if (Car_Kass[(int)source] != 0)
            {
                Car_Kass[(int)source]--;
                Car_Kass_Serviced[(int)source]++;
            }
        }

        static void Service(int num)
        {
            int interval = Get_Interval(r);
            Timer myTimer = new Timer(new TimerCallback(Del_Car), num, interval * 1000, interval * 1000);
        }
       
        static int Get_Interval(Random r)
        {
            return r.Next(Time_Service_Min, Time_Service_Max);
        }

        static void Add_Cars(object source)
        {
            if (((new TimeSpan(DateTime.Now.Ticks) - (new TimeSpan(dt_start.Ticks))).TotalMilliseconds) <= All_Time * 60 * 1000)
            {
                Console.WriteLine("\nПрибыло {0} маш.", Count_Cars);
                for (int j = 0; j < Count_Cars; j++)
                    Car_Kass[j % Count_Threads]++;
            }
            Car_Kass_Write();
        }

        static void Main(string[] args)
        {
            args = new string[3];
            args[0] = "4"; args[1] = "5"; args[2] = "0,4";
            if (args.Length == 3)
                try
                {
                    Count_Threads = Convert.ToInt32(args[0]);
                    if (Count_Threads < 0) Count_Threads = 1;
                    Count_Cars = Convert.ToInt32(args[1]);
                    if (Count_Cars < 0) Count_Cars = 1;
                    All_Time = Convert.ToDouble(args[2]);
                    if (All_Time < 0) All_Time = 1;
                    Car_Kass = new int[Count_Threads];
                    Car_Kass_Serviced = new int[Count_Threads];

                    Console.WriteLine("---- CAR SERVICE ----");
                    Console.WriteLine("Количество касс: {0}", Count_Threads);
                    Console.WriteLine("Количество машин каждые 5 секунд: {0}", Count_Cars);
                    Console.WriteLine("Интервал измерения: {0} мин.", All_Time);
                    
                    dt_start = DateTime.Now;

                    t = new Timer(new TimerCallback(Add_Cars));
                    t.Change(0, Interval_Car_Time * 1000);

                    Parallel.For(0, Count_Threads, i =>
                        {
                            Service(i);
                        });
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            else
                Console.WriteLine("Кол-во аргументов должно быть равно 3: количество касс, количество машин в ед.времени (5 секунд), интервал измерения (в минутах)");

            Console.ReadLine();
        }
    }
}
