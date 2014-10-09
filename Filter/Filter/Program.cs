using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Filter
{
    class Program
    {
        public static void Main(string[] args)
        {
            //args = new string[2]; args[0] = @"норм.jpeg";
            //args[1] = @"норм_итог.jpeg";
            if (args.Length != 2) Console.WriteLine("Количество аргументов должно быть 2!");
            else
            {
                try
                {
                    string file_in = args[0], file_out = args[1];
                    Filter bmp = new Filter();
                    bmp.Load_Picture(file_in);
                    bmp.Filter_And_Save(file_out);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.ReadLine();

            
        }
    }
}
