using MediatR;
using Microsoft.AspNetCore.Mvc;
using TalentNode.Application.command;
using TalentNode.Domain.Models;

namespace TalentNodeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController(ISender sender) : ControllerBase
    {
        [HttpPost("SaveBooking")]
        public async Task<int> Booking(BookingModel booking)
        {
            var result = await sender.Send(new BookingCommand(booking));
            return result;
        }
    }
}
