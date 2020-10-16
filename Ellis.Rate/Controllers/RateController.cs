using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ellis.Rate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateController : ControllerBase
    {
        private readonly ILogger _logger;

        public RateController(ILogger<RateController> logger)
        {
            _logger = logger;
        }

        [HttpGet("", Name = "rating-get-all")]
        public async Task<ActionResult<List<RatedItemViewModel>>> GetAllAsync()
        {
            return new List<RatedItemViewModel>()
            {
                new RatedItemViewModel() {Id = 1, Name = "Item 1", Rating = 1},
                new RatedItemViewModel() {Id = 2, Name = "Item 2", Rating = 2},
                new RatedItemViewModel() {Id = 3, Name = "Item 3", Rating = 3},
                new RatedItemViewModel() {Id = 4, Name = "Item 4", Rating = 4},
                new RatedItemViewModel() {Id = 5, Name = "Item 5", Rating = 5},
                new RatedItemViewModel() {Id = 6, Name = "Item 6", Rating = 1},
                new RatedItemViewModel() {Id = 7, Name = "Item 7", Rating = 2},
            };
        }

        [HttpPost("", Name = "rating-new")]
        public async Task<ActionResult<RatedItemViewModel>> PostAsync([FromBody]RatedItemViewModel ratedItem)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity();
            }

            return ratedItem;
        }

        [HttpPut("{id}", Name = "rating-update")]
        public async Task<ActionResult<RatedItemViewModel>> PutAsync([FromRoute]int id, [FromBody]RatedItemViewModel ratedItem)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity();
            }

            return ratedItem;
        }
    }

    public class RatedItemViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(0, 5)]
        public int Rating { get; set; }
    }
}
