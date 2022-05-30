using System.ComponentModel.DataAnnotations;

namespace AzureBackend.Data.Models;

// Good luck storing this one lol.
public class OverlayDataElement
{
    [Key]
    public int Id { get; set; }
    public double Lat { get; set; }
    public double Long { get; set; }
    public double Radius { get; set; }
    public double Intensity { get; set; }
}
