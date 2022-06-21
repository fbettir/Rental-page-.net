using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RentalPage.Bll.Dtos;
using RentalPage.Bll.Interfaces;
using RentalPage.Dal.Models;

namespace RentalPage.Api.Controllers
{
    [Route("rentItem")]
    [ApiController]
    public class RentalPageController : ControllerBase
    {
        private readonly IRentItemService _rentItemService;

        public RentalPageController(IRentItemService rentItemService)
        {
            _rentItemService = rentItemService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RentItemDto>> Get(int id)
        {
            return await _rentItemService.GetRentItemAsync(id);
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<RentItemDto>>> Get()
        {
            //var ret = new List<RentItemDto>();
            //ret.Add(new RentItemDto { Available = true });

            //return ret;
            return (await _rentItemService.GetRentItemsAsync()).ToList();
        }



        /// <summary>
        /// Creates a new product
        /// </summary>
        /// <param name="product">The product to create</param>
        /// <returns>Returns the product inserted</returns>
        /// <response code="201">Insert successful</response>

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<RentItemDto>> Post([FromBody] RentItemDto rentItem)
        {
            var created = await _rentItemService.InsertRentItemAsync(rentItem);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        // PUT api/<RentItemController>/5
        [HttpPut("update/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Put(int id, [FromBody] RentItemDto value)
        {
            await _rentItemService.UpdateRentItemAsync(value, id);
            return NoContent();
        }

        // DELETE api/<RentItemController>/5
        [HttpDelete("{id}/delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Delete(int id)
        {
            await _rentItemService.DeleteRentItemAsync(id);
            return NoContent();
        }

        [HttpDelete("/deleteAll")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Delete()
        {
            await _rentItemService.DeleteRentItemsAsync();

            return NoContent();
        }
    }
}
