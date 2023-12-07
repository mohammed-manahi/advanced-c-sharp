public class Program
{
    // Define a covariance delegate of type Car
    delegate Car CarFactoryDel(int id, string name);

    // Define a contravariance delegates
    delegate void LogICECarDetailsDel(ICECar iceCar);

    delegate void LogEVCarDetailsDel(EVCar evCar);

    public static void Main(string[] args)
    {
        #region CovarianceDelegate

        // This is a covariance delegate example
        // The delegate return type is car while the 'ReturnICECarDetails' return type is ICECar and 'ReturnEVCarDetails' return type is EVCar
        // Since these two methods are from child classes that inherit from Car base class, this implementation is allowed
        CarFactoryDel carFactoryDel = CarFactory.ReturnICECarDetails;
        CarFactoryDel carFactoryDel2 = CarFactory.ReturnEVCarDetails;

        Car iceCar = carFactoryDel(1, "ICE Car Model");
        // Console.WriteLine(iceCar.GetCarDetails());
        Car evCar = carFactoryDel2(2, "EV Car Model");
        // Console.WriteLine(evCar.GetCarDetails());

        #endregion

        #region ContravarianceDelegate

        // This is a covariance delegate example
        // The two  delegates define parameter of type ICECar and EVCar respectively yet the LogCarDetails' parameter is  car 
        // Since these two methods are from child classes that inherit from Car base class, this implementation is allowed
        LogICECarDetailsDel logICECarDetailsDel = new LogICECarDetailsDel(LogCarDetails);
        logICECarDetailsDel(iceCar as ICECar);
        LogEVCarDetailsDel logEvCarDetailsDel = new LogEVCarDetailsDel(LogCarDetails);
        logEvCarDetailsDel(evCar as EVCar);

        #endregion
    }

    public static void LogCarDetails(Car car)
    {
        if (car is ICECar)
        {
            Console.WriteLine(car.GetCarDetails());
        }
        else if (car is EVCar)
        {
            Console.WriteLine(car.GetCarDetails());
        }
        else
        {
            throw new ArgumentException();
        }
    }
}

public abstract class Car
{
    // Abstract car base class
    public int Id { get; set; }
    public string Name { get; set; }

    public virtual string GetCarDetails()
    {
        return $"Car ID: {Id} and Care Name: {Name}";
    }
}

public class ICECar : Car
{
    // Child class of car for car that uses internal combustion engine (ICE)
    public override string GetCarDetails()
    {
        return $"{base.GetCarDetails()} - internal combustion engine (ICE)";
    }
}

public class EVCar : Car
{
    // Child class of car for car that uses electric engine
    public override string GetCarDetails()
    {
        return $"{base.GetCarDetails()} - electric (EV)";
    }
}

public static class CarFactory
{
    public static ICECar ReturnICECarDetails(int id, string name)
    {
        return new ICECar() { Id = id, Name = name };
    }

    public static EVCar ReturnEVCarDetails(int id, string name)
    {
        return new EVCar() { Id = id, Name = name };
    }
}