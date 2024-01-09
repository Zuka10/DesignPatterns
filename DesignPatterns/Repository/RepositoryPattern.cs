namespace DesignPatterns.Repository;

public interface IPersonRepository
{
    Person GetById(int id);
    void Add(Person person);
    void Update(Person person);
    void Remove(int id);
}

public class PersonRepository : IPersonRepository
{
    private readonly MyDbContext _dbContext;

    public PersonRepository(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Person GetById(int id)
    {
        return _dbContext.People.Find(id)!;
    }

    public void Add(Person person)
    {
        _dbContext.People.Add(person);
    }

    public void Update(Person person)
    {
        _dbContext.People.Update(person);
    }

    public void Remove(int id)
    {
        var person = _dbContext.People.Find(id);
        _dbContext.People.Remove(person);
    }

}

public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
}
