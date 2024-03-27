namespace Domain.Users.Exceptions;

public sealed class EmailLengthIsInvalidException() 
    : Primitives.Exception($"The email length must be less than {Email.MaximumLength}");
