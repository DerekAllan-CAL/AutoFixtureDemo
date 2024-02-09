using AutoMoqStuff.DomainObjects;

namespace AutoMoqStuff.Services;

public interface IClientRepository
{
    public Client GetClientByName(string firstName, string lastName);
}