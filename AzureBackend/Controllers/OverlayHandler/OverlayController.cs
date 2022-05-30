using AzureBackend.Data;
using AzureBackend.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace AzureBackend.Controllers.OverlayHandler;

[ApiController]
[Route("[controller]")]
public class OverlayController : Controller
{
    private readonly ILogger<OverlayController> _logger;
    private readonly DatabaseContext _context;


    public OverlayController(ILogger<OverlayController> logger, DatabaseContext context)
    {
        _logger = logger;
        _context = context;
    }

    /// <summary>
    /// Return an overlay for the entire city.
    /// The action is expected to take a long time.
    /// </summary>
    [HttpGet("[action]")]
    public ActionResult<OverlayResponse> GetCityOverlay([FromQuery] int cityId, [FromQuery] string overlayType)
    {
        var overlay = _context.Overlays
            .Where(x => x.CityId == cityId)
            .Where(x => x.OverlayType == overlayType)
            .FirstOrDefault();

        string url = overlay is null ? string.Empty : overlay.Url;


        return new OverlayResponse()
        {
            url = url   //"https://raw.githubusercontent.com/Azure-Samples/AzureMapsCodeSamples/vnext/Static/data/geojson/SamplePoiDataSet.json"
        };
    }

    [HttpPost("[action]")]
    public async Task<ActionResult> PostCityOverlay([FromBody] PostOverlayRequest request)
    {
        //Save it
        Overlay ovr = new Overlay()
        {
            Url = request.Url,
            CityId = request.CityId,
            OverlayType = request.OverlayType
        };

        await _context.Overlays.AddAsync(ovr);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete("[action]")]
    public async Task<ActionResult> DeleteCityOverlay([FromQuery] int id)
    {
        //Delete it 
        var ovr = _context.Overlays.Where(x => x.Id == id).FirstOrDefault();

        if (ovr is null) return BadRequest();

        _context.Overlays.Remove(ovr);

        await _context.SaveChangesAsync();


        return Ok();
    }
}
