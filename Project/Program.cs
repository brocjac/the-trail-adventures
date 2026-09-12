var registry = new Registry();

registry.Add(new Trails("Glacial Drumlin Trail"));
registry.Add(new Trails("Waukesha, WI"));
registry.Add(new Trails("Asphalt"));
registry.Add(new Trails("5.0"));
registry.Add(new Trails("Jogging"));
registry.Add(new Trails("The weather was great with good dry conditions"));

Console.WriteLine(Registry.Topic);
Console.WriteLine($"{registry.Count} on file.");
Console.WriteLine();

foreach (Trails item in registry.All())
{
    Console.WriteLine(item.Name);
}