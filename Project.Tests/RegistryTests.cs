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

        registry.Add(registry.NewItem("A fresh Registry"));
        registry.Add(registry.NewItem("Add two records, with two DIFFERENT names"));

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
}