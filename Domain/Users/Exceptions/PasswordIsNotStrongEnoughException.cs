using Domain.Exceptions;

namespace Domain.Users.Exceptions;

public sealed class PasswordIsNotStrongEnoughException() 
    : DomainException(
        $"The password must have {Password.MinimumLength} characters at least, and it must include numbers and upper and lower case letters");
