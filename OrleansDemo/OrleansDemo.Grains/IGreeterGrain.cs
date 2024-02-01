namespace OrleansDemo.Grains;

public interface IGreeterGrain : IGrainWithGuidKey
{
    Task Greet(Person person);
}

[GenerateSerializer]
public class Person
{
    [Id(0)]
    public string? Firstname { get; set; }
    
    [Id(1)]
    public string? Lastname { get; set; }
}