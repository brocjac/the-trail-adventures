public class Activity
{
    public int Id { get; set; }

    public int ActivityId { get; set; }

    public string Name { get; private set; }

    public Activity(string name)
    {
        Name = name;
    }
}