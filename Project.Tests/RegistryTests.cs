using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Project.Migrations;

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
    public void Check3_FindHandsBackTheRecordItHolds()
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
    public void Check4_RemovingAStrangerSaysNo()
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

    [Fact]
    public void Check5_TheSameNameCannotRegisterTwice()
    {
        // Set the scene
        var registry = new Registry();

        // Do the thing
        registry.Add(registry.NewItem("Ice Age Trail"));
        registry.Add(registry.NewItem("Ice Age Trail"));

        // Check the answer
        Assert.Equal(1, registry.Count);
    }
    [Fact]
    public void Week8_TheRegistrySurvivesARestart()
    {
        DbContextOptions<ProjectContext> options = new DbContextOptionsBuilder<ProjectContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        
        Registry registry = new Registry();
        Trail item = registry.NewItem("Glacial Trails");
        registry.Add(item);
        item.Visit();

        registry.Save(new ProjectContext(options));

        Registry reopened = new Registry();
        reopened.Load(new ProjectContext(options));

        Assert.Equal(1, reopened.Count);
        Assert.Equal(1, reopened.All()[0].TimesVisited);
    }
    [Fact]
    public void Week9_FindComesBackEmptyHanded()
    {
        Registry registry = new Registry();
        Trail item = registry.NewItem("West Bend Ice Age");
        registry.Add(item);

        Assert.Same(item, registry.Find("West Bend Ice Age"));
        Assert.Null(registry.Find("Black Forest"));
    }

    [Fact]
    public void Week10_ASecondSaveChangesTheRow()
    {
        DbContextOptions<ProjectContext> options = new DbContextOptionsBuilder<ProjectContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        Registry registry = new Registry();
        registry.Add(registry.NewItem("Ice Age Trail"));
        registry.Save(new ProjectContext(options));

        ProjectContext db = new ProjectContext(options);
        Registry nextRun = new Registry();
        nextRun.Load(db);
        Trail item = nextRun.Find("Ice Age Trail")!;
        item.Visit();
        nextRun.Save(db);

        Registry reopened = new Registry();
        reopened.Load(new ProjectContext(options));

        Assert.Equal(1, reopened.Count);
        Assert.Equal(1, reopened.Find("Ice Age Trail")!.TimesVisited);
    }
    [Fact]
    public void Week11_ARemovedRecordStaysGone()
    {
        DbContextOptions<ProjectContext> options = new DbContextOptionsBuilder<ProjectContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        Registry registry = new Registry();
        Trail kept = registry.NewItem("Minooka");
        Trail removed = registry.NewItem("Drumlin Trail");
        registry.Add(kept);
        registry.Add(removed);
        registry.Save(new ProjectContext(options));

        ProjectContext db = new ProjectContext(options);
        Registry nextRun = new Registry();
        nextRun.Load(db);
        nextRun.Remove("Drumlin Trail");
        nextRun.Save(db);

        Registry reopened = new Registry();
        reopened.Load(new ProjectContext(options));

        Assert.Equal(1, reopened.Count);
        Assert.Null(reopened.Find("Drumlin Trail"));
    }
    [Fact]
    public void Week12_DetailsComeBack()
    {
        DbContextOptions<ProjectContext> options = new DbContextOptionsBuilder<ProjectContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        Registry registry = new Registry();
        Trail record = registry.NewItem("Trail America");
        record.Activities.Add(registry.NewDetail("Hiking"));
        record.Activities.Add(registry.NewDetail("Biking"));
        registry.Add(record);
        registry.Save(new ProjectContext(options));

        Registry reopened = new Registry();
        reopened.Load(new ProjectContext(options));

        Assert.Equal(2, reopened.Find("Trail America")!.Activities.Count);
    }
    [Fact]
    public void Week13_ABadFileAddsNothing()
    {
        string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".json");
        File.WriteAllText(path, """[ "Minooka", "" ]""");

        Registry registry = new Registry();

        Assert.Throws<InvalidDataException>(() => registry.Import(path));
        Assert.Equal(0, registry.Count);
    }
    [Fact]
    public void Week14_TheOldRecordsGetThreeStars()
    {
        Migration migration = new EveryRecordGetsStars();

        AddColumnOperation stars = migration.UpOperations
            .OfType<AddColumnOperation>()
            .Single(op => op.Name == "Stars");

        Assert.Equal(3, stars.DefaultValue);
    }
}