namespace AzureBackend.Utils;

//public static class MockParser
//{
//    public static OverlayResponse GetSafetyMock()
//    {
//        return GetMock("./Data/Mock/safety.json");
//    }

//    public static OverlayResponse GetPollutionMock()
//    {
//        return GetMock("./Data/Mock/badatmosphere.json");
//    }

//    private static OverlayResponse GetMock(string filePath)
//    {
//        var overlay = new OverlayResponse
//        {
//            Data = new List<OverlayDataElement>()
//        };

//        using var streamReader = new StreamReader(filePath);

//        while (!streamReader.EndOfStream)
//        {
//            var line = streamReader.ReadLine();

//            if (line is null)
//                break;

//            if (line.Contains("name"))
//            {
//                line = line[line.IndexOf(':')..];

//                var startIndex = line.IndexOf('\"') + 1;
//                overlay.Name = line.Substring(startIndex, line.LastIndexOf('\"') - startIndex);
//                continue;
//            }

//            if (line.Contains("color"))
//            {
//                line = line[line.IndexOf(':')..];

//                var startIndex = line.IndexOf('\"') + 1;
//                overlay.Color = line.Substring(startIndex, line.LastIndexOf('\"') - startIndex);
//                continue;
//            }

//            if (line.Contains("long"))
//            {
//                var overlayDataElement = new OverlayDataElement();

//                var startIndex = line.IndexOf(':') + 1;
//                overlayDataElement.Long = double.Parse(line.Substring(startIndex, line.IndexOf(',') - startIndex));

//                line = streamReader.ReadLine();
//                startIndex = line.IndexOf(':') + 1;
//                overlayDataElement.Lat = double.Parse(line.Substring(startIndex, line.IndexOf(',') - startIndex));

//                line = streamReader.ReadLine();
//                startIndex = line.IndexOf(':') + 1;
//                overlayDataElement.Radius = double.Parse(line.Substring(startIndex, line.IndexOf(',') - startIndex));

//                line = streamReader.ReadLine();
//                startIndex = line.IndexOf(':') + 1;
//                overlayDataElement.Intensity = double.Parse(line.Substring(startIndex));

//                overlay.Data.Add(overlayDataElement);
//            }
//        }

//        return overlay;
//    }
//}
