using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


//C:\Documents and Settings\User\Рабочий стол\Triangle\tri.txt
namespace Triangle
{
    class Program
    {
        //считывает строку, если все ок - записывает в файл результат
        //выводит инфо в лог
        static void ReadNextLine(StreamReader sr, StreamWriter sw)
        {
            if(!sr.EndOfStream)
            { 
                double a = 0, b = 0, c = 0, alf = 0, bet = 0, gam = 0;
                Triangle t = new Triangle();
                string fine_read = "ok";
                string line = sr.ReadLine();
                try
                {
                    char[] ch = new char[1] { ';' };
                    string[] value = line.Split(ch);

                    a = Convert.ToDouble(value[0]);
                    b = Convert.ToDouble(value[1]);
                    alf = Convert.ToDouble(value[2]);
                }
                catch 
                {
                    fine_read = "incorrect string " + line;
                }
                if (fine_read == "ok")
                {
                    string res = FindValue(a, b, alf, t);
                    if (res == "ok")
                    {
                        c = t.GetC();
                        bet = t.GetBeta();
                        gam = t.GetGamma();
                        sw.WriteLine(a.ToString("0.000") + ';' + b.ToString("0.000") + ';' + c.ToString("0.000"));
                        Console.WriteLine("{0:0.000};{1:0.000}", bet, gam);
                    }
                    else
                        Console.WriteLine(res);
                }
                else
                    Console.WriteLine(fine_read);
            }
        }
        static string FindValue(double A, double B, double Alfa, Triangle t)
        {
            string s1 = t.SetA(A);
            if (s1 == "ok")
            {
                string s2 = t.SetB(B);
                if (s2 == "ok")
                {
                    string s3 = t.SetAlfa(Alfa);
                    if (s3 == "ok")
                    {
                        t.FindC();
                        t.FindBeta(); 
                        t.FindLast();
                        return "ok";
                    }
                    else
                        return s3;
                }
                else
                    return s2;
            }
            else
                return s1;
        }
        static void Main(string[] args)
        {
            string file_in = "",
                   file_out = "";
            file_in = Console.ReadLine();
            file_out = Console.ReadLine();
            try
            {
                StreamReader sr = new StreamReader(file_in);
                StreamWriter sw = new StreamWriter(file_out);
                while (!sr.EndOfStream)
                {
                    ReadNextLine(sr, sw);
                }
                sr.Close();
                sw.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine("file {0} not found", file_in);
            }
        }
    }
}
