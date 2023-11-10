using System.Globalization;

namespace DijkstraTwoStackAlgorithm
{
    public class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();
            DijkstraTwoStackAlgorithm teste = new DijkstraTwoStackAlgorithm(input);
            teste.Dijkstra();
        }
    }
    public class DijkstraTwoStackAlgorithm
    {
        private ArrayStack<char> OperatorStack = new ArrayStack<char>(10);
        private ArrayStack<double> ValuesStack = new ArrayStack<double>(10);
        public string Input;
        // Ex: (((1+2)+(4*2))*3) = 33
        // Ex: (((4*((((2/5)*5)+(((2*(2*5))+5))*4))+(9+6))*(5*5)) = 11175.00
        public DijkstraTwoStackAlgorithm(string input)
        {
            Input = input;
        }

        public void Dijkstra()
        {
            foreach (char ch in Input)
            {
                switch (ch)
                {
                    case '(':
                        break;
                    case ' ':
                        break;
                    case '+':
                    case '-':
                    case '*':
                    case '/':
                        OperatorStack.Push(ch);
                        break;
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        ValuesStack.Push(double.Parse(ch.ToString()));
                        break;
                    case ')':
                        char op = OperatorStack.Pop();
                        switch (op)
                        {
                            case '+':
                                ValuesStack.Push(ValuesStack.Pop() + ValuesStack.Pop());
                                break;
                            case '-':
                                ValuesStack.Push(ValuesStack.Pop() - ValuesStack.Pop());
                                break;
                            case '*':
                                ValuesStack.Push(ValuesStack.Pop() * ValuesStack.Pop());
                                break;
                            case '/':
                                double denominator = ValuesStack.Pop();
                                ValuesStack.Push(ValuesStack.Pop() / denominator);
                                break;
                        }
                        break;
                    default:
                        ValuesStack.Push(double.Parse(ch.ToString()));
                        break;
                }
            }
            Console.WriteLine(ValuesStack.Pop().ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}