using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValoGari.com
{
    [Serializable()]
    public class clsBrand
    {
        private string _Name;
        private string _Category;
        private string _Model;

       

        private clsVehicleList _WorksList;
        private clsBrandList _ArtistList;

        //private static frmBrand _ArtistDialog = new frmBrand();

        public clsBrand() { }

        public clsBrand(clsBrandList prArtistList)
        {
            _WorksList = new clsVehicleList();
            _ArtistList = prArtistList;
        }

        public bool IsDuplicate(string prArtistName)
        {
            return _ArtistList.ContainsKey(prArtistName);
        }
        public void NewArtist()
        {
            if (!string.IsNullOrEmpty(Name))
                _ArtistList.Add(Name, this);
            else
                throw new Exception("No artist name entered");
        }

        /*public void EditDetails()
        {
            _ArtistDialog.SetDetails(this);
            //_TotalValue = _WorksList.GetTotalValue();
        }

        public bool IsDuplicate(string prArtistName)
        {
            return _ArtistList.ContainsKey(prArtistName);
        }*/


        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public string Category
        {
            get { return _Category; }
            set { _Category = value; }
        }

        public string Model
        {
            get { return _Model; }
            set { _Model = value; }
        }

        /*public decimal TotalValue
        {
            get { return _TotalValue; }
        }*/
        

        public decimal TotalValue
        {
            get { return _WorksList.GetTotalValue(); /* was: _TotalValue;*/ }
        }

        public clsBrandList ArtistList
        {
            get { return _ArtistList; }
        }

        public clsVehicleList WorksList
        {
            get { return _WorksList; }
        }

        public clsVehicleList VehicleList
        {
            get { return _WorksList; }
        }
    }
}
