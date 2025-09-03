using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TalentNode.Application.command;
using TalentNode.Domain.Models;

namespace TalentNodeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthenticationController(ISender sender) : ControllerBase
    {
        [HttpPost("Authenticate")]
        public async Task<string> AuthenticateUser([FromBody] UserDetails employee)
        {
            var result = await sender.Send(new UserAuthenticationCommand(employee));
            return result;
        }
    }
}
