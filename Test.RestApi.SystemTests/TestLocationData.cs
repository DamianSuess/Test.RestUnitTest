using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.RestApi.SystemTests
{
  public static class TestLocationData
  {
    // http://api.zippopotam.us/us/pa/pittsburgh

    public const string LocationPaPittsburgh = @"
{""country abbreviation"": ""US"", ""places"": [
{""place name"": ""East Pittsburgh"", ""longitude"": ""-79.8389"", ""post code"": ""15112"", ""latitude"": ""40.4036""},
{""place name"": ""Pittsburgh"", ""longitude"": ""-79.9528"", ""post code"": ""15201"", ""latitude"": ""40.4752""},
{""place name"": ""Pittsburgh"", ""longitude"": ""-80.0685"", ""post code"": ""15202"", ""latitude"": ""40.5053""},
{""place name"": ""Pittsburgh"", ""longitude"": ""-79.9799"", ""post code"": ""15203"", ""latitude"": ""40.4254""},
{""place name"": ""Pittsburgh"", ""longitude"": ""-80.0644"", ""post code"": ""15204"", ""latitude"": ""40.4554""},
{""place name"": ""Pittsburgh"", ""longitude"": ""-80.1021"", ""post code"": ""15205"", ""latitude"": ""40.4322""},
{""place name"": ""Pittsburgh"", ""longitude"": ""-79.9839"", ""post code"": ""15210"", ""latitude"": ""40.4072""},
{""place name"": ""Pittsburgh"", ""longitude"": ""-80.0144"", ""post code"": ""15211"", ""latitude"": ""40.4295""},
{""place name"": ""Pittsburgh"", ""longitude"": ""-79.9667"", ""post code"": ""15227"", ""latitude"": ""40.3805""},
{""place name"": ""Pittsburgh"", ""longitude"": ""-80.0108"", ""post code"": ""15295"", ""latitude"": ""40.463""}],
""country"": ""United States"", ""place name"": ""East Pittsburgh"", ""state"": ""Pennsylvania"", ""state abbreviation"": ""PA""}";

    private const string LocationCaBeverlyHills = @"
{
  ""post code"": ""90210"",
  ""country"": ""United States"",
  ""country abbreviation"": ""US"",
  ""places"": [{
    ""place name"": ""Beverly Hills"",
    ""longitude"": ""-118.4065"",
    ""state"": ""California"",
    ""state abbreviation"": ""CA"",
    ""latitude"": ""34.0901""
  }]
}";
  }
}
