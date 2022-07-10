using RPN.Service;

// Make the console blue because i like blue
Console.BackgroundColor = ConsoleColor.Blue;
Console.Clear();
Console.ForegroundColor = ConsoleColor.White;

var evaluator = new Evaluator();
var parser = new Parser();
var exitOptions = new string[] { "q", "\\n", "", Environment.NewLine, "exit", "q!:", "x" };

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
        foreach (var error in parser.Errors)
        {
            Console.WriteLine(error);
        }
        Console.WriteLine("Clearing stack, please try a different input");
        parser.ResetParser();
    }
    else
    {
        Console.WriteLine(userInput);
    }
}

