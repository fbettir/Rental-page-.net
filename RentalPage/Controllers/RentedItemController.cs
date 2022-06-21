using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalPage.Bll.Dtos;
using RentalPage.Bll.Interfaces;
using RentalPage.Dal.Models;

namespace RentalPage.Api.Controllers
{
    [Route("rentedItems")]
    [ApiController]
    public class RentedItemController : ControllerBase
    {
        public readonly IRentedItemService rentedItemService;

        public RentedItemController(IRentedItemService rentedItemService)
        {
            this.rentedItemService = rentedItemService;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<RentedItemDto>>> Get()
        {
            return (await rentedItemService.GetRentedItemsAsync()).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RentedItemDto>> Get(int id)
        {
            return await rentedItemService.GetRentedItemAsync(id);
        }


        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<RentedItemDto>> Post([FromBody] RentedItemDto rentedItem)
        {
            var created = await rentedItemService.InsertRentedItemAsync(rentedItem);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }


        [HttpPut("{id}/update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Put(int id, [FromBody] RentedItemDto rentedItem)
        {
            await rentedItemService.UpdateRentedItemAsync(rentedItem, id);
            return NoContent();
        }


        [HttpDelete("{id}/delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Delete(int id)
        {
            await rentedItemService.DeleteRentedItemAsync(id);
            return NoContent();
        }

        [HttpDelete("deleteAll")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Delete()
        {
            await rentedItemService.DeleteRentedItemsAsync();
            return NoContent();
        }
    }
}
