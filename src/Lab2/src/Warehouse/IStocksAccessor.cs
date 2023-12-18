using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Warehouse;

public interface IStocksAccessor<T>
{
    IReadOnlyCollection<T> Stocks();
}