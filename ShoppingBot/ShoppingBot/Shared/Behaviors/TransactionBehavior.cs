using MediatR;
using Microsoft.EntityFrameworkCore;
using ShoppingBot.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Shared.Behaviors
{
    internal class TransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : Result
    {
        private readonly ShoppingBotDbContext _dbContext;

        public TransactionBehavior(ShoppingBotDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!typeof(TRequest).Name.EndsWith("Command"))
            {
                return await next();
            }

            await using var transaction = await _dbContext.Database.BeginTransactionAsync();

            try
            {

                var result = await next();
                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();
                return result;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
