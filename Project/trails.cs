public class Trails
{
    public string Name;
    public string Location;
    public string Surface;
    public decimal TotalLengthMiles;
    public string Activity;
    public string Notes;

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