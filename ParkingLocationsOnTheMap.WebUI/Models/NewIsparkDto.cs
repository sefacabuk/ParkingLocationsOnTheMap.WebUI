using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingLocationsOnTheMap.WebUI.Models
{
    public class NewIsparkDto
    {
        public int Id { get; set; }
        public string parK_NAME { get; set; }
        public string locatioN_NAME { get; set; }
        public string parK_TYPE_ID { get; set; }
        public int capacitY_OF_PARK { get; set; }
        public string workinG_TIME { get; set; }
        public string countY_NAME { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
}
