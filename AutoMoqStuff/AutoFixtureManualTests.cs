using AutoFixture;
using AutoMoqStuff.DomainObjects;
using Xunit.Abstractions;

namespace AutoMoqStuff;

public class AutoFixtureManualTests
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly Fixture _fixture;

    public AutoFixtureManualTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        _fixture = new Fixture();
    }

    [Fact]
    public void UsingAutoFixtureInMethod()
    {
        var fixture = new Fixture();

        var client = fixture.Create<Client>();
        
        _testOutputHelper.WriteLine(client.FirstName);
        Assert.NotEmpty(client.FirstName);
    }
    
    [Fact]
    public void UsingAutoFixtureAsMemberVariable()
    {
        var client = _fixture.Create<Client>();
        
        _testOutputHelper.WriteLine(client.FirstName);
        Assert.NotEmpty(client.FirstName);
    }
    
    [Fact]
    public void UsingAutoFixtureFluentApi()
    {
        var fixture = new Fixture();

        var client = fixture.Build<Client>()
            .With(c => c.FirstName, "Derek")
            .With(c => c.LastName, "Allan")
            .Create();
        
        Assert.Equal("Derek", client.FirstName);
    }
    
}