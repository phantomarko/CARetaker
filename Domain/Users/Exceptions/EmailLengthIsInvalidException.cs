using Domain.Exceptions;

namespace Domain.Users.Exceptions;

public sealed class EmailLengthIsInvalidException() 
    : DomainException($"The email length must be less than {Email.MaximumLength}");
