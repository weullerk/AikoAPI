using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ViewModel
{
    public class PointOfInterestViewModel
    {
        public Guid Id { get; set; }

        public string Coordinates { get; set; }

        public string Description { get; set; }
    }
}
