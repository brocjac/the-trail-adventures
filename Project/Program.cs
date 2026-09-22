var registry = new Registry();

registry.Add(new Trail("Glacial Drumlin Trail", "Waukesha, WI", "Asphalt", 5.0, "Jogging", "The weather was great with good dry conditions"));
registry.Add(new Trail("Minooka", "Waukesha, WI", "Dirt", 5.0, "Jogging", "The weather was great with good dry conditions"));
registry.Add(new Trail("Lake Schrummy", "Waukesha, WI", "Dirt", 5.0, "Jogging", "The weather was great with good dry conditions"));


Console.WriteLine(Registry.Topic);
Console.WriteLine($"{registry.Count} trials on file.");

Console.WriteLine();

foreach (Trail trail in registry.All())
{
    Console.WriteLine($"{trail.Name} - {trail.Location}");
}

Console.WriteLine();

// One I know is on the registry.
Trail? known = registry.Find("Minooka");

// One I know something about.
Console.WriteLine(known == null ? "Nothing on file by that name." : "Found it.");

Console.WriteLine();

// And one nobody has ever heard of.
Trail? missing = registry.Find("something I never added");
Console.WriteLine(missing == null ? "Nothing on file by that name." : "...found something that shouldn't be there.");

Console.WriteLine();
Console.WriteLine(registry.Remove("Minooka")
    ? "Removed."
    : "Nothing by that name.");

Console.WriteLine();
foreach (Trail item in registry.All())
{
    Console.WriteLine(item.Name);
}

Console.WriteLine($"{registry.Count} on file.");