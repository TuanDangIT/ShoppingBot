using ShoppingBot.DAL.Repositories.Interfaces;
using ShoppingBot.Entities;
using ShoppingBot.Features.User.DTOs;
using ShoppingBot.Shared;
using ShoppingBot.Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBot.Features.User.GetUser
{
    internal class GetUserQueryHandler : IQueryHandler<GetUserQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;

        public GetUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<UserDto>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUser(request.Username);
            if (user is null)
            {
                return Result.Failure<UserDto>(UserErrors.NotFound);
            }
            return Result.Success(user.AsDto());
        }
    }
}
