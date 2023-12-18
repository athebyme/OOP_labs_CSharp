using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.GraphicsProcessor;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.ComponentExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Warehouse.Repositories;

public class WarehouseGpuRepository : Warehouse<GraphicsProcessingUnit>
{
    public override GraphicsProcessingUnit TopByPrice()
    {
        GraphicsProcessingUnit? topItem = Stocks().MaxBy(item => item.Price.PriceAmount);

        if (topItem != null)
        {
            return topItem;
        }

        throw new ComponentIsNotFoundException();
    }

    public override GraphicsProcessingUnit CheapestOne()
    {
        GraphicsProcessingUnit? topItem = Stocks().MinBy(item => item.Price.PriceAmount);

        if (topItem != null)
        {
            return topItem;
        }

        throw new ComponentIsNotFoundException();
    }

    public override GraphicsProcessingUnit BestOne(Func<GraphicsProcessingUnit, bool> condition)
    {
        GraphicsProcessingUnit? bestItem = Stocks().Where(condition).MinBy(item => item.Price.PriceAmount);

        if (bestItem != null)
        {
            return bestItem;
        }

        throw new ComponentIsNotFoundException();
    }
}