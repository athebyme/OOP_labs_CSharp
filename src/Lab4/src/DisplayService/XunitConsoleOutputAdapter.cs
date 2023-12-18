using Itmo.ObjectOrientedProgramming.Lab4.Exceptions.DisplayException;
using Itmo.ObjectOrientedProgramming.Lab4.LLogger.Observer;
using Xunit.Abstractions;

namespace Itmo.ObjectOrientedProgramming.Lab4.DisplayService;

public class XunitConsoleOutputAdapter : IDisplayDriver, IObserver
{
    private readonly ITestOutputHelper _xunitOutput;

    public XunitConsoleOutputAdapter(ITestOutputHelper xunitOutput)
    {
        _xunitOutput = xunitOutput ?? throw new NullXunitConsoleOutputException();
    }

    public virtual void Show(string text)
    {
        _xunitOutput.WriteLine(text);
    }

    public void Clear()
    {
    }

    public virtual void Update(string message)
    {
        _xunitOutput.WriteLine(message ?? throw new NullOutputTextException());
    }
}