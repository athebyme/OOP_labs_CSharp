namespace Atm.Bills;

public interface IBillService
{
    Task WithdrawMoney(int withdrawingAmount);
    Task DepositMoney(int depositAmount);
}