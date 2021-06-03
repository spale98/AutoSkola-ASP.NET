using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pokusaj3.Controllers
{

    public class SensorsData
    {
        public string BusIdentifier { get; set; }
        public DateTime[] Dates { get; set; }
        public Measurement[] Measurements { get; set; }
    }

    public class Measurement
    {
        public string Unit { get; set; }
        public float[] Values { get; set; }
    }

}