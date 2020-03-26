using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste_Aiko.Requests.PointOfInterest
{
    public class UpdatePointOfInterestRequest
    {
        public string Coordinates { get; set; }

        public string Description { get; set; }
    }
}
