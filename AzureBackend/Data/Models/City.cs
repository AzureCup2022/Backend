using System.ComponentModel.DataAnnotations;

namespace AzureBackend.Data.Models;

public class City
{
    [Key]
    public int Id { get; set; }
    
    public double Longitude { get; set; } 
    
    public double Latitude { get; set; }
    
    /// <summary>
    /// Specifies how much the Frontend map element should be zoomed in upon loading.
    /// The zoom level seems to be standardized and can be found here:
    /// https://www.latlong.net/place/prague-the-czech-republic-27250.html
    /// </summary>
    public int? DefaultZoom { get; set; }
}
