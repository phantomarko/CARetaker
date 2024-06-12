using Domain.Primitives;

namespace Domain.Users.Exceptions;

public sealed class EmailIsAlreadyInUseException() 
    : DomainException("The email is already in use");
