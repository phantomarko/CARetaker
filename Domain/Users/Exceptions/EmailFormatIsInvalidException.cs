using Domain.Primitives;

namespace Domain.Users.Exceptions;

public sealed class EmailFormatIsInvalidException() 
    : DomainException("The email is invalid");
