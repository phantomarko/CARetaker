namespace Domain.Users.Exceptions;

public sealed class EmailIsAlreadyInUseException() 
    : System.Exception("The email is already in use");
