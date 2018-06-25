using System;

namespace ValoGari.com
{
    [Serializable()]
    public class clsNew : clsVehicle
    {
        private float _Warrenty;
        


        //[NonSerialized()]
        //private static frmNew _PaintDialog;

        public delegate void LoadPhotographFormDelegate(clsNew prPhotograph);
        public static LoadPhotographFormDelegate LoadPhotographForm;

        public override void EditDetails()
        {
            LoadPhotographForm(this);
        }

        public Single Warrenty
        {
            get { return _Warrenty; }
            set { _Warrenty = value; }
        }

        // public string Type
        //{
        // get { return _Type; }
        //set { _Type = value; }
        //}
    }
}
