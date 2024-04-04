namespace Domain.Exceptions;

public sealed class MethodNotAllowedException()
    : DomainException("The method requested is not allowed");
