using Atm.Repositories;
using Atm.Transactions;
using Atm.Users;

namespace Atm.Bills;

public class BillService : IBillService
{
    private readonly IBillRepository _repository;
    private readonly ITransactionRepository _transactionRepository;
    private readonly ICurrentUserService _userService;
    public BillService(IBillRepository repository, ICurrentUserService userService, ITransactionRepository transactionRepository)
    {
        _repository = repository;
        _userService = userService;
        _transactionRepository = transactionRepository;
    }

    public async Task WithdrawMoney(int withdrawingAmount)
    {
        int userId = _userService.User?.Id ?? -1;
        Bill? bill = await _repository.FindUserBillById(userId).ConfigureAwait(false);

        if (bill != null && bill.BillState >= withdrawingAmount)
        {
            int newBill = bill.BillState;
            newBill -= withdrawingAmount;
            await _repository.ChangeBillState(userId, newBill).ConfigureAwait(false);
            await _transactionRepository.AddTransaction(userId, TransactionTypes.Withdrawal, newBill, DateTime.Now)
                .ConfigureAwait(false);
        }
        else
        {
            throw new InvalidOperationException("Insufficient funds.");
        }
    }

    public async Task DepositMoney(int depositAmount)
    {
        int userId = _userService.User?.Id ?? -1;
        Bill? bill = await _repository.FindUserBillById(userId).ConfigureAwait(false);

        if (bill != null)
        {
            int newBill = bill.BillState;
            newBill += depositAmount;
            await _repository.ChangeBillState(userId, newBill).ConfigureAwait(false);
            await _transactionRepository.AddTransaction(userId, TransactionTypes.Withdrawal, newBill, DateTime.Now)
                .ConfigureAwait(false);
        }
        else
        {
            throw new InvalidOperationException("Insufficient funds.");
        }
    }
}