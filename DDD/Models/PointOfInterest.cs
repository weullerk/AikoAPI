using DDD.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Models
{
    public class PointOfInterest : Model
    {
        public double CoordinateX { get; set; }
        public double CoordinateY { get; set; }
        public double ZoomLevel { get; set; }
        public string Description { get; set; }
    }
}
