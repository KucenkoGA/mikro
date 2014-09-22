using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Triangle;

namespace Unit_Test
{
    [TestClass]
    public class Unit_Test
    {
        [TestMethod]
        public void TestMethod_C1()                 // для FindC()
        {
            Triangle.Triangle tr = new Triangle.Triangle();
            tr.SetA(3);
            tr.SetB(4);
            tr.SetAlfa(90);

            tr.FindC();
            double c = tr.GetC();
            Assert.AreEqual(5, c, 0.01);
        }

        [TestMethod]
        public void TestMethod_C2()                 // для FindC()
        {
            Triangle.Triangle tr = new Triangle.Triangle();
            tr.SetA(1);
            tr.SetB(6);
            tr.SetAlfa(110);

            tr.FindC();
            double c = tr.GetC();
            Assert.AreEqual(6.41, c, 0.01);
        }

        [TestMethod]
        public void TestMethod_Bet1()                 // для FindBeta()
        {
            Triangle.Triangle tr = new Triangle.Triangle();
            tr.SetA(3);
            tr.SetB(4);
            tr.SetAlfa(90);

            tr.FindBeta();
            double bet = tr.GetBeta();
            Assert.AreEqual(36.87, bet, 0.01);
        }

        [TestMethod]
        public void TestMethod_Bet2()                 // для FindBeta()
        {
            Triangle.Triangle tr = new Triangle.Triangle();
            tr.SetA(1);
            tr.SetB(6);
            tr.SetAlfa(110);

            tr.FindBeta();
            double bet = tr.GetBeta();
            Assert.AreEqual(8.43, bet, 0.01);
        }

        [TestMethod]
        public void TestMethod_Gam1()                 // для FindLast()
        {
            Triangle.Triangle tr = new Triangle.Triangle();
            tr.SetA(3);
            tr.SetB(4);
            tr.SetAlfa(90);

            tr.FindLast();
            double gam = tr.GetGamma();
            Assert.AreEqual(53.13, gam, 0.01);
        }

        [TestMethod]
        public void TestMethod_Gam2()                 // для FindLast()
        {
            Triangle.Triangle tr = new Triangle.Triangle();
            tr.SetA(1);
            tr.SetB(6);
            tr.SetAlfa(110);

            tr.FindLast();
            double gam = tr.GetGamma();
            Assert.AreEqual(61.57, gam, 0.01);
        }

        [TestMethod]
        public void TestMethod_C1_not1()                 // для FindC() с неверным результатом
        {
            Triangle.Triangle tr = new Triangle.Triangle();
            tr.SetA(3);
            tr.SetB(4);
            tr.SetAlfa(90);

            tr.FindC();
            double c = tr.GetC();
            Assert.AreEqual(56, c, 0.01);
        }

        [TestMethod]
        public void TestMethod_Bet1_not1()                 // для FindBeta() с неверным результатом
        {
            Triangle.Triangle tr = new Triangle.Triangle();
            tr.SetA(3);
            tr.SetB(4);
            tr.SetAlfa(90);

            tr.FindBeta();
            double bet = tr.GetBeta();
            Assert.AreEqual(14, bet, 0.01);
        }

        [TestMethod]
        public void TestMethod_Gam1_not1()                 // для FindLast() с неверным результатом
        {
            Triangle.Triangle tr = new Triangle.Triangle();
            tr.SetA(3);
            tr.SetB(4);
            tr.SetAlfa(90);

            tr.FindLast();
            double gam = tr.GetGamma();
            Assert.AreEqual(41, gam, 0.01);
        }

        [TestMethod]
        public void TestMethod_C1_not2()                 // для FindC() с некорректными данными
        {
            Triangle.Triangle tr = new Triangle.Triangle();
            tr.SetA(-3);
            tr.SetB(4);
            tr.SetAlfa(90);

            tr.FindC();
            double c = tr.GetC();
            Assert.AreEqual(5, c, 0.01);
        }

        [TestMethod]
        public void TestMethod_Bet1_not2()                 // для FindBeta() с некорректными данными
        {
            Triangle.Triangle tr = new Triangle.Triangle();
            tr.SetA(3);
            tr.SetB(4);
            tr.SetAlfa(200);

            tr.FindBeta();
            double bet = tr.GetBeta();
            Assert.AreEqual(36.87, bet, 0.01);
        }

        [TestMethod]
        public void TestMethod_Gam1_not2()                 // для FindLast() с некорректными данными
        {
            Triangle.Triangle tr = new Triangle.Triangle();
            tr.SetA(3);
            tr.SetB(-4);
            tr.SetAlfa(181);

            tr.FindLast();
            double gam = tr.GetGamma();
            Assert.AreEqual(53.13, gam, 0.01);
        }

        [TestMethod]
        [ExpectedException(typeof(System.IO.FileNotFoundException))]           
        public void TestMethod_File()                                 
        {
            string[] argss = new string[] { "123.txt", "321.txt" };
            Program.Main(argss);
        }
    }
}
