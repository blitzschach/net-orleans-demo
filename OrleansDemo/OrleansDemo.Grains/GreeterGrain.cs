namespace OrleansDemo.Grains;

public class GreeterGrain : Grain, IGreeterGrain
{
    public GreeterGrain()
    {
        Console.WriteLine($"Created {nameof(GreeterGrain)} with Id '{this.GetPrimaryKey()}'");
    }

    public Task Greet(Person person)
    {
        Console.WriteLine($"{this.GetPrimaryKey()}: Hello {person.Firstname} {person.Lastname}!");
        
        return Task.CompletedTask;
    }
}