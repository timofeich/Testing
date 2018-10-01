using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTest;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestEnterSidesOfEgyptTriangle()
        {
            var triangle = new Triangle();
            Assert.AreEqual(true, triangle.IsTriangle(3, 4, 5));
        }

        [TestMethod]
        public void TestEnterSameLengthforAllSides()
        {
            var triangle = new Triangle();
            Assert.AreEqual(true, triangle.IsTriangle(4, 4, 4));
        }

        [TestMethod]
        public void TestEnterZeroLengthforAllSides()
        {
            var triangle = new Triangle();
            Assert.AreEqual(false, triangle.IsTriangle(0, 0, 0));
        }

        [TestMethod]
        public void TestEnterNegativeLengthforAllSides()
        {
            var triangle = new Triangle();
            Assert.AreEqual(false, triangle.IsTriangle(-3, -4, -5));
        }

        [TestMethod]
        public void TestEnterrNegativeLengthforFirstSide()
        {
            var triangle = new Triangle();
            Assert.AreEqual(false, triangle.IsTriangle(-3, 4, 5));
        }

        [TestMethod]
        public void TestEnterTooLargeLengthForFirstSide()
        {
            var triangle = new Triangle();
            Assert.AreEqual(false, triangle.IsTriangle(30, 3, 3));
        }

        [TestMethod]
        public void TestEnterTooLargeLengthForSecondSide()
        {
            var triangle = new Triangle();
            Assert.AreEqual(false, triangle.IsTriangle(1, 30, 1));
        }

        [TestMethod]
        public void TestEnterTooLargeLengthForThirdSide()
        {
            var triangle = new Triangle();
            Assert.AreEqual(false, triangle.IsTriangle(1, 1, 30));
        }

        [TestMethod]
        public void TestEnterFractialLengthofAllSides()
        {
            var triangle = new Triangle();
            Assert.AreEqual(true, triangle.IsTriangle(3.3, 4.4, 5.5));
        }

        [TestMethod]
        public void TestEnterBigLengthofSides()
        {
            var triangle = new Triangle();
            Assert.AreEqual(true, triangle.IsTriangle(3000, 4000, 5000));
        }
    }
}
