# The RPN Calculator!
The Reverse Polish Notation (RPN) Calculator is a calcuator in which operands follow their operands, and this is my simple CLI app implementing that specification.

In an RPN Calculator, rather than inputting 1 + 1, you would input 1 1 + to get the same result.

Multiple operands would just be concatenated at the end, for example 3 * (4 - 5) would be expressed in RPN as 3 4 5 * - 

This app currently supports the following operators:

\+ (addition)

\- (subtraction)

\* (multipication)

\/ (division)

## Design Choices
This could have easily been written in a single file, but I decided to split it up into a project for parsing/evaluation and a project for the CLI UI, the reason being if I ever decide to make a different UI I can easily just write one and then slap it onto my service project.

I wrote this in C# running on .NET 6 due to my familiarity with the language, I was debating a SQL based implementation but I thought that might be a bit esoteric.

## Room for improvement
This implementation can handle some simpler edge cases but I'm sure there's more I'm missing, the unit tests also could be better. I feel like I could have done a better job decoupling my components as well, the parser feels like it's doing too much.

## Running the project
To run in visual studio, clone the repo and set RPN.CommandLine.UI project as your startup project, alternatively you can clone the .NET CLI and run "dotnet run --project RPN.CommandLine.UI" in the rpn_calculator solution folder. 

**Note: .NET 6 is required to run the project.**
