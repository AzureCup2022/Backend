using AzureBackend.Data;
using AzureBackend.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace AzureBackend.Controllers;

[ApiController]
[Route("[controller]")]
public class OverlayController : Controller
{
    private readonly ILogger<OverlayController> _logger;
    private readonly DataContext _dataContext;

    public OverlayController(ILogger<OverlayController> logger)
    {
        _logger = logger;
    }
    
    // public OverlayController(ILogger<OverlayController> logger, DataContext context)
    // {
    //     _logger = logger;
    //     _dataContext = context;
    // }

    /// <summary>
    /// Return an overlay for the entire city.
    /// The action is expected to take a long time.
    /// </summary>
    [HttpGet("[action]")]
    public async Task<ActionResult<Overlay>> GetCityOverlay(int cityId, string overlayType)
    {
        return Ok(new Overlay());
    }
    
    /// <summary>
    /// Return an overlay within given boundaries.
    /// The action is meant to optimize the data throughput.
    /// </summary>
    /// <remarks>
    /// ! This controller has the lowest priority and does not have to be implement (so far).
    /// </remarks>
    [HttpGet("[action]")]
    public async Task<ActionResult<Overlay>> GetLocalAreaOverlay(int cityId, double longitude, double latitude, int zoomLevel, string overlayType)
    {
        return Ok(new Overlay());
    }
}
