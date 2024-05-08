using ConsoleApp1;

namespace ShadowTestProject
{
    [TestClass]
    public class BlackBoxTests
    {
        [TestMethod]
        public void TestIfLengthEqualsZero()
        {
            Shadow shadow = new Shadow();
            shadow.AddLine(0,0);
            int value = shadow.GetSum();
            Assert.AreEqual(0, value);
        }
        [TestMethod]
        public void TestIfLengthEqualsZeroMultipleLines()
        {
            Shadow shadow = new Shadow();
            shadow.AddLine(0, 0);
            shadow.AddLine(0, 0);
            shadow.AddLine(0, 0);
            int value = shadow.GetSum();
            Assert.AreEqual(0, value);
        }
        [TestMethod]
        public void TestSingleLineBothPositive()
        {
            Shadow shadow = new Shadow();
            shadow.AddLine(5, 11);
            int value = shadow.GetSum();
            Assert.AreEqual(6, value);
        }
        [TestMethod]
        public void TestSingleLineBothNegative()
        {
            Shadow shadow = new Shadow();
            shadow.AddLine(-3, -8);
            int value = shadow.GetSum();
            Assert.AreEqual(5, value);
        }
        [TestMethod]
        public void TestSingleLineDifferentSigns()
        {
            Shadow shadow = new Shadow();
            shadow.AddLine(-5, 11);
            int value = shadow.GetSum();
            Assert.AreEqual(16, value);
        }
        [TestMethod]
        public void TestMultipleLinesPositive()
        {
            Shadow shadow = new Shadow();
            shadow.AddLine(1, 3);
            shadow.AddLine(5, 8);
            shadow.AddLine(9, 13);
            int value = shadow.GetSum();
            Assert.AreEqual(9, value);
        }
        [TestMethod]
        public void TestMultipleLinesNegative()
        {
            Shadow shadow = new Shadow();
            shadow.AddLine(-1, -3);
            shadow.AddLine(-5, -8);
            shadow.AddLine(-9, -13);
            int value = shadow.GetSum();
            Assert.AreEqual(9, value);
        }
        [TestMethod]
        public void TestMultipleLinesDifferentSigns()
        {
            Shadow shadow = new Shadow();
            shadow.AddLine(-1, 3);
            shadow.AddLine(-5, 2);
            shadow.AddLine(-9, 1);
            int value = shadow.GetSum();
            Assert.AreEqual(12, value);
        }
        [TestMethod]
        public void TestMultipleLinesCollide()
        {
            Shadow shadow = new Shadow();
            shadow.AddLine(1, 4);
            shadow.AddLine(2, 7);
            shadow.AddLine(5, 10);
            int value = shadow.GetSum();
            Assert.AreEqual(9, value);
        }
        [TestMethod]
        public void TestMultipleLinesFill()
        {
            Shadow shadow = new Shadow();
            shadow.AddLine(1, 11);
            shadow.AddLine(2, 7);
            shadow.AddLine(5, 10);
            int value = shadow.GetSum();
            Assert.AreEqual(10, value);
        }
    }

    [TestClass]
    public class WhiteBoxTests
    {
        [TestMethod]
        public void TestIfNoLinesAdded()
        {
            Shadow shadow = new Shadow();
            int value = shadow.GetSum();
            Assert.AreEqual(0, value);
        }
        [TestMethod]
        public void TestLinesAreSeparated()
        {
            Shadow shadow = new Shadow();
            shadow.AddLine(1, 4);
            shadow.AddLine(5, 8);
            shadow.AddLine(9, 11);
            int value = shadow.GetSum();
            Assert.AreEqual(8, value);
        }
        [TestMethod]
        public void TestLinesAreCollided()
        {
            Shadow shadow = new Shadow();
            shadow.AddLine(1, 15);
            shadow.AddLine(4, 9);
            shadow.AddLine(5, 11);
            int value = shadow.GetSum();
            Assert.AreEqual(14, value);
        }
        [TestMethod]
        public void TestLastLineCalculation()
        {
            Shadow shadow = new Shadow();
            shadow.AddLine(1, 15);
            shadow.AddLine(4, 9);
            shadow.AddLine(5, 11);
            int value = shadow.GetSum();
            Assert.AreEqual(14, value);
        }
        [TestMethod]
        public void TestLoopEndAfterLastLine()
        {
            Shadow shadow = new Shadow();
            shadow.AddLine(1, 15);
            shadow.AddLine(4, 9);
            shadow.AddLine(5, 11);
            int value = shadow.GetSum();
            Assert.AreEqual(14, value);
        }
    }


}