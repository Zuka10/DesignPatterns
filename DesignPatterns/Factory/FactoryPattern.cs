namespace DesignPatterns.Factory;

public abstract class Car
{
    public abstract void Assemble();
}

public class BMW : Car
{
    public override void Assemble()
    {
        Console.WriteLine("Assembling BMW Car.");
    }
}

public class Audi : Car
{
    public override void Assemble()
    {
        Console.WriteLine("Assembling Audi Car.");
    }
}

public class Mercedes : Car
{
    public override void Assemble()
    {
        Console.WriteLine("Assembling Mercedes Car.");
    }
}

public class CarFactory
{
    public Car CreateCar(string carType)
    {
        switch(carType.ToLower())
        {
            case "bmw":
                return new BMW();
            case "audi":
                return new Audi();
            case "mercedes":
                return new Mercedes();
            default:
                throw new ArgumentException($"Invalid car type: {carType}");
        }
    }
}
