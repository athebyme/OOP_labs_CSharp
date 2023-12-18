using Atm.Bills;
using Atm.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Atm.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IBillService, BillService>();
        collection.AddScoped<IUserService, UserService>();

        collection.AddScoped<CurrentUserManager>();
        collection.AddScoped<ICurrentUserService>(
            p => p.GetRequiredService<CurrentUserManager>());

        return collection;
    }
}