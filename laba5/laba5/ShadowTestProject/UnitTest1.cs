using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1;

namespace ShadowTestProject
{
    [TestClass]
    public class ShadowTest1
    {
        [TestMethod]
        public void TestIfLengthEqualsZero()
        {
            OX ox = new OX();
            ox.lines.Add(new Line(0, 0));
            Value value = new Value(ox);
            Assert.AreEqual(0, value.shadow_lenght());
        }
        [TestMethod]
        public void TestIfLengthEqualsZeroMultipleLines()
        {
            OX ox = new OX();
            ox.lines.Add(new Line(0, 0));
            ox.lines.Add(new Line(0, 0));
            ox.lines.Add(new Line(0, 0));
            Value value = new Value(ox);
            Assert.AreEqual(0, value.shadow_lenght());
        }
        [TestMethod]
        public void TestSingleLine()
        {
            OX ox = new OX();
            ox.lines.Add(new Line(5, 11));
            Value value = new Value(ox);
            Assert.AreEqual(6, value.shadow_lenght());
        }
        [TestMethod]
        public void TestShadowdryadom()
        {
            OX ox = new OX();
            ox.lines.Add(new Line(-2, 1));
            ox.lines.Add(new Line(1, 4));
            Value value = new Value(ox);
            Assert.AreEqual(6, value.shadow_lenght());
        }
        [TestMethod]
        public void TestShadowSprobelami()
        {
            OX ox = new OX();
            ox.lines.Add(new Line(-1, 1));
            ox.lines.Add(new Line(2, 5));
            Value value = new Value(ox);
            Assert.AreEqual(5, value.shadow_lenght());
        }
        [TestMethod]
        public void TestLineOutOfRange()
        {
            Line line = new Line(1000, 1000);
            Assert.IsFalse(line.check());
        }
    }
}