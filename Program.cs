using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string sentence = "((1+2)*(4-2)/(2))";
            char[] operators = new char[] { '+', '-', '*', '/' };
            MyStack<float> numbersStack = new MyStack<float>();
            MyStack<char> operatorsStack = new MyStack<char>();

            foreach (char c in sentence)
            {
                if (Char.IsDigit(c))
                {
                    numbersStack.Push(c - '0');
                }
                else if (c == ')')
                {
                    float num2 = numbersStack.GetStackHead();
                    numbersStack.Pop();
                    float num1 = numbersStack.GetStackHead();
                    numbersStack.Pop();
                    char op = operatorsStack.GetStackHead();
                    operatorsStack.Pop();

                    float result = ApplyOperation(num1, num2, op);
                    numbersStack.Push(result);
                }
                else if (Array.IndexOf(operators, c) != -1)
                {
                    operatorsStack.Push(c);
                }
            }

            // O resultado final estará no topo da pilha de números
            float finalResult = numbersStack.GetStackHead();
            Console.WriteLine($"Resultado: {finalResult}");
        }

        static float ApplyOperation(float num1, float num2, char op)
        {
            switch (op)
            {
                case '+':
                    return num1 + num2;
                case '-':
                    return num1 - num2;
                case '*':
                    return num1 * num2;
                case '/':
                    if (num2 != 0)
                    {
                        return num1 / num2;
                    }
                    else
                    {
                        throw new DivideByZeroException("Divisão por zero!");
                    }
                default:
                    throw new ArgumentException("Operador inválido!");
            }
        }
    }
}
