using System.Reflection;

namespace Project.Tests;

public class RegistryTests
{
    [Fact]
    public void Check2_AddingGrowsTheCount()
    {
        // set the scene: a fresh Registry
        // do the thing:   Add two records, with two DIFFERENT names
        // check:          Assert.Equal — what should Count be?

        Registry registry = new Registry();

        registry.Add(registry.NewItem("Ice Age Trail"));
        registry.Add(registry.NewItem("Glacial Drumlin Trail"));

        Assert.Equal(2, registry.Count);
    }

    [Fact]
    public void Check2_FindHandsBackTheRecordItHolds()
    {
        // Set the scene
        var registry = new Registry();
        var depot = registry.NewItem("Depot");
        registry.Add(depot);

        // Do the thing
        var found = registry.Find("Depot");

        // Check the answer
        Assert.Same(depot, found);
    }

    [Fact]
    public void Check2_RemovingAStrangerSaysNo()
    {
        // Set the scene
        var registry = new Registry();
        var trail = registry.NewItem("Ice Age Trail");
        registry.Add(trail);

        // Do the thing
        var removed = registry.Remove("Trail That Does Not Exist");

        // Check the answer
        Assert.False(removed);
        Assert.Equal(1, registry.Count);
    }
}