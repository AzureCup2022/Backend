using System.ComponentModel.DataAnnotations;

namespace AzureBackend.Data.Models;

public class Overlay
{
    [Key]
    [StringLength(50)]
    public string Name { get; set; } = string.Empty;
    
    [StringLength(20)]
    public string? Color { get; set; }
    
    public ICollection<OverlayDataElement>? Data { get; set; }
}
