﻿using Itmo.Dev.Platform.Postgres.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Atm.Extensions;

public static class ServiceScopeExtensions
{
    public static async Task UseInfrastructureDataAccess(this IServiceScope scope)
    {
        await scope.UsePlatformMigrationsAsync(default).ConfigureAwait(false);
    }
}