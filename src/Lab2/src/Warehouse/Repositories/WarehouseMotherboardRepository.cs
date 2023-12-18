using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.ComponentExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Warehouse.Repositories;

public class WarehouseMotherboardRepository : Warehouse<MotherBoard>
{
    public override MotherBoard TopByPrice()
    {
        MotherBoard? topItem = Stocks().MaxBy(item => item.Price.PriceAmount);

        if (topItem != null)
        {
            return topItem;
        }

        throw new ComponentIsNotFoundException();
    }

    public override MotherBoard CheapestOne()
    {
        MotherBoard? topItem = Stocks().MinBy(item => item.Price.PriceAmount);

        if (topItem != null)
        {
            return topItem;
        }

        throw new ComponentIsNotFoundException();
    }

    public override MotherBoard BestOne(Func<MotherBoard, bool> condition)
    {
        MotherBoard? bestItem = Stocks().Where(condition).MinBy(item => item.Price.PriceAmount);

        if (bestItem != null)
        {
            return bestItem;
        }

        throw new ComponentIsNotFoundException();
    }
}