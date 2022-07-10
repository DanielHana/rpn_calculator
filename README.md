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
This could have easily been written in a single file, but I decided to split it up into a project for parsing/evaluation and a project for the CLI UI, with the bulk of the work being handled by the service project it will be easier to connect different user interfaces. The service classes intentionally do not print anything to the console, instead I opted for them to return strings to be handled by the UI, making it easier to apply separate UI's and also helping decouple the project.

I wrote this in C# running on .NET 6 due to my familiarity with the language, I was debating a SQL based implementation but I thought that might be a bit esoteric. My understanding of SQL is better than my understanding of C#, but C# is a much better tool for this job.

## Room for improvement
This implementation can handle some simpler edge cases but I'm sure there's more I'm missing, the unit tests also could be better. I feel like I could have done a better job decoupling my components as well, the parser feels like it's doing too much. Right now the parser is also sanitizing user input, if I had more time to work on this I'd probably create a separate class for sanitization.

## Running the project
To run in visual studio, clone the repo, set RPN.CommandLine.UI project as your startup project, and hit the run button 

![image](https://user-images.githubusercontent.com/45577253/178158865-82183504-643f-4865-8845-721594ba8f52.png)

You can also press F5 in Visual Studio, or select Start Debugging in the debug tab.

![image](https://user-images.githubusercontent.com/45577253/178158891-d92548a8-c592-4112-afad-a35291c5bb6c.png)

Alternatively you can clone the .NET CLI and run the following in a terminal in the rpn_calculator solution folder:

`dotnet run --project RPN.CommandLine.UI`

![image](https://user-images.githubusercontent.com/45577253/178158916-98dabda3-6b0e-497a-aed6-708b4fa5effb.png)

You can also run RPN.CommandLine.UI executable in the build folder located in the root directory of the repository

**Note: .NET 6 is required to run the project.**
