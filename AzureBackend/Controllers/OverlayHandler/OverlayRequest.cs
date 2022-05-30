namespace AzureBackend.Controllers.OverlayHandler
{
    public class PostOverlayRequest
    {
        public string OverlayType { get; set; }
        public int CityId { get; set; }
        public string Url { get; set; }
    }
}
