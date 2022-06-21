using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalPage.Bll.Dtos;
using RentalPage.Bll.Interfaces;
using System.Web.Http.Cors;

namespace RentalPage.Api.Controllers
{
    
    [Route("user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<UserDto>>> Get()
        {
            return (await userService.GetUsersAsync()).ToList();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> Get(int id)
        {
            return await userService.GetUserAsync(id);
        }


        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<UserDto>> Post([FromBody] UserDto user)
        {
            var created = await userService.InsertUserAsync(user);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }


        [HttpPut("{id}/update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Put(int id, [FromBody] UserDto user)
        {
            await userService.UpdateUserAsync(id, user);
            return NoContent();
        }


        [HttpDelete("{id}/delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Delete(int id)
        {
            await userService.DeleteUserAsync(id);
            return NoContent();
        }

        [HttpDelete("deleteAll")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Delete()
        {
            await userService.DeleteUsersAsync();
            return NoContent();
        }
    }
}
