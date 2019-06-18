using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using RestSharp.Serialization.Json;
using Test.RestApi.WebApi;

namespace Test.RestApi.SystemTests
{
  [TestClass]
  public class RestTests
  {
    /*
     * https://www.ontestautomation.com/restful-api-testing-in-csharp-with-restsharp/
     * Sample:
        {
          "post code": "90210",
          "country": "United States",
          "country abbreviation": "US",
          "places": [{
            "place name": "Beverly Hills",
            "longitude": "-118.4065",
            "state": "California",
            "state abbreviation": "CA",
            "latitude": "34.0901"
          }]
        }
     */

    [TestMethod]
    public void StatusCodeTest()
    {
      // Request input: "{countryCode}/{zipCode}"
      RestClient client = new RestClient("http://api.zippopotam.us");
      RestRequest request = new RestRequest("nl/3825", Method.GET);
      IRestResponse response = client.Execute(request);

      Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
    }

    [TestMethod]
    [DataTestMethod]
    [DataRow("nl", "3825", HttpStatusCode.OK)]
    [DataRow("us", "15203", HttpStatusCode.OK)]
    public void ContentTypeTest(string countryCode, string zipCode, HttpStatusCode statusCode)
    {
      RestClient client = new RestClient("http://api.zippopotam.us");
      RestRequest request = new RestRequest($"{countryCode}/{zipCode}", Method.GET);

      IRestResponse response = client.Execute(request);

      Assert.AreEqual(statusCode, response.StatusCode);
    }

    [TestMethod]
    public void CountryAbbrvSerializtaionTest()
    {
      RestClient client = new RestClient("http://api.zippopotam.us");
      RestRequest request = new RestRequest("us/12345", Method.GET);

      IRestResponse response = client.Execute(request);
      LocationResponse locationResponse =
        new JsonDeserializer().Deserialize<LocationResponse>(response);

      Assert.AreEqual("New York", locationResponse.Places[0].State);
    }
  }
}