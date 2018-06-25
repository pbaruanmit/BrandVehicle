using System;

namespace ValoGari.com
{
    public sealed partial class frmNew : ValoGari.com.frmVehicle
    {
        //Singleton
        public static readonly frmNew Instance = new frmNew();

        private frmNew()
        {
            InitializeComponent();
        }
        public static void Run(clsNew prPhotograph)
        {
            Instance.SetDetails(prPhotograph);
        }

        protected override void updateForm()
        {
            base.updateForm();
            clsNew lcWork = (clsNew)this._Work;
            txtWarrenty.Text = lcWork.Warrenty.ToString();
            //txtHeight.Text = lcWork.Height.ToString();
            //txtWarrenty.Text = lcWork.Warrenty;
        }

        protected override void pushData()
        {
            base.pushData();
            clsNew lcWork = (clsNew)_Work;
            lcWork.Warrenty = float.Parse(txtWarrenty.Text);
            //lcWork.Height = float.Parse(txtHeight.Text);
            //lcWork.Type = txtType.Text;
        }





       /* protected override void updateForm()
        {
            base.updateForm();
            clsNew lcWork = (clsNew)_Vehicle;
            txtWarrenty.Text = lcWork.Warrenty.ToString();
           
        }

        protected override void pushData()
        {
            base.pushData();
            clsNew lcWork = (clsNew)_Vehicle;
            lcWork.Warrenty = float.Parse(txtWarrenty.Text);
            
        }

        private void frmNew_Load(object sender, EventArgs e)
        {

        }
        */
    }
}
