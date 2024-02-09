using AutoFixture.Xunit2;
using AutoMoqStuff.DomainObjects;
using AutoMoqStuff.Services;

namespace AutoMoqStuff;

public class AutoFixtureWithAttributes
{

    [Theory]
    [AutoData]
    public void AutoDataAttribute_ToInjectValues(int someExpectedNumber)
    {
        Assert.Equal(Math.Pow(someExpectedNumber, 2), someExpectedNumber * someExpectedNumber);
    }

    [Theory]
    [AutoData]
    public void AutoDataAttribute_ToInjectClassInstances(Client client)
    {
        Assert.NotEmpty(client.Cars);
        Assert.NotEmpty(client.FirstName);
    }
    
    [Theory, InlineAutoData(1,2,"string")]
    public void InlineAutoDataAttribute_WithClassInstance(int one, int two, string three, Client created)
    {
        Assert.Equal(1, one);
        Assert.Equal(2, two);
        Assert.NotEmpty(created.FirstName);
    }
    public static IEnumerable<object?[]> Data = [[1, "string"]];

    [Theory]
    [MemberAutoData(nameof(Data))]
    public void MemberAutoDataAttribute_WithClassInstance(int one, string two, Client client)
    {
        Assert.Equal(1, one);
        Assert.NotEmpty(two);
        Assert.NotEmpty(client.FirstName);
    }
    
    [Theory]
    [AutoData]
    public void AutoAttribute_WithoutMoqingFailsToCreateObjectWithDependancy(MarketingService sut)
    {
        Assert.True(true);
    }
}