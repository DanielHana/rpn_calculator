using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPN.Service
{
    public class Parser : IParser
    {
        
        public Stack<string> Characters = new Stack<string>();
        public bool IsReadyForOperation = false;
        public List<string> Errors = new List<string>();

        public void Add(string itemsToAdd)
        {
            var itemList = itemsToAdd.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in itemList)
            {
                if (IsAllowedCharacter(item))
                    Characters.Push(item);
            }

            CheckIsReadyForOperation();
            CheckForInvalidUserInput();
        }

        private bool IsAllowedCharacter(string character)
        {
            // if the character can be converted to a double or is an operator, it is allowed
            return Double.TryParse(character, out double value)
                   || Constants.ValidOperations.Contains(character);
        }

        public void CheckIsReadyForOperation()
        {
            IsReadyForOperation = Characters.Intersect(Constants.ValidOperations).Any();
        }

        private void CheckForInvalidUserInput()
        {
            // Order of input does not matter until there has been an operator
            if (IsReadyForOperation)
            {
                var characterArray = Characters.ToArray();

                // Get the last number inputted
                var indexOfLastNumber = Array.IndexOf(characterArray,
                     characterArray.Where(character =>
                     Double.TryParse(character, out double value)).FirstOrDefault());

                // Get the first operator inputted
                var indexOfFirstOperator = Array.FindIndex(characterArray, character => Constants.ValidOperations.Contains(character));

                // Get a count of all the numbers in the array
                var numberCount = 
                     characterArray.Where(character =>
                     Double.TryParse(character, out double value)).Count();

                // Get a count of all the operators
                var operatorCount =
                    characterArray.Where(character =>
                    Constants.ValidOperations.Contains(character)).Count();

                // If there is an operator and there is also a number afterward, user violated the notation >:O
                if (indexOfFirstOperator > indexOfLastNumber)
                    Errors.Add("Error: Invalid notation detected");

                // If there are too many operators add an error
                if (operatorCount >= numberCount)
                    Errors.Add("Error: Not enough numbers to perform an operation");
                
                if (Errors.Count > 0)
                    IsReadyForOperation = false;
            }
        }

        public void ResetParser()
        {
            Characters.Clear();
            Errors.Clear();
            IsReadyForOperation = false;
        }
    }
}
