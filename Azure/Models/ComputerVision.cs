using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Azure.Models
{

  public class Caption
  {
    public string text { get; set; }
    public double confidence { get; set; }
  }

  public class Description
  {
    public List<string> tags { get; set; }
    public List<Caption> captions { get; set; }
  }

  public class Metadata
  {
    public int height { get; set; }
    public int width { get; set; }
    public string format { get; set; }
  }

  public class ComputerVision
  {
    public Description description { get; set; }
    public string requestId { get; set; }
    public Metadata metadata { get; set; }
  }
}