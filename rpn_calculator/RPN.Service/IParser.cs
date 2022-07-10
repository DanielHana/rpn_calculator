namespace RPN.Service
{
    public interface IParser
    {
        void Add(string itemsToAdd);
        void CheckForInvalidUserInput();
        void CheckIsReadyForOperation();
        void ResetParser();
    }
}