using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShowroomWinForm.com
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private clsBrandList _BrandList = new clsBrandList();
        private void updateDisplay()
        {
            lstBrands.DataSource = null;
            string[] lcDisplayList = new string[_BrandList.Count];
            _BrandList.Keys.CopyTo(lcDisplayList, 0);
            lstBrands.DataSource = lcDisplayList;
            //lblValue.Text = Convert.ToString(_BrandList.GetTotalValue());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _BrandList.NewBrand();
                MessageBox.Show("Brand added!", "Success");
                updateDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error adding new Brand");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string lcKey;

            lcKey = Convert.ToString(lstBrands.SelectedItem);
            if (lcKey != null && MessageBox.Show("Are you sure?", "Deleting Brand", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                try
                {
                    _BrandList.Remove(lcKey);
                    lstBrands.ClearSelected();
                    updateDisplay();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error deleing Brand");
                }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                _BrandList = clsBrandList.RetrieveBrandList();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "File retrieve error");
            }
            updateDisplay();
        }

        private void lstBrands_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
