using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.ComputerCase;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.ComponentExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Warehouse.Repositories;

public class WarehouseCaseRepository : Warehouse<ComputerCase>
{
    public override ComputerCase TopByPrice()
    {
        ComputerCase? topItem = Stocks().MaxBy(item => item.Price.PriceAmount);

        if (topItem != null)
        {
            return topItem;
        }

        throw new ComponentIsNotFoundException();
    }

    public override ComputerCase CheapestOne()
    {
        ComputerCase? cheapestItem = Stocks().MinBy(item => item.Price.PriceAmount);

        if (cheapestItem != null)
        {
            return cheapestItem;
        }

        throw new ComponentIsNotFoundException();
    }

    public override ComputerCase BestOne(Func<ComputerCase, bool> condition)
    {
        ComputerCase? bestItem = Stocks().Where(condition).MinBy(item => item.Price.PriceAmount);

        if (bestItem != null)
        {
            return bestItem;
        }

        throw new ComponentIsNotFoundException();
    }
}