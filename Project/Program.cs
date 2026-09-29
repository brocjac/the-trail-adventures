var registry = new Registry();

registry.Add(new Trail("Glacial Drumlin Trail", "Waukesha, WI", "Asphalt", 5.0, "Hike", "The weather was great with good dry conditions"));
registry.Add(new Trail("Glacial Drumlin Trail", "Waukesha, WI", "Trail", 5.0, "Jogging", "The weather was great with good dry conditions"));
registry.Add(new Trail("Minooka", "Waukesha, WI", "Dirt", 5.0, "Jogging", "The weather was great with good dry conditions"));
registry.Add(new Trail("Lake Schrummy", "Waukesha, WI", "Dirt", 5.0, "Jogging", "The weather was great with good dry conditions"));

foreach (Trail trail in registry.All())
{
    Console.WriteLine($"{trail.Name} - {trail.Location}");
}

Console.WriteLine();

// One I know something about. Find hands back the record the registry is
// holding, so the change lands on the real one.
Trail? known = registry.Find("Minooka");

if (known != null)
{
    known.Visit();
}

Console.WriteLine();

Console.Write("Take one off the books (Enter to skip): ");
string? name = Console.ReadLine();

Console.WriteLine();
if (!string.IsNullOrWhiteSpace(name))
{
    Console.WriteLine(registry.Remove(name) ? "Removed." : "Nothing by that name.");
}

Console.WriteLine();

// One loop. It knows about exactly one thing, and that thing is not a class.
foreach (IListed thing in registry.Everything())
{
    Console.WriteLine($"{thing.Kind,-12}{thing.Line()}");
}
Console.WriteLine();