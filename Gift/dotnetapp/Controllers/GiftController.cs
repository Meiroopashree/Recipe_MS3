using Microsoft.AspNetCore.Mvc;
using dotnetapp.Models;
using dotnetapp.Services;
using Microsoft.Extensions.Configuration;


namespace dotnetapp.Controllers
{
    [ApiController]
    [Route("api/gift")]  // Assuming you want the endpoint to be "api/gift"
    public class GiftController : ControllerBase
    {
        private readonly GiftService _giftService;

        public GiftController(GiftService giftService)
        {
            _giftService = giftService;
        }

        [HttpPost]
        public IActionResult addGift([FromBody] Gift gift)
        {
            var addedGift = _giftService.addGift(gift);

            return CreatedAtAction(nameof(viewAllGifts), new { id = addedGift.GiftId }, addedGift);
        }

        [HttpGet]
        public IActionResult viewAllGifts()
        {
            var gifts = _giftService.viewAllGifts();

            return Ok(gifts);
                var jsonOptions = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.Preserve,
            // You can add other options as needed...
        };

        var json = JsonSerializer.Serialize(cart, jsonOptions);
        return Ok(json);
        }
        }

        [HttpPut("{id}")]
        public IActionResult updateGift(long id, [FromBody] Gift updatedGift)
        {
            var editedGift = _giftService.updateGift(id, updatedGift);

            if (editedGift != null)
            {
                return Ok(editedGift);
            }

            return NotFound(new { Message = "Gift not found." });
        }

        [HttpDelete("{id}")]
        public IActionResult deleteGift(long id)
        {
            var deletedGift = _giftService.deleteGift(id);

            if (deletedGift != null)
            {
                return Ok(deletedGift);
            }

            return NotFound(new { Message = "Gift not found." });
        }
    }
}