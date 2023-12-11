public class Program
{
    // This application illustrates generic delegate namely Func, Action and Predicate

    /*
     *  Func is a generic delegate type in C# that represents a function that takes input parameters and returns a value
     * The basic form of Func delegate is: delegate TResult Func<in T, out TResult> Name(T argument)
     * The in keyword is followed by generic type T which represents the input to the Func
     * The out TResult represent the output of the delegate and the T argument represents the delegate parameter
     * Func delegate always return a value TResult
     */

    /*
     * Action is a generic delegate that does not return a value delegate void <in T>Name(T obj)
     * Predicate is a generic delegate that returns a boolean value delegate void <in T>Name(T obj)
     */

    // Func definition already available in system namespace here it is just a clarification
    delegate TResult Func<in T1, in T2, out TResult>(T1 a, T2 b);

    public static void Main(string[] args)
    {
        Program program = new Program();
        // Define the generic Func delegate and pass the reference method
        // Note the params here: first two int parameters are in, while the last one is out
        Func<int, int, int> calcSum = program.Sum;
        // Use the generic Func delegate
        Console.WriteLine(calcSum(1, 2));

        // Same example using lambda expression
        Func<int, int, int> calcSumLambda = (int a, int b) => { return a + b; };
        Console.WriteLine(calcSumLambda(2, 4));
        
        // Action generic delegate example 
        // Note that Action delegate must not return (void) 
        Action<int, string, string> EmployeeDetails = (int id, string firstName, string lastName) =>
        {
            Console.WriteLine($"Id: {id}, First Name: {firstName}, Last Name: {lastName}");
        };
        EmployeeDetails(1, "Mohammed", "Ahmed");
        
        // Predicate generic delegate example 
        // Note that Action delegate must return a boolean
        Predicate<string> predicate = (text) =>
        {
            return text.Length > 0;
        };
        
        Console.WriteLine(predicate("Some text"));
    }

    public int Sum(int a, int b)
    {
        return a + b;
    }
}