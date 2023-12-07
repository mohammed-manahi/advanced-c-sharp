/*
 * A delegate is a type that represents references to methods with a particular parameter list and return type.
 * The delegate can be used with instance methods and static methods
 * The delegate can be in class scope or in namespace scope
 */
class Program
{
    // To define a delegate use 'delegate' keyword and return type of the reference method of the delegate
    // The method that can be referenced must have the same parameters and return type defined in the delegate definition
    // In this case the method must declare one single string parameter
    delegate void LogDelegate(string text);
    public static void Main(string[] args)
    {
        // Create a delegate object to pass the method reference 
        // Same applies to instance method just like static methods, only object initialization is required since these methods are instance methods
        // LogDelegate logDelegate = new LogDelegate(LogTextToScreen);
        // Pass the delegate parameter(s), in this case it is single string paramter
        // logDelegate("Hello Delegate");
        
        // Delegate multicast 
        LogDelegate logTextToScreenDelegate = new LogDelegate(LogTextToScreen);
        LogDelegate logTextToFileDelegate = new LogDelegate(LogTextToFile);
        LogDelegate multiCastDelegate = logTextToScreenDelegate + logTextToFileDelegate;
        // Simple multicast of delegate
        multiCastDelegate("A multi-cast for log text to screen and file");
        // Multicast delegate using a wrapper method
        LogDelegateWrapper(multiCastDelegate, "Another way of multicast using a wrapper method");

    }

    static void LogTextToScreen(string text)
    {
        // This method's return type and parameters must follow delegate's return type and parameters 
        Console.WriteLine($"{DateTime.Now} : {text}");
    }

    static void LogTextToFile(string text)
    {
        // Combines the path of bin/debug/.net with the name of the file
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "text.txt");
        using (StreamWriter streamWriter = new StreamWriter(path, true))
        {
            streamWriter.WriteLine($"{DateTime.Now}: {text}");
        }
    }

    static void LogDelegateWrapper(LogDelegate logDelegate, string text)
    {
        // A wrapper method that takes the delegate object and the delegate parameter for a multicast delegate
        logDelegate(text);
    }
}
