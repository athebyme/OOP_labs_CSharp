using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Memory.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.ComponentExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Warehouse.Repositories;

public class WarehouseRamRepository : Warehouse<RamKit>
{
    public override RamKit TopByPrice()
    {
        RamKit? topItem = Stocks().MaxBy(item => item.Price.PriceAmount);

        if (topItem != null)
        {
            return topItem;
        }

        throw new ComponentIsNotFoundException();
    }

    public override RamKit CheapestOne()
    {
        RamKit? topItem = Stocks().MinBy(item => item.Price.PriceAmount);

        if (topItem != null)
        {
            return topItem;
        }

        throw new ComponentIsNotFoundException();
    }

    public override RamKit BestOne(Func<RamKit, bool> condition)
    {
        RamKit? bestItem = Stocks().Where(condition).MinBy(item => item.Price.PriceAmount);

        if (bestItem != null)
        {
            return bestItem;
        }

        throw new ComponentIsNotFoundException();
    }
}