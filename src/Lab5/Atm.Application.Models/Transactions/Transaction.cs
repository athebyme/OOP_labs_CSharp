namespace Atm.Transactions;

public record Transaction(int UserId, TransactionTypes TransactionType, int BillState, DateTime Date);