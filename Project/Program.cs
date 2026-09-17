var registry = new Registry();

registry.Add(new Trails("Glacial Drumlin Trail", "Waukesha, WI", "Asphalt", 5.0, "Jogging", "The weather was great with good dry conditions"));
registry.Add(new Trails("Glacial Drumlin Trail", "Waukesha, WI", "Asphalt", 5.0, "Jogging", "The weather was great with good dry conditions"));


Console.WriteLine(Registry.Topic);
Console.WriteLine($"{registry.Count} on file.");
Console.WriteLine();

foreach (Trails item in registry.All())
{
    Console.WriteLine(item.Name);
}

List<Trails> both = registry.All();
Console.WriteLine($"before:  {both[0].TimesVisited}   {both[1].TimesVisited}");
both[0].Visit();
Console.WriteLine($"after:   {both[0].TimesVisited}   {both[1].TimesVisited}");