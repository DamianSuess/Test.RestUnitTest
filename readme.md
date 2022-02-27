# Xamarin REST API sample
This repo shows you how to perform RESTful calls using Xamarin.Forms and setup a Unit Testing framework around it

System test examples show you how to perform validations both online and offline!

## Project Space
* Test.RestApi.SystemTests
  * ``RestTests.cs`` - These tests require an internet connection
  * ``RestMockTest.cs`` - Offline tests using our own mock REST API server
* Test.RestApi
  * ``Models`` are used for system tests
  * The GUI is just garbage noise & can be removed

## Tech Used
* [Microsoft.VisualStudio.TestTools.UnitTesting](https://docs.microsoft.com/en-us/visualstudio/test/using-microsoft-visualstudio-testtools-unittesting-members-in-unit-tests?view=vs-2019)
* [RestSharp](http://restsharp.org/)

### Sample API
* https://devlinduldulao.pro/5-public-apis-for-practicing-rest-in-your-xamarin-forms/


## Sample Snips

### RestSharp - Multiple Rows
```cs
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
```

