namespace Domain.Users.Exceptions;

public sealed class EmailLengthIsInvalidException() 
    : System.Exception($"The email length must be less than {Email.MaximumLength}");
