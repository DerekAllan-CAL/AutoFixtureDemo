using AutoMoqStuff.DomainObjects;

namespace AutoMoqStuff.Services;

public interface IMarketing
{
    public IClientRepository ClientRepository { get; }
    public void SendMarketingToClient(Client p);
}