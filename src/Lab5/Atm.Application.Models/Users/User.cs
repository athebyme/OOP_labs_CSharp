using Atm.Bills;

namespace Atm.Users;

public record User(int Id, string Username, string HashPassword, string Salt, UserRole Role, Bill Bill);