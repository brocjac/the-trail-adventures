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

// Week 7's rule, visible: Add called twice with the same name, and the
// second one refused. The count is the only thing that tells you.
registry.Add(registry.NewItem("Ice Age Trail"));
Console.WriteLine($"Tried to register \"Ice Age Trail\" twice - {registry.Count} on file.");

string registryFile = "registry.json";

registry.Save(registryFile);
Console.WriteLine($"{registry.Count} on file, saved to {registryFile}.");

registry.Load(registryFile);

Console.WriteLine();
Console.Write("Search (a word, or Enter to skip): ");
string? term = Console.ReadLine();

if (!string.IsNullOrWhiteSpace(term))
{
    var found = registry.Matching(term.Trim());

    Console.WriteLine(found.Count == 0
        ? $"  Nothing on file with \"{term.Trim()}\" in it."
        : $"  {found.Count} on file with \"{term.Trim()}\" in it.");
}

Console.WriteLine();
Console.WriteLine($"On the books, as they arrived: {string.Join(", ", registry.Names())}");

Console.WriteLine();
Console.WriteLine("In order:");

foreach (var record in registry.Sorted())
{
    Console.WriteLine($"  {record.Name}");
}