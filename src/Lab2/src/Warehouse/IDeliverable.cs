using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Warehouse;

public interface IDeliverable<in T>
{
    void CreateNewDelivery(IEnumerable<T> supplyList);
}