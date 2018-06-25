using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValoGari.com
{
    public sealed class clsDateComparer : IComparer<clsVehicle>
    {
        //Singleton
        public static readonly clsDateComparer Instance = new clsDateComparer();

        private clsDateComparer() { }

        public int Compare(clsVehicle x, clsVehicle y)
        {
            clsVehicle lcWorkX = x;
            clsVehicle lcWorkY = y;
            DateTime lcDateX = lcWorkX.Date.Date;
            DateTime lcDateY = lcWorkY.Date.Date;

            return lcDateX.CompareTo(lcDateY);
        }
    }

    class clsDDateComparer : IComparer<clsVehicle>
    // descending date comparer, i.e. reverse sorting order!
    {
        public int Compare(clsVehicle x, clsVehicle y)
        {
            return y.Date.CompareTo(x.Date);
        }
    }
}
