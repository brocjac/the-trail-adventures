public class Activity
{
    public int Id { get; set; }
    public string Notes { get; set; } = "";
    public int ActivityId { get; set; }
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

    private string _type = "";
    public string Type
    {
        get {return _type;}
        set
        {
           if (!string.IsNullOrWhiteSpace(value))
            {
                _type = value.Trim();
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
    public Activity(string type)
    {
        Type = type;
    }
    public Activity(string type, string surface, double totalLengthMiles, string notes)
    {
        Type = type;
        Surface = surface;
        TotalLengthMiles = totalLengthMiles;
        Notes = notes;
    }
}