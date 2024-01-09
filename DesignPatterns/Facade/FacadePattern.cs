namespace DesignPatterns.Facade;

public class CPU
{
    public void Start()
    {
        Console.WriteLine("CPU is starting...");
    }
}

public class Memory
{
    public void Load()
    {
        Console.WriteLine("Memory is loading data");
    }
}

public class HardDrive
{
    public void Read()
    {
        Console.WriteLine("Hard Drive is reading data");
    }
}

public class ComputerFacade
{
    private CPU _cpu;
    private Memory _memory;
    private HardDrive _drive;

    public ComputerFacade()
    {
        _cpu = new CPU();
        _memory = new Memory();
        _drive = new HardDrive();
    }

    public void StartComputer()
    {
        Console.WriteLine("Starting the computer");
        _cpu.Start();
        _memory.Load();
        _drive.Read();
    }
}