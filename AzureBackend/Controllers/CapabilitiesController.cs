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
        var cities = _context.Cities.ToList();

        return Ok(cities);
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
