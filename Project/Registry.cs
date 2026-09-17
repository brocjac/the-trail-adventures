// Project/Registry.cs
public class Registry
{
    private readonly List<Trails> _trails = new List<Trails>();

    // TODO — Task 1. Say what your project is about, in words.
    public static string Topic => "The Records of all my Adventures";     // ← yours

    public Trails NewItem(string name)
    {
        return new Trails(name);
    }

    public Trails NewItem(string name, string location, string surface, double totalLengthMiles, string activity, string notes) => 
    new Trails(name, location, surface, totalLengthMiles, activity, notes);

    public void Add(Trails item)
    {
        _trails.Add(item);
    }

    public int Count => _trails.Count;

    public List<Trails> All()
    {
        // TODO — Task 5. Hand back a COPY, never the list itself.
        return new List<Trails>(_trails);                                   // ← yours
    }
}