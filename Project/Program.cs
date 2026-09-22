var registry = new Registry();

registry.Add(new Trails("Glacial Drumlin Trail", "Waukesha, WI", "Asphalt", 5.0, "Jogging", "The weather was great with good dry conditions"));
registry.Add(new Trails("Glacial Drumlin Trail", "Waukesha, WI", "Asphalt", 5.0, "Jogging", "The weather was great with good dry conditions"));


Console.WriteLine(Registry.Topic);
Console.WriteLine($"{registry.Count} on file.");

Console.WriteLine();

// One I know is on the registry.
Trails? known = registry.Find("Glacial Drumlin Trail");

// One I know something about.
if (known == null)
{
    Console.WriteLine("Nothing on file by that name.");
}
else
{
    known.Visit();
    Console.WriteLine($"{known.Name} - visited {known.TimesVisited}x");
}

Console.WriteLine(known == null ? "Nothing on file by that name." : "Found it.");

// And one nobody has ever heard of.
Trails? missing = registry.Find("something I never added");
Console.WriteLine(missing == null ? "Nothing on file by that name." : "...found something that shouldn't be there.");

Console.WriteLine();
Console.WriteLine(registry.Remove("the same name you searched for")
    ? "Removed."
    : "Nothing by that name.");

Console.WriteLine();
foreach (Trails item in registry.All())
{
    Console.WriteLine(item.Name);
}

Console.WriteLine($"{registry.Count} on file.");