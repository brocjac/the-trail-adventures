using System.Runtime.CompilerServices;

public class Trails
{
    public int TimesVisited { get; private set; }
    public string Notes { get; set; }

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

    private decimal _totalLengthMiles = 0;
    public decimal TotalLengthMiles
    {
        get {return _totalLengthMiles;}
        set
        {
           if (!decimal.IsNegative(value))
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

    public Trails(string name)
    {
        Name = name;
        Location = "";
        Surface = "";
        TotalLengthMiles = 0;
        Activity = "";
        Notes = "";
    }
}