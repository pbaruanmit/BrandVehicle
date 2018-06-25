using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ValoGari.com
{
    public partial class frmBrand : Form
    {
        private clsBrand _Brand;
        private clsVehicleList _VehicleList;

        private static Dictionary<clsBrand, frmBrand> _BrandFormList =
            new Dictionary<clsBrand, frmBrand>();
        private frmBrand()
        {
            InitializeComponent();
        }

        public static void Run(clsBrand prBrand)
        {
            frmBrand lcBrandForm;
            if (!_BrandFormList.TryGetValue(prBrand, out lcBrandForm))
            {
                lcBrandForm = new frmBrand();
                _BrandFormList.Add(prBrand, lcBrandForm);
                lcBrandForm.SetDetails(prBrand);
            }
            else
            {
                lcBrandForm.Show();
                lcBrandForm.Activate();
            }
        }

        private void updateTitle(string prGalleryName)
        {
            if (!string.IsNullOrEmpty(prGalleryName))
                Text = "Brand Details - " + prGalleryName;
        }

        private void UpdateDisplay()
        {
            if (_VehicleList.SortOrder == 0)
            {
                _VehicleList.SortByName();
                rbByName.Checked = true;
            }
            else
            {
                _VehicleList.SortByDate();
                rbByDate.Checked = true;
            }

            lstVehicle.DataSource = null;
            lstVehicle.DataSource = _VehicleList;
            //lblTotal.Text = Convert.ToString(_WorksList.GetTotalValue());
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
            txtName.Text = _Brand.Name;
            txtCategory.Text = _Brand.Category;
            //txtPhone.Text = _Artist.Phone;
            _VehicleList = _Brand.WorksList;

            //frmMain.Instance.GalleryNameChanged += new frmMain.Notify(updateTitle);
            //updateTitle(_Artist.ArtistList.GalleryName);
        }

        public void SetDetails(clsBrand prArtist)
        {
            _Brand = prArtist;
            txtName.Enabled = string.IsNullOrEmpty(_Brand.Name);
            UpdateForm();
            UpdateDisplay();
            frmMain.Instance.GalleryNameChanged += new frmMain.Notify(updateTitle);
            updateTitle(_Brand.ArtistList.GalleryName);
            Show();
        }

        private void pushData()
        {
            _Brand.Name = txtName.Text;
            _Brand.Category = txtCategory.Text;
            //_Artist.Phone = txtPhone.Text;
            //_WorksList.SortOrder = _SortOrder; // no longer required, updated with each rbByDate_CheckedChanged
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            string lcReply = new InputBox(clsVehicle.FACTORY_PROMPT).Answer;
            if (!string.IsNullOrEmpty(lcReply))
            {
                _VehicleList.AddWork(lcReply[0]);
                UpdateDisplay();
                frmMain.Instance.UpdateDisplay();
            }
        }

        private void lstVehicles_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                _VehicleList.EditWork(lstVehicle.SelectedIndex);
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

            if (lcIndex >= 0 && MessageBox.Show("Are you sure?", "Deleting work", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _VehicleList.RemoveAt(lcIndex);
                UpdateDisplay();
                frmMain.Instance.UpdateDisplay();
            }
        }

        

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (isValid() == true)
                try
                {
                    pushData();
                    if (txtName.Enabled)
                    {
                        _Brand.NewArtist();
                        MessageBox.Show("Brand added!", "Success");
                        frmMain.Instance.UpdateDisplay();
                        txtName.Enabled = false;
                    }
                    Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }

        private Boolean isValid()
        {
            if (txtName.Enabled && txtName.Text != "")
                if (_Brand.IsDuplicate(txtName.Text))
                {
                    MessageBox.Show("Brand with that name already exists!", "Error adding artist");
                    return false;
                }
                else
                    return true;
            else
                return true;
        }

       

        private void rbByDate_CheckedChanged(object sender, EventArgs e)
        {
            _VehicleList.SortOrder = Convert.ToByte(rbByDate.Checked);
            UpdateDisplay();
        }

        

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            if (isValid() == true)
                try
                {
                    pushData();
                    if (txtName.Enabled)
                    {
                        _Brand.NewArtist();
                        MessageBox.Show("Artist added!", "Success");
                        frmMain.Instance.UpdateDisplay();
                        txtName.Enabled = false;
                    }
                    Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }
    }
}
