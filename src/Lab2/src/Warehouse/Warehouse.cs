using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.ParamExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Warehouse;

public abstract class Warehouse<T> : IStocksAccessor<T>, IDeliverable<T>
{
    private readonly Collection<T> _stocks = new();

    public abstract T TopByPrice();
    public abstract T CheapestOne();
    public abstract T BestOne(Func<T, bool> condition);
    public IReadOnlyCollection<T> Stocks() => _stocks;

    public void AddProduct(T product)
    {
        if (product == null) throw new ParamNullException();
        _stocks.Add(product);
    }

    public void CreateNewDelivery(IEnumerable<T> supplyList)
    {
        if (supplyList == null) throw new ParamNullException();
        foreach (T product in supplyList)
        {
            _stocks.Add(product);
        }
    }
}