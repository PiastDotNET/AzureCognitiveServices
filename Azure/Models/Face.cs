using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Azure.Models
{
  public class FaceRectangle
  {
    public int top { get; set; }
    public int left { get; set; }
    public int width { get; set; }
    public int height { get; set; }
  }

  public class Emotion
  {
    public int anger { get; set; }
    public double contempt { get; set; }
    public int disgust { get; set; }
    public int fear { get; set; }
    public double happiness { get; set; }
    public double neutral { get; set; }
    public double sadness { get; set; }
    public int surprise { get; set; }
  }

  public class FaceAttributes
  {
    public double smile { get; set; }
    public string gender { get; set; }
    public int age { get; set; }
    public Emotion emotion { get; set; }
  }

  public class Face
  {
    public string faceId { get; set; }
    public FaceRectangle faceRectangle { get; set; }
    public FaceAttributes faceAttributes { get; set; }
  }
}