namespace Domain.Users.Exceptions;

public sealed class EmailIsEmptyException() 
    : Primitives.Exception("The email cannot be empty");
