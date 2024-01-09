//Facade Pattern
using DesignPatterns.Facade;
using DesignPatterns.Factory;

ComputerFacade computerFacade = new ComputerFacade();
computerFacade.StartComputer();

//Factory Pattern
CarFactory carFactory = new CarFactory();
carFactory.CreateCar("bmw");