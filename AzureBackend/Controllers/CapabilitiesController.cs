using AzureBackend.Data;
using AzureBackend.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace AzureBackend.Controllers;

[ApiController]
[Route("[controller]")]
public class CapabilitiesController : Controller
{
    private readonly ILogger<CapabilitiesController> _logger;
    private readonly DataContext _dataContext;

    public CapabilitiesController(ILogger<CapabilitiesController> logger)
    {
        _logger = logger;
    }
    
    // public CapabilitiesController(ILogger<CapabilitiesController> logger, DataContext context)
    // {
    //     _logger = logger;
    //     _dataContext = context;
    // }
    
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
                Id = 0,
                Name = "Prague",
                Longitude = 50.073658,
                Latitude = 14.418540,
                DefaultZoom = 11
            },
            new()
            {
                Id = 1,
                Name = "Paris",
                Longitude = 48.864716,
                Latitude = 2.349014,
                DefaultZoom = 10
            }
        });
    }

    /// <summary>
    /// Return a list of currently supported overlays for a given city.
    /// The list contains names of the overlays.
    /// </summary>
    [HttpGet("[action]")]
    public async Task<ActionResult<IAsyncEnumerable<string>>> GetAvailableOverlays(int cityId)
    {
        return Ok(new List<string>
        {
            "safety",
            "pollution"
        });
    }
}
