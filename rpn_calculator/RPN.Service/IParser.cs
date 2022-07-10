namespace RPN.Service
{
    public interface IParser
    {
        void Add(string itemsToAdd);
        void CheckIsReadyForOperation();
        void ResetParser();
    }
}