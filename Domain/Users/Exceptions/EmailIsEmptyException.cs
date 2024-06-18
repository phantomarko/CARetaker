namespace Domain.Users.Exceptions;

public sealed class EmailIsEmptyException() 
    : System.Exception("The email cannot be empty");
