using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.PowerSupply;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.ComponentExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Warehouse.Repositories;

public class WarehousePowerSupplyRepository : Warehouse<PowerSupply>
{
    public override PowerSupply TopByPrice()
    {
        PowerSupply? topItem = Stocks().MaxBy(item => item.Price.PriceAmount);

        if (topItem != null)
        {
            return topItem;
        }

        throw new ComponentIsNotFoundException();
    }

    public override PowerSupply CheapestOne()
    {
        PowerSupply? topItem = Stocks().MinBy(item => item.Price.PriceAmount);

        if (topItem != null)
        {
            return topItem;
        }

        throw new ComponentIsNotFoundException();
    }

    public override PowerSupply BestOne(Func<PowerSupply, bool> condition)
    {
        PowerSupply? bestItem = Stocks().Where(condition).MinBy(item => item.Price.PriceAmount);

        if (bestItem != null)
        {
            return bestItem;
        }

        throw new ComponentIsNotFoundException();
    }
}