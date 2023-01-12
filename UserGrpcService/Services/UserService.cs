using AutoMapper;
using Grpc.Core;
using System;
using System.Runtime.CompilerServices;
using UserGrpcService;
using UserGrpcService.Entities;
using UserGrpcService.Protos;
using UserGrpcService.Repositories;
using UserServices = UserGrpcService.Protos.UserService;
namespace UserGrpcService.Services
{
    public class UserService : UserServices.UserServiceBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserService(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async override Task<UserDetail> GetUser(GetUserDetailRequest request, ServerCallContext context)
        {
            var user = await _userService.GetUserByIdAsync(new Guid(request.Id));
            var userDetail = _mapper.Map<UserDetail>(user);
            return userDetail;
        }

        public async override Task<Users> GetUserList(Empty empty, ServerCallContext context)
        {
            try
            {
                var userData = await _userService.GetUserListAsync();

                Users users = new Users();
                foreach (UserDetails user in userData)
                {
                    if(user.DateOfBirth == null)
                    {
                        user.DateOfBirth = DateTime.Now;
                     }
                    users.Items.Add(_mapper.Map<UserDetail>(user));
                }

                return users;
            }
            catch (Exception ee)
            {
                throw;
            }

        }
        public async override Task<UserDetail> CreateUser(CreateUserDetailRequest request, ServerCallContext context)
        {
            var user = _mapper.Map<UserDetails>(request.User);
            await _userService.AddUserAsync(user);
            var userDetail = _mapper.Map<UserDetail>(user);
            return userDetail;
        }


    }
}
