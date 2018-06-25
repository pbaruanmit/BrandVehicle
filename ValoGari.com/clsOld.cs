using System;

namespace ValoGari.com
{
    [Serializable()]
    public class clsOld :clsVehicle
    {
        private string _Condition;
        private float _Mileage;
        //[NonSerialized()]
        //private static frmOld _SculptureDialog;
        public delegate void LoadSculptureFormDelegate(clsOld prSculpture);
        public static LoadSculptureFormDelegate LoadSculptureForm;

        public override void EditDetails()
        {
            LoadSculptureForm(this);
        }

        public string Condition
        {
            get { return _Condition; }
            set { _Condition = value; }

        }
        

        public Single Mileage
        {
            get { return _Mileage; }
            set { _Mileage = value; }
        }

        
    }
}
