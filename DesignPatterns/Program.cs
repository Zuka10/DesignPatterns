using DesignPatterns.CircuitBreaker;
using DesignPatterns.Facade;
using DesignPatterns.Factory;

//Facade Pattern
ComputerFacade computerFacade = new ComputerFacade();
computerFacade.StartComputer();

////Factory Pattern
CarFactory carFactory = new CarFactory();
carFactory.CreateCar("bmw");

//Circuit Breaker Pattern
CircuitBreaker circuitBreaker = new(failureThreshold: 3, resetTimeout: 5000);

for (int i = 0; i < 5; i++)
{
    circuitBreaker.ExecuteAction(() =>
    {
        if (i < 3)
        {
            throw new Exception("Service failure");
        }

        Console.WriteLine("Service call succeeded.");
    });

    Console.WriteLine($"Circuit Breaker State: {circuitBreaker.State}");
}