namespace Application.Abstractions.Messaging;

public interface ITransactionalCommand<TResponse> : ICommand<TResponse>;
