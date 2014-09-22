using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Triangle
{
    public class Triangle
    {
        double a, b, c;
        double alf, bet, gam;

        //третья сторона
        public void FindC()
        {
            c = Math.Sqrt(a * a + b * b - 2 * a * b * Math.Cos(GradToRad(alf)));
        }
        //угол betta
        public void FindBeta()
        {
            FindC();                                                           // !!!
            bet = RadToGrad(Math.Asin(Math.Sin(GradToRad(alf)) * a * 1.0 / c));
        }
        //угол gamma
        public void FindLast()
        {
            FindBeta();                                                       // !!!
            gam = 180 - alf - bet;
        }
        //радианы в градусы
        public double RadToGrad(double rad)
        {
            return rad * 180.0 / Math.PI;
        }
        //градусы в радианы
        public double GradToRad(double grad)
        {
            return grad * Math.PI / 180.0;
        }

        public string SetA(double A)
        {
            if (A > 0)
            {
                a = A;
                return "ok";
            }
            else return "incorrect value a " + A;
        } 

        public double GetA()
        {
            return a;
        }

        public string SetB(double B)
        {
            if (B > 0)
            {
                b = B;
                return "ok";
            }
            else return "incorrect value b " + B;
        }

        public double GetB()
        {
            return b;
        }

        public string SetAlfa(double Alfa)
        {
            if (Alfa > 0 & Alfa < 180)
            {
                alf = Alfa;
                return "ok";
            }
            else return "incorrect value alfa " + Alfa;
        }

        public double GetAlfa()
        {
            return alf;
        }

        public double GetC()
        {
            return c;
        }

        public double GetBeta()
        {
            return bet;
        }

        public double GetGamma()
        {
            return gam;
        }
    }
}
