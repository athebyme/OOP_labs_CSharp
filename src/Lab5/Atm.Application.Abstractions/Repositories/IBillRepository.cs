using Atm.Bills;

namespace Atm.Repositories;

public interface IBillRepository
{
    Task<Bill?> FindUserBillById(int userId);
    Task ChangeBillState(int userId, int amount);
}