using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValoGari.com
{
    [Serializable()]
    public class clsVehicleList : List<clsVehicle>
    {
        private byte _SortOrder;

        public void AddWork(char prChoice)
        {
            clsVehicle lcWork = clsVehicle.NewWork(prChoice);
            if (lcWork != null)
            {
                Add(lcWork);
            }
        }
        public void EditWork(int prIndex)
        {
            if (prIndex >= 0 && prIndex < this.Count)
            {
                clsVehicle lcWork = (clsVehicle)this[prIndex];
                lcWork.EditDetails();
            }
            else
                throw new Exception("Sorry no work selected #" + Convert.ToString(prIndex));
        }

        public decimal GetTotalValue()
        {
            decimal lcTotal = 0;
            foreach (clsVehicle lcWork in this)
            {
               // lcTotal += lcWork.Value;
            }
            return lcTotal;
        }

        public void SortByName()
        {
            Sort(clsNameComparer.Instance);
            _SortOrder = 0;
        }

        public void SortByDate()
        {
            Sort(clsDateComparer.Instance);
            _SortOrder = 1;
        }

        public byte SortOrder
        {
            get { return _SortOrder; }
            set { _SortOrder = value; }
        }


        /*

        //private static clsNameComparer _NameComparer = new clsNameComparer();
        //private static clsDateComparer _DateComparer = new clsDateComparer();
        //private byte _SortOrder;

        public void AddVehicle(char prChoice)
        {
            clsVehicle lcWork = clsVehicle.NewWork(prChoice);
            if (lcWork != null)
            {
                Add(lcWork);
            }
        }

        public void EditVehicle(int prIndex)
        {
            if (prIndex >= 0 && prIndex < this.Count)
            {
                clsVehicle lcWork = (clsVehicle)this[prIndex];
                lcWork.EditDetails();
            }
            else
                throw new Exception("Sorry no work selected #" + Convert.ToString(prIndex));
        }

        /*public decimal GetTotalValue()
        {
            decimal lcTotal = 0;
            foreach (clsVehicle lcWork in this)
            {
                lcTotal += lcWork.Value;
            }
            return lcTotal;
        }
        */
        /*
        public void SortByName()
        {
            Sort(_NameComparer);
            _SortOrder = 0;
        }

        public void SortByDate()
        {
            Sort(_DateComparer);
            _SortOrder = 1;
        }

        public byte SortOrder
        {
            get { return _SortOrder; }
            set { _SortOrder = value; }
        }
        */
    }
}
