using Microsoft.AspNetCore.Mvc;
using TalentNode.Application.command;
using TalentNode.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;


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
        [Authorize]
        [HttpPost("SaveData")]
        public async Task<int> SaveData(SaveFoodData saveFoodData)
        {
            var result = await sender.Send(new SaveFoodItemCommand(saveFoodData));
            return result;
        }
        [Authorize]
        [HttpPost("updateData")]
       
        public async Task<int> UpdateData(FoodData foodData)
        {
            var result = await sender.Send(new EditfoodmenuitemCommand(foodData));
            return result;
        }
        [Authorize]
        [HttpGet("Delete")]

        public async Task<int> UpdateData(int id)
        {
            var result = await sender.Send(new DeleteFoodItemCommand(id));
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
