namespace Task1;

public class UI
{
    private Calculator _calculator = new Calculator();

    public UI(bool run = false)
    {
        _calculator.Log += Console.WriteLine;
        while(run)
            Run();
    }

    public void Run()
    {
        // Clearing
        Console.Clear();

        // Getting Arguments
        var num1 = GetNumberFromConsole("Enter First Number: ");
        var operation = GetOperationFromConsole();
        var num2 = GetNumberFromConsole("Enter Second Number: ");
        Console.WriteLine();
        
        // Calculating
        _calculator.Calculate(num1, num2, operation);

        // Waiting User
        Console.ReadLine();
    }

    private float GetNumberFromConsole(string message = "Enter Number: ")
    {
        // Asking Number
        Console.Write(message);
        float result;

        // Getting Number
        while (!float.TryParse(Console.ReadLine(), out result))
        {
            // Asking Number
            Console.WriteLine("Something Wrong :(, Try Again!");
            Console.Write(message);
        }
        
        return result;
    }

    private Calculator.Operation GetOperationFromConsole(string message = "Enter Operation: ")
    {
        Calculator.Operation? operation = null;

        while (operation == null)
        {
            // Asking Operation
            Console.Write(message);

            // Getting User Response
            var response = Console.ReadLine().ToLower();

            // Getting Operation Add
            if (response == "+" || response == "sum" || response == "add" || response == "addition")
                operation = Calculator.Add;

            // Getting Operation Sub
            else if (response == "-" || response == "sub" || response == "subtract" || response == "subtraction")
                operation = Calculator.Sub;

            // Getting Operation Mul
            else if (response == "*" || response == "mul" || response == "times" || response == "multiply")
                operation = Calculator.Mul;

            // Getting Operation Div
            else if (response == "/" || response == "div" || response == "division" || response == "divide")
                operation = Calculator.Div;

            // if Bad Operation
            else
                Console.WriteLine("Something Wrong :(, Try Again!");
        }

        return operation;
    }
}
