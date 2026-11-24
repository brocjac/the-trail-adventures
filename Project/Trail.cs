using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

public class Trail : IListed
{
    [JsonInclude]
    public int Id { get; set; }
    public int TimesVisited { get; private set; }

    public void Visit()
    {
        TimesVisited++;
    }

    private string _name = "(unnamed)";
    public string Name
    {
        get {return _name;}
        set
        {
           if (!string.IsNullOrWhiteSpace(value))
            {
                _name = value.Trim();
            } 
        }
    }

    private string _location = "";
    public string Location
    {
        get {return _location;}
        set
        {
           if (!string.IsNullOrWhiteSpace(value))
            {
                _location = value.Trim();
            } 
        }
    }

    public Trail()
    {
    }

    public Trail(string name)
    {
        Name = name;
    }

    public Trail(string name, string location)
    {
        Name = name;
        Location = location;
    }
    
    // inside SignOut, below Back()
    public string Kind => "TRAIL";

    public string Line() => $"{Name} - {Location} - Visited {TimesVisited}x";

    public List<Activity> Activities { get; set; } = new List<Activity>();
}