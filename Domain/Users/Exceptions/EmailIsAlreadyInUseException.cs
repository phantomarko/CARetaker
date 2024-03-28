namespace Domain.Users.Exceptions;

public sealed class EmailIsAlreadyInUseException() 
    : Primitives.Exception("The email is already in use");
