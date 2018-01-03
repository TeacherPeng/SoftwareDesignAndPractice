using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestLesson01;

namespace UnitTests
{
    [TestClass]
    public class ComplexTests
    {
        [TestMethod]
        public void ComplexAddTest()
        {
            Complex c1 = new Complex(1, 2);
            Complex c2 = new Complex(3, 4);
            Complex c3 = c1 + c2;

            Console.WriteLine($"{c1.x}+{c1.y}i + {c2.x}+{c2.y}i = {c3.x}+{c3.y}i");
            Assert.AreEqual(c3.x, 4);
            Assert.AreEqual(c3.y, 6);
        }

        [TestMethod]
        public void ComplexSubTest()
        {
            Complex c1 = new Complex(4, 7);
            Complex c2 = new Complex(1, 2);
            Complex c3 = c1 - c2;

            Assert.AreEqual(c3.x, 3);
            Assert.AreEqual(c3.y, 5);
        }
    }
}
