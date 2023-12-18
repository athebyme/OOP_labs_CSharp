using Itmo.ObjectOrientedProgramming.Lab3.Exceptions.DisplayExceptions;
using Xunit.Abstractions;

namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayService;

public class XunitConsoleOutputAdapter : IDisplayDriver
{
    private readonly ITestOutputHelper _xunitOutput;

    public XunitConsoleOutputAdapter(ITestOutputHelper xunitOutput)
    {
        _xunitOutput = xunitOutput ?? throw new NullXunitConsoleOutputException();
    }

    public void Show(string text)
    {
        _xunitOutput.WriteLine(text);
    }

    public void Clear()
    {
    }
}