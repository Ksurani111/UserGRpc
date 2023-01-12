using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserGrpcService.Protos;
using Admin.API.Entities;
using Grpc.Net.Client;

namespace Admin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDataController : ControllerBase
    {
        private readonly GrpcChannel _channel;
        private readonly UserService.UserServiceClient _userServiceClient;
        private readonly IConfiguration _configuration;

        public UserDataController(IConfiguration configuration)
        {
            _configuration = configuration;
            _channel = GrpcChannel.ForAddress(_configuration.GetValue<string>("GrpcSettings:OfferServiceUrl"));
            _userServiceClient = new UserService.UserServiceClient(_channel);
        }

        [HttpGet("GetUserDetail")]
        public Task<UserDetail> GetUserDetail(string Id)
        {
            var request = new GetUserDetailRequest();
            request.Id = Id;

            var response = _userServiceClient.GetUser(request);
            return Task.FromResult(response);

        }


        [HttpGet("GetUsers")]
        public Task<Users> GetUserDetails()
        {
            var request = new Empty();

            var response = _userServiceClient.GetUserList(request);
            return Task.FromResult(response);

        }

        [HttpPost("CreateUser")]
        public async Task<UserDetail> CreateUser(UserDetails user)
        {
            var request = new UserDetail();
            request.City = user.City;
            request.UserName = user.UserName;
            request.Id = Guid.Empty.ToString();

            var userRequest = new CreateUserDetailRequest()
            {
                User = request
            };

            var response = await _userServiceClient.CreateUserAsync(userRequest);
            return response;

        }
    }
}
