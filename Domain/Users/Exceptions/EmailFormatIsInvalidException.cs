namespace Domain.Users.Exceptions;

public sealed class EmailFormatIsInvalidException() 
    : Primitives.Exception("The email is invalid");
