namespace AutoMoqStuff.DomainObjects;

public class Car(string Make, int Year, string Registration)
{
    public override string ToString()
    {
        return $"Car - Make: {Make}, Year: {Year}, Registration: {Registration}";
    }
}