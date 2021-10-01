using System.Collections.Generic;
using System.Threading.Tasks;
using API.Controllers.Types;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeaturesController : ControllerBase
    {
        private readonly DataContext _context;
        public FeaturesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Feature>>> GetFeatures()
        {
            var features = await _context.Features.ToListAsync();

            return features;
        }

        [HttpPost("create")]
        public async Task<ActionResult<Feature>> CreateFeature(TFeature Feature)
        {
            var feature = new Feature
            {
                Name = Feature.Name,
                Activity = Feature.Activity
            };

            _context.Features.Add(feature);
            await _context.SaveChangesAsync();

            return feature;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Feature>> UpdateFeature(int id, TFeature Feature)
        {
            var feature = new Feature
            {
                Id = id,
                Name = Feature.Name,
                Activity = Feature.Activity,
                EndTime = Feature.EndTime
            };

            _context.Update(feature);
            await _context.SaveChangesAsync();
            return feature;
        }
    }
}