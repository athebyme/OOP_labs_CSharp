using Atm.Users;

namespace Atm.Chains;

public class ScenarioHandlerChain
{
    private readonly List<IScenarioHandler> _handlers;

    public ScenarioHandlerChain(IEnumerable<IScenarioHandler> handlers)
    {
        _handlers = handlers.ToList();
    }

    public async Task<bool> HandleAsync(UserRole role)
    {
        foreach (IScenarioHandler handler in _handlers)
        {
            if (await handler.HandleAsync(role).ConfigureAwait(false))
            {
                return true;
            }
        }

        return false;
    }
}