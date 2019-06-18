using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using RestSharp;
using Test.RestApi.WebApi;

namespace Test.RestApi.SystemTests
{
  [TestClass]
  public class RestMockTest
  {
    // http://restsharp.org/
    // Mock RestClient - https://stackoverflow.com/questions/42646830/how-to-mock-restsharp-portable-library-in-unit-test

    private readonly string Url = "http://api.zippopotam.us";

    private readonly string JsonLocationSample = @"
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

    public static IRestClient MockRestClient<T>(HttpStatusCode httpStatusCode, string json)
    where T : new()
    {
      var data = JsonConvert.DeserializeObject<T>(json);
      var response = new Mock<IRestResponse<T>>();
      response.Setup(_ => _.StatusCode).Returns(httpStatusCode);
      response.Setup(_ => _.Data).Returns(data);

      var mockIRestClient = new Mock<IRestClient>();
      mockIRestClient.Setup(x => x.Execute<T>(Moq.It.IsAny<IRestRequest>()))
                     .Returns(response.Object);

      return mockIRestClient.Object;
    }

    [TestMethod]
    public void LiveGetLocationByCityTest()
    {
      IRestClient restClient = new RestClient(Url);
      var service = new DataServices(restClient);
      var loc = service.GetLocationByCity("us", "15203");


      Assert.IsNotNull(loc);
      Assert.IsTrue(loc.Places.Count > 0);

      bool hasCity = false;
      foreach (var place in loc.Places)
      {
        if (place.PlaceName == "Pittsburgh")
          hasCity = true;
      }

      Assert.IsTrue(hasCity);
    }

    [TestMethod]
    public void MockGetLocationByCityTest()
    {
      var restClient = MockRestClient<LocationResponse>(HttpStatusCode.OK, JsonLocationSample);
      var service = new DataServices(restClient);
      var loc = service.GetLocationByCity("us", "90210");

      Assert.IsNotNull(loc);
      Assert.IsTrue(loc.Places.Count > 0);

      bool hasCity = false;
      foreach (var place in loc.Places)
      {
        if (place.PlaceName == "Beverly Hills")
          hasCity = true;
      }

      Assert.IsTrue(hasCity);
    }
  }

  // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

  public interface IDataServices
  {
    LocationResponse GetLocationByCity(string country, string zip);
  }

  public class DataServices : IDataServices
  {
    private readonly IRestClient _restClient;

    public DataServices(IRestClient restClient)
    {
      _restClient = restClient;
    }

    public LocationResponse GetLocationByCity(string country, string zip)
    {
      LocationResponse location = null;

      // Create a new request
      var restRequest = new RestRequest($"{country}/{zip}", Method.GET);
      // Sample:
      //  - RestRequest(resource: "User", Method.POST);
      //  - .AddParameter("UserName", "User123", ParameterType.QueryString).

      // Create REST parameters
      // Adds to POST or URL querystring based on Method
      // restRequest.AddParameter("place name", city, ParameterType.QueryString);

      // Execute the REST request
      var restResponse = _restClient.Execute<LocationResponse>(restRequest);
      if (restResponse.StatusCode.Equals(HttpStatusCode.OK))
      {
        location = restResponse.Data;
      }

      return location;
    }
  }
}
