using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ellis.Rate.Data;
using Ellis.Rate.Mappers;
using Ellis.Rate.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ellis.Rate.Mappers
{
}

namespace Ellis.Rate.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/json"), Produces("application/json")]
    public class RateController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly RateContext _rateContext;

        public RateController(ILogger<RateController> logger, RateContext rateContext)
        {
            _logger = logger;
            _rateContext = rateContext;
        }

        [HttpGet("", Name = "rating-get-all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<RatedItemViewModel>>> GetAllAsync()
        {
            var items = await _rateContext.RatedItems.ToListAsync();
            var vms = items.Select(RatedItemMapper.ToViewModel);
            return vms.ToList();
        }

        [HttpPost("", Name = "rating-create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<ActionResult<RatedItemViewModel>> PostAsync([FromBody]RatedItemBaseViewModel ratedItem)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity();

            var entity = RatedItemMapper.FromViewModel(ratedItem);

            _rateContext.Add(entity);
            await _rateContext.SaveChangesAsync();

            return RatedItemMapper.ToViewModel(entity);
        }

        [HttpPut("{id}", Name = "rating-update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<ActionResult<RatedItemViewModel>> PutAsync([FromRoute]int id, [FromBody]RatedItemBaseViewModel ratedItem)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity();

            var entity = await _rateContext.RatedItems.FindAsync(id);
            if (entity == null)
                return NotFound();

            RatedItemMapper.FromViewModel(ratedItem, entity);

            await _rateContext.SaveChangesAsync();

            return RatedItemMapper.ToViewModel(entity);
        }

        [HttpDelete("{id}", Name = "rating-delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<ActionResult> DeleteAsync([FromRoute]int id)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity();

            var entity = await _rateContext.RatedItems.FindAsync(id);
            if (entity == null)
                return NotFound();

            _rateContext.Remove(entity);

            await _rateContext.SaveChangesAsync();

            return Ok();
        }
    }
}
