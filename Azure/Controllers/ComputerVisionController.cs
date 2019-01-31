using Azure.Models;
using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Azure.Controllers
{
  public class ComputerVisionController : Controller
  {
    string apiAddress = @"https://westeurope.api.cognitive.microsoft.com/vision/v1.0";
    string key1 = "";

    [HttpGet]
    public ActionResult Describe()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Describe(Image image)
    {
      var computerVision = DescribeImage(image.Url);
      image.ComputerVision = computerVision;

      return View(image);
    }

    private ComputerVision DescribeImage(string url)
    {
      var client = new RestClient(apiAddress);

      var queryString = HttpUtility.ParseQueryString(string.Empty);
      queryString["maxCandidates"] = "1";

      var request = new RestRequest("describe?" + queryString, Method.POST);
      request.RequestFormat = DataFormat.Json;

      request.AddHeader(@"Ocp-Apim-Subscription-Key", key1);

      request.AddBody(new { Url = url });

      JsonDeserializer deserializer = new JsonDeserializer();

      var response2 = client.Execute(request);
      var imageDescription = deserializer.Deserialize<ComputerVision>(response2);

      return imageDescription;
    }

    [Test]
    public void DescribeImage()
    {
      string url = @"https://i.iplsc.com/andrzej-duda-fot-jacek-domi/0006CMFCK67IYAL4-C122-F4.jpg";

      DescribeImage(url);
    }
  }
}