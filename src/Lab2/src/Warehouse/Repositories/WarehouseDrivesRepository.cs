using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.StorageDevice;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.ComponentExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Warehouse.Repositories;

public class WarehouseDrivesRepository : Warehouse<InformationStorage>
{
    public override InformationStorage TopByPrice()
    {
        InformationStorage? topItem = Stocks().MaxBy(item => item.Price.PriceAmount);

        if (topItem != null)
        {
            return topItem;
        }

        throw new ComponentIsNotFoundException();
    }

    public override InformationStorage CheapestOne()
    {
        InformationStorage? topItem = Stocks().MinBy(item => item.Price.PriceAmount);

        if (topItem != null)
        {
            return topItem;
        }

        throw new ComponentIsNotFoundException();
    }

    public override InformationStorage BestOne(Func<InformationStorage, bool> condition)
    {
        InformationStorage? bestItem = Stocks().Where(condition).MinBy(item => item.Price.PriceAmount);

        if (bestItem != null)
        {
            return bestItem;
        }

        throw new ComponentIsNotFoundException();
    }
}