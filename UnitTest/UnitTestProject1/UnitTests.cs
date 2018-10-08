using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTest;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTests
    {
        Triangle triangle = new Triangle();
        [TestMethod]
        public void TestEnterSidesOfEgyptTriangle()
        {         
            Assert.AreEqual(true, triangle.IsTriangle(3, 4, 5));
        }

        [TestMethod]
        public void TestEnterSameLengthforAllSides()
        {
            Assert.AreEqual(true, triangle.IsTriangle(4, 4, 4));
        }

        [TestMethod]
        public void TestEnterZeroLengthforAllSides()
        {
            Assert.AreEqual(false, triangle.IsTriangle(0, 0, 0));
        }

        [TestMethod]
        public void TestEnterNegativeLengthforAllSides()
        {
            Assert.AreEqual(false, triangle.IsTriangle(-3, -4, -5));
        }

        [TestMethod]
        public void TestEnterrNegativeLengthforFirstSide()
        {
            Assert.AreEqual(false, triangle.IsTriangle(-3, 4, 5));
        }

        [TestMethod]
        public void TestEnterTooLargeLengthForFirstSide()
        {
            Assert.AreEqual(false, triangle.IsTriangle(30, 3, 3));
        }

        [TestMethod]
        public void TestEnterTooLargeLengthForSecondSide()
        {
            Assert.AreEqual(false, triangle.IsTriangle(1, 30, 1));
        }

        [TestMethod]
        public void TestEnterTooLargeLengthForThirdSide()
        {
            Assert.AreEqual(false, triangle.IsTriangle(1, 1, 30));
        }

        [TestMethod]
        public void TestEnterFractialLengthofAllSides()
        {
            Assert.AreEqual(true, triangle.IsTriangle(3.3, 4.4, 5.5));
        }

        [TestMethod]
        public void TestEnterBigLengthofSides()
        {
            Assert.AreEqual(true, triangle.IsTriangle(3000, 4000, 5000));
        }
    }
}
