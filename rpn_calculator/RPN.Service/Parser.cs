using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPN.Service
{
    public class Parser
    {
        public string[] ValidOperations = new string[] { "+", "-", "/", "*" };

        public Stack<string> Characters = new Stack<string>();

        public void Add(string itemsToAdd)
        {
            var itemList = itemsToAdd.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach(var item in itemList)
            {
                if(IsValidInput(item))
                    Characters.Push(item);
            }
        }

        private bool IsValidInput(string character)
        {
            // if the character can be converted to a double or is an operator, it is allowed
            return Double.TryParse(character, out double value) 
                   || ValidOperations.Contains(character);
        }

        public bool IsReadyForOperation()
        {
            return Characters.Intersect(ValidOperations).Any();
        }
    }
}
