using DelegateApplicationExample;
using DelegateApplicationExample.Views;

class Program
{
    /*
     * This application implements real-world delegate example for user membership authentication
     * It uses entity framework core and sqlite database
     */
    public static void Main(string[] args)
    {
        IView mainView = Factory.GetMainViewObject();
        mainView.RunView();

        Console.ReadKey();
    }
    
}