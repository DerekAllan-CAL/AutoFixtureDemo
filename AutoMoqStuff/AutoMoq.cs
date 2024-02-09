using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using AutoMoqStuff.Services;
using Moq;
using Xunit.Abstractions;

namespace AutoMoqStuff;

public class AutoMoq
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly IFixture _fixture;
    private Mock<IClientRepository> _mock = new();
    private MarketingService _sut;

    public AutoMoq(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        _sut = new MarketingService(_mock.Object);
    }

    [Theory]
    [AutoMoqInterfaces]
    public void AutoMoqInterfacesAttribute_WithBasicServiceThatRequiresInterface(MarketingService sut1, MarketingService sut2)
    {
        _testOutputHelper.WriteLine(sut1.ClientRepository.ToString());
        _testOutputHelper.WriteLine(sut2.ClientRepository.ToString());
        Assert.True(true);
    }
    
    [Theory]
    [AutoMoqInterfaces]
    public void AutoMoqInterfacesAttribute_WithFrozenDependency(
        [Frozen] Mock<IClientRepository> clientRepositoryMock,
        MarketingService sut1, 
        MarketingService sut2)
    {
        _testOutputHelper.WriteLine(clientRepositoryMock.ToString());
        _testOutputHelper.WriteLine(sut1.ClientRepository.ToString());
        _testOutputHelper.WriteLine(sut2.ClientRepository.ToString());
        Assert.True(true);
    }
    
    [Theory]
    [InlineAutoMoqData("string")]
    public void AutoMoqInterfacesAttribute_WithInlineData(string s,
        [Frozen] Mock<IClientRepository> clientRepositoryMock,
        MarketingService sut1, 
        MarketingService sut2)
    {
        _testOutputHelper.WriteLine(clientRepositoryMock.ToString());
        _testOutputHelper.WriteLine(sut1.ClientRepository.ToString());
        _testOutputHelper.WriteLine(sut2.ClientRepository.ToString());
        Assert.True(true);
        Assert.Equal("string", s);
    }
}