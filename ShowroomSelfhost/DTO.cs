using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowroomSelfhost
{
    public class clsBrand

    {

        public string BrandName { get; set; }

        public string BrandDescription { get; set; }

        public List<clsVehicle> VehicleList { get; set; }

    }
    public class clsVehicle
    {
        public string VehicleType { get; set; }
        public string VehicleModel { get; set; }
        public string VehiclePrice { get; set; }
        public string VehicleRegNo { get; set; }
    }
}
