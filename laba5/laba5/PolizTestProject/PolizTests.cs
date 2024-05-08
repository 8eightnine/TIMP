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

        // Проверка работы с одним числом
        [TestMethod]
        public void OneNumberTest()
        {
            string result = _poliz.ConvertToRPN("123");
            Assert.AreEqual("123", result);
        }

        // Проверка работы с простым выражением без скобок
        [TestMethod]
        public void SimpleExpressionTest()
        {
            string result = _poliz.ConvertToRPN("2+3*4");
            Assert.AreEqual("2 3 4 * +", result);
        }

        // Проверка работы с выражением со скобками
        [TestMethod]
        public void ExpressionWithParenthesesTest()
        {
            string result = _poliz.ConvertToRPN("(2+3)*4");
            Assert.AreEqual("2 3 + 4 *", result);
        }

        // Проверка работы с выражением, состоящим только из операций
        [TestMethod]
        public void ExpressionWithOperationsOnlyTest()
        {
            string result = _poliz.ConvertToRPN("+*+");
            Assert.AreEqual("* + +", result);
        }

        // Проверка работы с пустым выражением
        [TestMethod]
        public void EmptyExpressionTest()
        {
            string result = _poliz.ConvertToRPN("");
            Assert.AreEqual("", result);
        }

        // Проверка работы с выражением, содержащим пробелы
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

        // Проверка приоритета операции сложения
        [TestMethod]
        public void AdditionTest()
        {
            int result = _poliz.Priority("+");
            Assert.AreEqual(1, result);
        }

        // Проверка приоритета операции вычитания
        [TestMethod]
        public void SubtractionTest()
        {
            int result = _poliz.Priority("-");
            Assert.AreEqual(1, result);
        }

        // Проверка приоритета операции умножения
        [TestMethod]
        public void MultiplicationTest()
        {
            int result = _poliz.Priority("*");
            Assert.AreEqual(2, result);
        }

        // Проверка приоритета операции деления
        [TestMethod]
        public void DivisionTest()
        {
            int result = _poliz.Priority("/");
            Assert.AreEqual(2, result);
        }

        // Проверка приоритета открывающей скобки
        [TestMethod]
        public void OpeningParenthesisTest()
        {
            int result = _poliz.Priority("(");
            Assert.AreEqual(0, result);
        }

        // Проверка работы с незнакомым символом
        [TestMethod]
        public void UnknownSymbolTest()
        {
            int result = _poliz.Priority("a");
            Assert.AreEqual(-1, result);
        }
    }
}