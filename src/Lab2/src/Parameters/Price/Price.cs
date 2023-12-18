using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.ParamExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Parameters.Price;

public class Price
{
    public Price(int price)
    {
        if (price < 0) throw new ParamOutOfRangeException();
        PriceAmount = price;
    }

    public int PriceAmount { get; private set; }
}