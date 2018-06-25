using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValoGari.com
{
    sealed class clsNameComparer : IComparer<clsVehicle>
    {   //Singleton
        public static readonly clsNameComparer Instance = new clsNameComparer();

        private clsNameComparer() { }

        public int Compare(clsVehicle x, clsVehicle y)
        {
            clsVehicle workClassX = x;
            clsVehicle workClassY = y;
            string lcNameX = workClassX.Name;
            string lcNameY = workClassY.Name;

            return lcNameX.CompareTo(lcNameY);
        }
    }
}
