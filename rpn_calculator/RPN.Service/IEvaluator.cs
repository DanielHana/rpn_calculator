namespace RPN.Service
{
    public interface IEvaluator
    {
        double Evaluate(Stack<string> container);
    }
}