using Filter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Unit_Tests
{
    
    
    /// <summary>
    ///Это класс теста для FilterTest, в котором должны
    ///находиться все модульные тесты FilterTest
    ///</summary>
    [TestClass()]
    public class FilterTest
    {


        private TestContext testContextInstance;



        [TestMethod]
        [ExpectedException(typeof(System.IO.FileNotFoundException))]
        public void TestMethod_File()
        {
            string[] argss = new string[] { "123.jpeg", "321.jpeg" };
            Program.Main(argss);
        }
        
    }
}
