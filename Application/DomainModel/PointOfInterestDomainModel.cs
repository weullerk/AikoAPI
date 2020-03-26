using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DomainModel
{
    public class PointOfInterestDomainModel
    {
        public Guid Id { get; set; }

        public double CoordinateX { get; set; }
        public double CoordinateY { get; set; }
        public double ZoomLevel { get; set; }

        public string Description { get; set; }
    }
}
