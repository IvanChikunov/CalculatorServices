using calculator_back.Consts;
using calculator_back.Services.Interfaces;

namespace calculator_back.Services
{
    public class CustomCalculator : ICalculationService
    {
        public CalculationServicesEnum CalculationServiceType => CalculationServicesEnum.Custom;

        static bool isNumber(string value)
        {
            return int.TryParse(value, out int result);
        }

        static int isOperator(char symbol)
        {
            switch (symbol)
            {
                case '+': return 0;
                case '-': return 0;
                case '*': return 1;
                case '/': return 1;
                default:
                    return -1;
            }
        }

        static double calculateOperation(double exp1, double exp2, char operation)
        {
            switch (operation)
            {
                case '+': return exp1 + exp2;
                case '-': return exp1 - exp2;
                case '*': return exp1 * exp2;
                case '/': return exp1 / exp2;
                default:
                    throw new Exception("Нет подходящего оператора");
            }
        }

        public string Calculate(string expression)
        {
            try
            {
                if (!expression.Any(v => v == '+' || v == '-' || v == '*' || v == '/'))
                {
                    expression = expression.Replace("(", string.Empty);
                    expression = expression.Replace(")", string.Empty);
                }
                double result;
                if (double.TryParse(expression, out result))
                    return result.ToString();
                //List<OperatorPos> operators = new List<OperatorPos>();
                int priority = 0;
                int minPriority = expression.Length;
                int minPriorityPos = 0;
                for (int i = 0; i < expression.Length; i++)
                {
                    int symbWeight = isOperator(expression[i]);
                    if (symbWeight > -1 && priority + symbWeight <= minPriority)
                    {
                        minPriority = priority + symbWeight;
                        minPriorityPos = i;
                    }
                    //operators.Add(new OperatorPos() { Operation = expression[i], Pos = i, Priority = priority + symbWeight });
                    if (expression[i] == '(') priority += 2;
                    if (expression[i] == ')') priority -= 2;
                }
                //OperatorPos solvingOperator = operators.
                string leftPart = expression.Substring(0, minPriorityPos);
                string rightPart = expression.Substring(minPriorityPos + 1);
                double.TryParse(Calculate(leftPart), out double leftResult);
                double.TryParse(Calculate(rightPart), out double rightResult);

                return calculateOperation(leftResult, rightResult, expression[minPriorityPos]).ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
