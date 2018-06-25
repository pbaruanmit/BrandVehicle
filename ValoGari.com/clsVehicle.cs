using System;

namespace ValoGari.com
{
    [Serializable()]
    public abstract class clsVehicle
    {
        private string _Name;
        private string _RegustrationNo;
        private string _Description;
        private decimal _Price;
        private string _Origin;
        private DateTime _Date = DateTime.Now;
        
        public static readonly string FACTORY_PROMPT = "Enter N for New, O for Old";

        public clsVehicle()
        {
            EditDetails();
        }

        public static clsVehicle NewWork(char prChoice)
        {
            switch (char.ToUpper(prChoice))
            {
                case 'N': return new clsNew();
                case 'O': return new clsOld();
                
                default: return null;
            }
        }

        public abstract void EditDetails();

        public override string ToString()
        {
            return _Name + "\t" + _Date.ToShortDateString();
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value; }
        }

        public decimal Price
        {
            get { return Price1; }
            set { Price1 = value; }
        }

        public string RegustrationNo { get => _RegustrationNo; set => _RegustrationNo = value; }
        public string Description { get => _Description; set => _Description = value; }
        public string Origin { get => _Origin; set => _Origin = value; }
        public decimal Price1 { get => _Price; set => _Price = value; }
    }
}
