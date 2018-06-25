using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

namespace ValoGari.com
  
{

    [Serializable()]
    public class clsBrandList : SortedDictionary<string, clsBrand>
    {
        private const string _FileName = "showroom.dat";
        private string _GalleryName;

        public void NewArtist(clsBrand prArtist)
        {
            if (!string.IsNullOrEmpty(prArtist.Name))
            {
                Add(prArtist.Name, prArtist);
            }
            else
                throw new Exception("No artist name entered");
        }

        public decimal GetTotalValue()
        {
            decimal lcTotal = 0;
            foreach (clsBrand lcArtist in Values)
            {
                lcTotal += lcArtist.TotalValue;
            }
            return lcTotal;
        }

        public string GalleryName
        {
            get { return _GalleryName; }
            set { _GalleryName = value; }
        }

        public static clsBrandList RetrieveArtistList()
        {
            clsBrandList lcArtistList;
            try
            {
                System.IO.FileStream lcFileStream = new System.IO.FileStream(_FileName, System.IO.FileMode.Open);
                BinaryFormatter lcFormatter = new BinaryFormatter();
                lcArtistList = (clsBrandList)lcFormatter.Deserialize(lcFileStream);
                lcFileStream.Close();
            }
            catch (Exception ex)
            {
                lcArtistList = new clsBrandList();
                throw new Exception("File Retrieve Error: " + ex.Message);
            }
            return lcArtistList;
        }

        public void Save()
        {
            System.IO.FileStream lcFileStream = new System.IO.FileStream(_FileName, System.IO.FileMode.Create);
            BinaryFormatter lcFormatter = new BinaryFormatter();
            lcFormatter.Serialize(lcFileStream, this);
            lcFileStream.Close();
        }


        /*public void EditBrand(string prKey)
        {
            clsBrand lcBrand;
            lcBrand = this[prKey];
            if (lcBrand != null)
                lcBrand.EditDetails();
            else
                throw new Exception("Sorry no Brand by this name");
        }

        public void NewBrand()
        {
            clsBrand lcBrand = new clsBrand(this);
            if (lcBrand.Name != "")
                Add(lcBrand.Name, lcBrand);
        }

        public decimal GetTotalValue()
        {
            decimal lcTotal = 0;
            foreach (clsBrand lcArtist in Values)
            {
                //lcTotal += lcArtist.TotalValue;
            }
            return lcTotal;
        }
        

        public static clsBrandList RetrieveBrandList()
        {
            clsBrandList lcBrandList;
            try
            {
                System.IO.FileStream lcFileStream = new System.IO.FileStream(_FileName, System.IO.FileMode.Open);
                BinaryFormatter lcFormatter = new BinaryFormatter();
                lcBrandList = (clsBrandList)lcFormatter.Deserialize(lcFileStream);
                lcFileStream.Close();
            }
            catch (Exception ex)
            {
                lcBrandList = new clsBrandList();
                throw new Exception("File Retrieve Error: " + ex.Message);
            }
            return lcBrandList;
        }

        public void Save()
        {
            System.IO.FileStream lcFileStream = new System.IO.FileStream(_FileName, System.IO.FileMode.Create);
            BinaryFormatter lcFormatter = new BinaryFormatter();
            lcFormatter.Serialize(lcFileStream, this);
            lcFileStream.Close();
        }
        */
    }
}
