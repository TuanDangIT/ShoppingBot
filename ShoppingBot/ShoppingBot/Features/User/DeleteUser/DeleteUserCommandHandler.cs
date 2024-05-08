using ShoppingBot.DAL.Repositories.Interfaces;
using ShoppingBot.Shared;
using ShoppingBot.Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.User.DeleteUser
{
    internal class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Result> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUser(request.Username);
            if(user is null)
            {
                return Result.Failure(UserErrors.NotFound);
            }
            var change = await _userRepository.DeleteUser(user);
            if(change == 0)
            {
                return Result.Failure(UserErrors.NotDeleted);
            }
            return Result.Success();
        }
    }
}
