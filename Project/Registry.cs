// Project/Registry.cs
public class Registry
{
    private readonly List<Trails> _trails = new List<Trails>();

    // TODO — Task 1. Say what your project is about, in words.
    public static string Topic => "The Records of all my Adventures";     // ← yours

    public Trails NewItem(string name) => new Trails(name);

    public void Add(Trails item)
    {
        _trails.Add(item);
    }

    public int Count => _trails.Count;

    public List<Trails> All()
    {
        // TODO — Task 5. Hand back a COPY, never the list itself.
        return _trails;                                   // ← yours
    }
}