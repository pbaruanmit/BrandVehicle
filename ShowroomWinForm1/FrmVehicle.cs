using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShowroomWinForm1
{
    public partial class FrmVehicle : Form
    {
        private clsVehicle _Brand;
        //private clsVehicleList _WorksList;

        private static Dictionary<string, FrmVehicle> _BrandFormList =
            new Dictionary<string, FrmVehicle>();
        public FrmVehicle()
        {
            InitializeComponent();
        }

        public static void Run(clsVehicle prBrandName)

        {
            Console.WriteLine("ssss {0}", prBrandName.VehicleRegNo);
            FrmVehicle lcBrandForm;
            if (string.IsNullOrEmpty(prBrandName.VehicleRegNo) ||

            !_BrandFormList.TryGetValue(prBrandName.VehicleRegNo, out lcBrandForm))

            {
                lcBrandForm = new FrmVehicle();

                if (string.IsNullOrEmpty(prBrandName.VehicleRegNo))

                    lcBrandForm.SetDetails(new clsVehicle());

                else

                {
                    _BrandFormList.Add(prBrandName.VehicleRegNo, lcBrandForm);

                    lcBrandForm.refreshFormFromDB(prBrandName.VehicleRegNo);

                }

            }

            else

            {

                lcBrandForm.Show();

                lcBrandForm.Activate();

            }

        }

        public void SetDetails(clsVehicle prBrand)
        {
            _Brand = prBrand;
            //txtName.Enabled = string.IsNullOrEmpty(_Artist.Name);
            UpdateForm();
            //updateTitle(_Artist.ArtistList.GalleryName);
            Show();
        }

        public void UpdateForm()
        {

            textBoxType.Text = _Brand.VehicleType;
            textBoxModel.Text = _Brand.VehicleModel;
            textBoxPrice.Text = _Brand.VehiclePrice;
            textBoxRegNo.Text = _Brand.VehicleRegNo;
            //_WorksList = _Artist.WorksList;


            //frmMain.Instance.GalleryNameChanged += new frmMain.Notify(updateTitle);
            //updateTitle(_Artist.ArtistList.GalleryName);
        }

        private async void refreshFormFromDB(string prBrandName)
        {
            //throw new NotImplementedException();
            SetDetails(await ServiceClient.GetVehicleAsync(prBrandName));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
