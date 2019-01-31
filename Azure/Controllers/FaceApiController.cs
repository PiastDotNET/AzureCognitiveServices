using Azure.Models;
using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Azure.Controllers
{
  public class FaceApiController : Controller
  {
    string apiAddress = "https://westeurope.api.cognitive.microsoft.com/face/v1.0";
    string key1 = "";

    // GET: FaceApi
    [HttpGet]
    public ActionResult Detect()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Detect(FaceApi faceApi)
    {
      var faces = FaceDetect(faceApi.Url);
      faceApi.Faces = faces;

      return View(faceApi);
    }

    public List<Face> FaceDetect(string url)
    {
      var client = new RestClient(apiAddress);

      var queryString = HttpUtility.ParseQueryString(string.Empty);
      queryString["returnFaceId"] = "true";
      queryString["returnFaceLandmarks"] = "false";
      queryString["returnFaceAttributes"] = "age,gender,smile,emotion";

      var request = new RestRequest("detect?" + queryString, Method.POST);
      request.RequestFormat = DataFormat.Json;

      request.AddHeader(@"Ocp-Apim-Subscription-Key", key1);

      request.AddBody(new { Url = url});

      JsonDeserializer deserializer = new JsonDeserializer();

      var response2 = client.Execute(request);
      var faces = deserializer.Deserialize<List<Face>>(response2);

      return faces;
    }

    [Test]
    public void FaceDetectTest()
    {
      string url = @"https://i.iplsc.com/andrzej-duda-fot-jacek-domi/0006CMFCK67IYAL4-C122-F4.jpg";

      FaceDetect(url);
    }
  }
}