namespace Task1;

public class Calculator
{
    public delegate float Operation(float num1, float num2);
    public delegate void CalculateHandler(string text);
    public event CalculateHandler? Log;
    private Dictionary<Operation, string> _operationSymbol = new Dictionary<Operation, string>()
        {
            { Add, "+" },
            { Sub, "-" },
            { Mul, "*" },
            { Div, "/" }
        };

    public Calculator() { }

    public float Calculate(float num1, float num2, Operation operation)
    {
        var result = operation(num1, num2);

        // Examples: "1 + 2 = 3", "3 * 4 = 12"
        Log?.Invoke($"{num1} {_operationSymbol[operation]} {num2} = {result}");
        
        return result;
    }

    public static float Add(float num1, float num2) => num1 + num2;
    public static float Sub(float num1, float num2) => num1 - num2;
    public static float Mul(float num1, float num2) => num1 * num2;
    public static float Div(float num1, float num2) => num1 / num2;
}
