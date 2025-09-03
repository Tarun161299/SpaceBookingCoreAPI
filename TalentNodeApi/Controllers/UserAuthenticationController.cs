using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TalentNode.Application.command;
using TalentNode.Domain.Entities;
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
            var resCCult = await sender.Send(new UserAuthenticationCommand(employee));
            return System.Text.Json.JsonSerializer.Serialize( resCCult);
        }
    }
}
