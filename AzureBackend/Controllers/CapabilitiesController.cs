using AzureBackend.Data;
using AzureBackend.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace AzureBackend.Controllers;

[ApiController]
[Route("[controller]")]
public class CapabilitiesController : Controller
{
    private readonly ILogger<CapabilitiesController> _logger;
    private readonly DatabaseContext _context;

    public CapabilitiesController(ILogger<CapabilitiesController> logger, DatabaseContext context)
    {
        _logger = logger;
        _context = context;
    }

    /// <summary>
    /// Return a list of current supported cities.
    /// </summary>
    [HttpGet("[action]")]
    public async Task<ActionResult<IAsyncEnumerable<City>>> GetAvailableCities()
    {
        return Ok(new List<City>
        {
            new()
            {
                Id = 1,
                Name = "Prague",
                Longitude = 50.073658,
                Latitude = 14.418540,
                DefaultZoom = 11
            },
            new()
            {
                Id = 2,
                Name = "Paris",
                Longitude = 48.864716,
                Latitude = 2.349014,
                DefaultZoom = 10
            }
        });
    }

    [HttpPost("[action]")]
    public async Task<ActionResult> AddCity([FromBody] City city)
    {
        _context.Cities.Add(city);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete("[action]")]
    public async Task<ActionResult> DeleteCity([FromQuery] int id)
    {
        var city = await _context.Cities.FindAsync(id);
        if (city == null)
        {
            return NotFound();
        }

        _context.Cities.Remove(city);
        await _context.SaveChangesAsync();
        return Ok();
    }

    /// <summary>
    /// Return a list of currently supported overlays for a given city.
    /// The list contains names of the overlays.
    /// </summary>
    [HttpGet("[action]")]
    public ActionResult<IEnumerable<string>> GetAvailableOverlays([FromQuery] int cityId)
    {
        var ovrs = _context.Overlays.Where(x => x.CityId == cityId).Select(x => x.OverlayType).ToList();

        return Ok(ovrs);
    }
}
