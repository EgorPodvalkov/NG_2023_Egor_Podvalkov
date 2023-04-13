namespace Task1;

public class UI
{
    private Calculator _calculator = new Calculator();

    public UI()
    {
        _calculator.Log += Console.WriteLine;
    }

    public void Run()
    {
        // Clearing
        Console.Clear();

        try
        {
            // Getting Arguments
            var num1 = GetNumberFromConsole("Enter First Number: ");
            var operation = GetOperationFromConsole();
            var num2 = GetNumberFromConsole("Enter Second Number: ");
            Console.WriteLine();

            // Calculating
            _calculator.Calculate(num1, num2, operation);
        }
        catch
        { 
            // Bad Input
            Console.WriteLine($"Bad Input :(");
        }

        // Waiting User
        Console.ReadLine();
    }

    private float GetNumberFromConsole(string message = "Enter Number: ")
    {
        // Asking Number
        Console.Write(message);

        // Getting Number
        return float.Parse(Console.ReadLine());
    }

    private Calculator.Operation GetOperationFromConsole(string message = "Enter Operation: ")
    {
        // Asking Operation
        Console.Write(message);

        // Getting User Response
        var input = Console.ReadLine().ToLower();

        switch (input)
        {
            // Getting Operation Add
            case string response when response == "+" || response == "sum" || response == "add" || response == "addition":
                return Calculator.Add;

            // Getting Operation Sub
            case string response when response == "-" || response == "sub" || response == "subtract" || response == "subtraction":
                return Calculator.Sub;

            // Getting Operation Mul
            case string response when response == "*" || response == "mul" || response == "times" || response == "multiply":
                return Calculator.Mul;

            // Getting Operation Div
            case string response when response == "/" || response == "div" || response == "division" || response == "divide":
                return Calculator.Div;

            // if Bad Operation
            default:
                throw new Exception("Bad Operation :(");
        }
    }
}
