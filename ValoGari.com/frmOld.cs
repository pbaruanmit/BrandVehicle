using System;


namespace ValoGari.com
{
    public sealed partial class frmOld : ValoGari.com.frmVehicle
    {
        //Singleton
        public static readonly frmOld Instance = new frmOld();
        private frmOld()
        {
            InitializeComponent();
        }
        public static void Run(clsOld prSculpture)
        {
            Instance.SetDetails(prSculpture);
        }

        protected override void updateForm()
        {
            base.updateForm();
            clsOld lcWork = (clsOld)this._Work;
            txtMileage.Text = lcWork.Mileage.ToString();
            txtCondition.Text = lcWork.Condition;

        }

        protected override void pushData()
        {
            base.pushData();
            clsOld lcWork = (clsOld)_Work;
            lcWork.Mileage = float.Parse(txtMileage.Text);
            lcWork.Condition = txtCondition.Text;

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
