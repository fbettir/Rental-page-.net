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

        /// <summary>
        /// Get all rented items.
        /// </summary>
        /// <returns>Returns all items you can rent</returns>
        /// <response code="200">Listing successful</response>
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<RentedItemDto>>> Get()
        {
            return (await rentedItemService.GetRentedItemsAsync()).ToList();
        }

        /// <summary>
        /// Get a specific rented item with the given identifier
        /// </summary>
        /// <param name="id">Product's identifier</param>
        /// <returns>Returns a specific product with the given identifier</returns>
        /// <response code="200">Listing successful</response>
        /// <response code="404">Rented item not found</response>
        /// <response code="400">Validation error</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<RentedItemDto>> Get(int id)
        {
            return await rentedItemService.GetRentedItemAsync(id);
        }

        /// <summary>
        /// Add a rented item in body (with user identifier, rent item identifier, start date, end date)
        /// </summary>
        /// <returns>Returns a specific product with the given identifier</returns>
        /// <response code="201">Creating successful</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="400">Validation error</response>
        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<RentedItemDto>> Post([FromBody] RentedItemDto rentedItem)
        {
            var created = await rentedItemService.InsertRentedItemAsync(rentedItem);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        /// <summary>
        /// Update a rented item with the given identifier, and values in body
        /// </summary>
        /// <param name="id">Product's identifier</param>
        /// <param name="rentedItem">######</param>
        /// <returns>Returns a specific product with the given identifier</returns>
        /// <response code="204">Update successful</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="409">Conflict</response>
        /// <response code="400">Validation error</response>
        [HttpPut("{id}/update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Put(int id, [FromBody] RentedItemDto rentedItem)
        {
            await rentedItemService.UpdateRentedItemAsync(rentedItem, id);
            return NoContent();
        }

        /// <summary>
        /// Delete a rented item with the given identifier
        /// </summary>
        /// <param name="id">Product's identifier</param>
        /// <returns>Returns a specific product with the given identifier</returns>
        /// <response code="204">Delete successful</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="404">Not found</response>
        /// <response code="400">Validation error</response>
        [HttpDelete("{id}/delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Delete(int id)
        {
            await rentedItemService.DeleteRentedItemAsync(id);
            return NoContent();
        }

        ///// <summary>
        ///// Delete a specific Item with the given identifier
        ///// </summary>
        ///// <param name="id">Product's identifier</param>
        ///// <returns>Returns a specific product with the given identifier</returns>
        ///// <response code="200">Listing successful</response>
        //[HttpDelete("deleteAll")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //public async Task<ActionResult> Delete()
        //{
        //    await rentedItemService.DeleteRentedItemsAsync();
        //    return NoContent();
        //}
    }
}
