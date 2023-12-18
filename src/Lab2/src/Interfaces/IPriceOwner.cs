using Itmo.ObjectOrientedProgramming.Lab2.Parameters.Price;

namespace Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

public interface IPriceOwner
{
    Price Price { get; }
}