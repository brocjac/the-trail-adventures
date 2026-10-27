using System.Text.Json;

public class Registry : IListed
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
        if (Find(item.Name) != null)
        {
            return;
        }
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
        return _trail.FirstOrDefault(item => item.Name == name);
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
    public string Kind => "REGISTRY";

    public string Line() => $"{Topic} - {Count} on file";

    public List<IListed> Everything()
    {
        List<IListed> listing = new List<IListed>();

        listing.Add(this);

        foreach (Trail item in _trail)
        {
            listing.Add(item);
        }

        return listing;
    }

    public void Save(string path)
    {
        string json = JsonSerializer.Serialize(_trail, new JsonSerializerOptions {WriteIndented = true});
        File.WriteAllText(path,json);
    }

    public void Load(string path)
    {
        if (!File.Exists(path))
        {
            return;
        }

        List<Trail>? loaded = JsonSerializer.Deserialize<List<Trail>>(File.ReadAllText(path));

        if (loaded == null)
        {
            return;
        }

        _trail.Clear();

        foreach (Trail item in loaded)
        {
            _trail.Add(item);
            _trail.Clear();
            _trail.AddRange(loaded);
        }
    }

    public List<Trail> Matching(string term)
    {
        return _trail.Where(item => item.Name.Contains(term)).ToList();
    }

    public List<string> Names()
    {
        return _trail.Select(item => item.Name).ToList();
    }

    public List<Trail> Sorted()
    {
        return _trail.OrderBy(item => item.Name).ToList();
    }
}