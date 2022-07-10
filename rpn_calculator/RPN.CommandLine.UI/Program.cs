using RPN.Service;

// Make the console blue because i like blue
Console.BackgroundColor = ConsoleColor.Blue;
Console.Clear();
Console.ForegroundColor = ConsoleColor.White;

var evaluator = new Evaluator();
var parser = new Parser();
var exitOptions = new string[] { "q", "\\n", "", Environment.NewLine, "exit", "q!:", "x" };
var clearOptions = new string[] { "clear" };
var listOptions = new string[] { "list", "ls" };

ListSupportedOperators(false);

while (true)
{
    Console.Write("> ");
    string? userInput = Console.ReadLine();

    if (string.IsNullOrEmpty(userInput) || exitOptions.Contains(userInput.ToLower())) break;

    parser.Add(userInput);

    if(parser.IsReadyForOperation)
    {
        double result = evaluator.Evaluate(parser.Characters);
        parser.Add(result.ToString());
        Console.WriteLine(result);
    }
    else if(parser.Errors.Count > 0)
    {
        Console.Clear();
        foreach (var error in parser.Errors)
            Console.WriteLine(error);
        
        ListSupportedOperators(true);
        parser.ResetParser();
    }
    else
    { 
        Console.WriteLine(userInput);
    }

    if (clearOptions.Contains(userInput.ToLower()))
    {
        Console.Clear();
        parser.ResetParser();
        ListSupportedOperators(true);
    }

    if (listOptions.Contains(userInput))
    { 
        Console.WriteLine("Current Stack:");
        foreach (var a in parser.Characters)
            Console.WriteLine(a);
    }
}

void ListSupportedOperators(bool clearingConsole)
{
    if (clearingConsole) Console.WriteLine("Caclulator cleared.");
    Console.WriteLine("Please input an equation in Reverse Polish Notation");
    Console.WriteLine("Supported Operaters: ");
    Array.ForEach(Constants.ValidOperations, Console.WriteLine);
}