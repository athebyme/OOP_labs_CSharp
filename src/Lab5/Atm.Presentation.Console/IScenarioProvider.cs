using System.Diagnostics.CodeAnalysis;

namespace Atm;

public interface IScenarioProvider
{
    bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario);
}