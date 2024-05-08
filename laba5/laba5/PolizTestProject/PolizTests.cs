namespace PolizTestProject
{
    [TestClass]
    public class BlackBoxPolizTests
    {
        private POLIZ _poliz;

        [TestInitialize]
        public void TestInitialize()
        {
            _poliz = new POLIZ();
        }

        // �������� ������ � ����� ������
        [TestMethod]
        public void OneNumberTest()
        {
            string result = _poliz.ConvertToRPN("123");
            Assert.AreEqual("123", result);
        }

        // �������� ������ � ������� ���������� ��� ������
        [TestMethod]
        public void SimpleExpressionTest()
        {
            string result = _poliz.ConvertToRPN("2+3*4");
            Assert.AreEqual("2 3 4 * +", result);
        }

        // �������� ������ � ���������� �� ��������
        [TestMethod]
        public void ExpressionWithParenthesesTest()
        {
            string result = _poliz.ConvertToRPN("(2+3)*4");
            Assert.AreEqual("2 3 + 4 *", result);
        }

        // �������� ������ � ����������, ��������� ������ �� ��������
        [TestMethod]
        public void ExpressionWithOperationsOnlyTest()
        {
            string result = _poliz.ConvertToRPN("+*+");
            Assert.AreEqual("* + +", result);
        }

        // �������� ������ � ������ ����������
        [TestMethod]
        public void EmptyExpressionTest()
        {
            string result = _poliz.ConvertToRPN("");
            Assert.AreEqual("", result);
        }

        // �������� ������ � ����������, ���������� �������
        [TestMethod]
        public void ExpressionWithSpacesTest()
        {
            string result = _poliz.ConvertToRPN("2 + 3 * 4");
            Assert.AreEqual("2 3 4 * +", result);
        }
    }

    [TestClass]
    public class WhiteBoxPolizTests
    {
        private POLIZ _poliz;

        [TestInitialize]
        public void TestInitialize()
        {
            _poliz = new POLIZ();
        }

        // �������� ���������� �������� ��������
        [TestMethod]
        public void AdditionTest()
        {
            int result = _poliz.Priority("+");
            Assert.AreEqual(1, result);
        }

        // �������� ���������� �������� ���������
        [TestMethod]
        public void SubtractionTest()
        {
            int result = _poliz.Priority("-");
            Assert.AreEqual(1, result);
        }

        // �������� ���������� �������� ���������
        [TestMethod]
        public void MultiplicationTest()
        {
            int result = _poliz.Priority("*");
            Assert.AreEqual(2, result);
        }

        // �������� ���������� �������� �������
        [TestMethod]
        public void DivisionTest()
        {
            int result = _poliz.Priority("/");
            Assert.AreEqual(2, result);
        }

        // �������� ���������� ����������� ������
        [TestMethod]
        public void OpeningParenthesisTest()
        {
            int result = _poliz.Priority("(");
            Assert.AreEqual(0, result);
        }

        // �������� ������ � ���������� ��������
        [TestMethod]
        public void UnknownSymbolTest()
        {
            int result = _poliz.Priority("a");
            Assert.AreEqual(-1, result);
        }
    }
}