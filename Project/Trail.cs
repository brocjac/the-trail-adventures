using System.Runtime.CompilerServices;

public class Trail
{
    public int TimesVisited { get; private set; }
    public string Notes { get; set; } = "";

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

    private string _surface = "(unnamed)";
    public string Surface
    {
        get {return _surface;}
        set
        {
           if (!string.IsNullOrWhiteSpace(value))
            {
                _surface = value.Trim();
            } 
        }
    }

    private double _totalLengthMiles = 0;
    public double TotalLengthMiles
    {
        get {return _totalLengthMiles;}
        set
        {
           if (!double.IsNegative(value))
            {
                _totalLengthMiles = value;
            } 
        }
    }

    private string _activity = "";
    public string Activity
    {
        get {return _activity;}
        set
        {
           if (!string.IsNullOrWhiteSpace(value))
            {
                _activity = value.Trim();
            } 
        }
    }

    public Trail(string name)
    {
        Name = name;
    }

    public Trail(string name, string location, string surface, double totalLengthMiles, string activity, string notes)
    {
        Name = name;
        Location = location;
        Surface = surface;
        TotalLengthMiles = totalLengthMiles;
        Activity = activity;
        Notes = notes;
    }
}