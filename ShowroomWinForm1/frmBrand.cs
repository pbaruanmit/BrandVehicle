using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ShowroomWinForm1
{
    public partial class frmBrand : Form
    {
        private clsBrand _Brand;
        //private clsVehicleList _WorksList;

        private static Dictionary<string, frmBrand> _BrandFormList =
            new Dictionary<string, frmBrand>();
        private frmBrand()
        {
            InitializeComponent();
        }

        public static void Run(string prBrandName)

        {
            frmBrand lcBrandForm;
            if (string.IsNullOrEmpty(prBrandName) ||

            !_BrandFormList.TryGetValue(prBrandName, out lcBrandForm))

            {
                lcBrandForm = new frmBrand();

                if (string.IsNullOrEmpty(prBrandName))

                    lcBrandForm.SetDetails(new clsBrand());

                else

                { _BrandFormList.Add(prBrandName, lcBrandForm);

                    lcBrandForm.refreshFormFromDB(prBrandName);

                }

            }

            else

            {

                lcBrandForm.Show();

                lcBrandForm.Activate();

            }

        }

        private async void  refreshFormFromDB(string prBrandName)
        {
            //throw new NotImplementedException();
            SetDetails(await ServiceClient.GetBrandAsync(prBrandName));
        }

        private void updateTitle(string prShowroomName)
        {
            if (!string.IsNullOrEmpty(prShowroomName))
                Text = "Brand Details - " + prShowroomName;
        }

        private void UpdateDisplay()
        {
            lstVehicle.DataSource = null;

            if (_Brand.VehicleList != null)

                lstVehicle.DataSource = _Brand.VehicleList;
        }

        //private clsBrand _Brand;
        //private clsVehicleList _VehicleList;

        /*public void SetDetails(clsBrand prBrand)
        {
            _Brand = prBrand;
            updateForm();
            updateDisplay();
            ShowDialog();
        }*/

        public void UpdateForm()
        {
            
            txtName.Text = _Brand.BrandName;
            txtCategory.Text = _Brand.BrandDescription;
            //txtPhone.Text = _Artist.Phone;
            //_WorksList = _Artist.WorksList;
            

            //frmMain.Instance.GalleryNameChanged += new frmMain.Notify(updateTitle);
            //updateTitle(_Artist.ArtistList.GalleryName);
        }

        public void SetDetails(clsBrand prBrand)
        {
            _Brand = prBrand;
            //txtName.Enabled = string.IsNullOrEmpty(_Artist.Name);
            UpdateForm();
            UpdateDisplay();
            frmMain.Instance.ShowroomNameChanged += new frmMain.Notify(updateTitle);
            //updateTitle(_Artist.ArtistList.GalleryName);
            Show();
        }

        private void pushData()
        {
            //_Artist.Name = txtName.Text;
            //_Artist.Category = txtCategory.Text;
            //_Artist.Phone = txtPhone.Text;
            //_WorksList.SortOrder = _SortOrder; // no longer required, updated with each rbByDate_CheckedChanged
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            //string lcReply = new InputBox(clsVehicle.FACTORY_PROMPT).Answer;
            //if (!string.IsNullOrEmpty(lcReply))
            {
                //_WorksList.AddWork(lcReply[0]);
                UpdateDisplay();
                frmMain.Instance.UpdateDisplay();
            }
        }

        private void lstVehicles_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //_WorksList.EditWork(lstVehicle.SelectedIndex);
                UpdateDisplay();
                frmMain.Instance.UpdateDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            int lcIndex = lstVehicle.SelectedIndex;

            if (lcIndex >= 0 && MessageBox.Show("Are you sure?", "Deleting Brand", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
               // _WorksList.RemoveAt(lcIndex);
                UpdateDisplay();
                frmMain.Instance.UpdateDisplay();
            }
        }

        

        private async void btnClose_Click(object sender, EventArgs e)
        {
            pushData();

            if (txtName.Enabled)

            {

                MessageBox.Show(await ServiceClient.InsertArtistAsync(_Brand));

                frmMain.Instance.UpdateDisplay();

                txtName.Enabled = false;

            }

            else

                MessageBox.Show(await ServiceClient.UpdateArtistAsync(_Brand));

            Hide();
        }

        private Boolean isValid()
        {

            /*
            if (txtName.Enabled && txtName.Text != "")
                if (_Artist.IsDuplicate(txtName.Text))
                {
                    MessageBox.Show("Artist with that name already exists!", "Error adding artist");
                    return false;
                }
               
                else
                    return true;
                   
            else
             */
            return true; }

        private async void btnClose_Click_1(object sender, EventArgs e)
        {
            pushData();

            if (txtName.Enabled)

            {

                MessageBox.Show(await ServiceClient.InsertArtistAsync(_Brand));

                frmMain.Instance.UpdateDisplay();

                txtName.Enabled = false;

            }

            else

                MessageBox.Show(await ServiceClient.UpdateArtistAsync(_Brand));

            Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {

        }

        private void lstVehicle_DoubleClick(object sender, EventArgs e)
        {
            string lcKey;

            lcKey = Convert.ToString(lstVehicle.SelectedItem);
            if (lcKey != null)
                try
                {
                    FrmVehicle.Run(lstVehicle.SelectedItem as clsVehicle);
                    //frmBrand.Run(_ArtistList[lcKey]);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, "This should never occur");
                }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

       
       /*
        private void rbByDate_CheckedChanged(object sender, EventArgs e)
        {
            _WorksList.SortOrder = Convert.ToByte(rbByDate.Checked);
            UpdateDisplay();
        }
        */

        
       /*
        private void btnClose_Click_1(object sender, EventArgs e)
        {
            if (isValid() == true)
                try
                {
                    pushData();
                    if (txtName.Enabled)
                    {
                        _Artist.NewArtist();
                        MessageBox.Show("Artist added!", "Success");
                        frmMain.Instance.UpdateDisplay();
                        txtName.Enabled = false;
                    }
                    Hide();
                }
            */
            /*
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                */
        }
    

