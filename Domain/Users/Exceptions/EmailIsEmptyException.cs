using Domain.Exceptions;

namespace Domain.Users.Exceptions;

public sealed class EmailIsEmptyException() 
    : DomainException("The email cannot be empty");
