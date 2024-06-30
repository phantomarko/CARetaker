using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using MediatR;
using System.Transactions;

namespace Application.Behaviours;

public sealed class TransactionalPipelineBehaviour<TRequest, TResponse>(
    IUnitOfWork unitOfWork)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ITransactionalCommand<TResponse>
{
    public async Task<TResponse> Handle(
        TRequest request, 
        RequestHandlerDelegate<TResponse> next, 
        CancellationToken cancellationToken)
    {
        using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            var response = await next();

            await unitOfWork.SaveChangesAsync(cancellationToken);

            transactionScope.Complete();

            return response;
        }
    }
}
