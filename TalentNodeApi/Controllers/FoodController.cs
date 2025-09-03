using Microsoft.AspNetCore.Mvc;
using TalentNode.Application.command;
using TalentNode.Domain.Models;
using MediatR;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TalentNodeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController(ISender sender) : ControllerBase
    {
        // GET: api/<FoodController>
        [HttpGet("GetAllFoodData")]
        public async Task<List<FoodData>> AuthenticateUser()
        {
            var result = await sender.Send(new GetAllFoodDataCommand());
            return result;
        }

        // GET api/<FoodController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FoodController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FoodController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FoodController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
