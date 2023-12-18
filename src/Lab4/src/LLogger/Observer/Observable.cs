using System.Collections.Generic;
using System.Globalization;

namespace Itmo.ObjectOrientedProgramming.Lab4.LLogger.Observer;

public class Observable
{
    private readonly List<IObserver> _observers = new();

    public void AddObserver(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        _observers.Remove(observer);
    }

    protected void NotifyObservers(string format, params object[] args)
    {
        string message = string.Format(CultureInfo.CurrentCulture, format, args);

        foreach (IObserver observer in _observers)
        {
            observer.Update(message);
        }
    }
}