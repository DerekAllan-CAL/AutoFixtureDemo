using AutoMoqStuff.DomainObjects;

namespace AutoMoqStuff.Services;

public class MarketingService(IClientRepository clientRepository) : IMarketing
{
    public IClientRepository ClientRepository => clientRepository;

    public void SendMarketingToClient(Client p)
    {
        
    }
}