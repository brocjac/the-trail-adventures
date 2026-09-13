using System.Runtime.CompilerServices;

public class Trails
{
    public string Surface { get; set; }
    public decimal TotalLengthMiles { get; set; }
    public string Activity { get; set; }
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