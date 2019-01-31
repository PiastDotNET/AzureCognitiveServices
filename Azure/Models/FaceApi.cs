using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Azure.Models
{
  public class FaceApi
  {
    public string Url { get; set; }

    public List<Face> Faces { get; set; }
  }
}