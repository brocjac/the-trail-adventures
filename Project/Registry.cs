// Project/Registry.cs
public class Registry
{
    private readonly List<Trail> _trail = new List<Trail>();

    // TODO — Task 1. Say what your project is about, in words.
    public static string Topic => "The Records of all my Adventures";     // ← yours

    public Trail NewItem(string name)
    {
        return new Trail(name);
    }

    public Trail NewItem(string name, string location, string surface, double totalLengthMiles, string activity, string notes) => 
    new Trail(name, location, surface, totalLengthMiles, activity, notes);

    public void Add(Trail item)
    {
        _trail.Add(item);
    }

    public int Count => _trail.Count;

    public List<Trail> All()
    {
        // TODO — Task 5. Hand back a COPY, never the list itself.
        return new List<Trail>(_trail);                                   // ← yours
    }

    public Trail? Find(string name)
    {
        foreach (Trail trail in _trail)
        {
            if (trail.Name == name)
            {
                return trail;
            }
        }
        return null;
    }

    public bool Remove(string name)
    {
        Trail? found = Find(name);

        if (found == null)
        {
            return false;
        }
        
        _trail.Remove(found);
        return true;
    }
}