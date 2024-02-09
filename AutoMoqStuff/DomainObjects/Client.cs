namespace AutoMoqStuff.DomainObjects;

public record Client(Guid Id, 
    string FirstName,
    string LastName,
    int HouseNumber,
    IEnumerable<Car> Cars);