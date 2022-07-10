using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPN.Service
{
    public class Evaluator
    {
        public double Evaluate(Stack<string> container)
        {
            string topCharacter = container.Pop();
            double firstOperand, secondOperand;
            
            // if topCharacter is not a number, use it as the operator
            if (!Double.TryParse(topCharacter, out firstOperand))
            {
                // the first operand pulled is actually the second in order of operation, since it was added to the stack later
                secondOperand = Evaluate(container);
                firstOperand = Evaluate(container);
                firstOperand = PerformOperation(topCharacter, firstOperand, secondOperand);
            }
            return firstOperand;
        }

        public static double PerformOperation(string operation, double firstOperand, double secondOperand) => operation switch
        {
            "+" => firstOperand + secondOperand,
            "-" => firstOperand - secondOperand,
            "*" => firstOperand * secondOperand,
            "/" => firstOperand / secondOperand,
            _ => throw new InvalidOperationException($"Invalid operation performed, attempted the operation \"{firstOperand} {operation} {secondOperand}\""),
        };
    }
}
