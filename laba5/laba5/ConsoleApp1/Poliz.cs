using System.Text;

public class POLIZ
{
    public static string ConvertToRPN(string expression)
    {
        List<string> outputList = new List<string>();
        Stack<string> stack = new Stack<string>();
        StringBuilder number = new StringBuilder();

        foreach (var c in expression.Where(c => !char.IsWhiteSpace(c)))
        {
            if (char.IsDigit(c))
            {
                number.Append(c);
            }
            else
            {
                if (number.Length > 0)
                {
                    outputList.Add(number.ToString());
                    number.Clear();
                }

                if (c == '(')
                {
                    stack.Push(c.ToString());
                }
                else if (c == ')')
                {
                    while (stack.Count > 0 && stack.Peek() != "(")
                    {
                        outputList.Add(stack.Pop());
                    }
                    stack.Pop();
                }
                else
                {
                    while (stack.Count > 0 && Priority(c.ToString()) <= Priority(stack.Peek()))
                    {
                        outputList.Add(stack.Pop());
                    }
                    stack.Push(c.ToString());
                }
            }
        }

        if (number.Length > 0)
        {
            outputList.Add(number.ToString());
        }

        while (stack.Count > 0)
        {
            outputList.Add(stack.Pop());
        }

        return string.Join(" ", outputList);
    }

    static int Priority(string c)
    {
        if (c == "(")
        {
            return 0;
        }
        else if (c == "+" || c == "-")
        {
            return 1;
        }
        else if (c == "*" || c == "/")
        {
            return 2;
        }
        else
        {
            return -1;
        }
    }
}