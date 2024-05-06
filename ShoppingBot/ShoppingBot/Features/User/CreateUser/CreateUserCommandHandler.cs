using ShoppingBot.DAL.Repositories.Interfaces;
using ShoppingBot.Shared;
using ShoppingBot.Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.User.CreateUser
{
    internal class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Result> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var change = await _userRepository.CreateUser(new Entities.User()
            {
                Id = Guid.NewGuid(),
                Username = request.Username,
            });
            if(change == 0)
            {
                return Result.Failure(UserErrors.NotCreated);
            }
            return Result.Success();
        }
    }
}
