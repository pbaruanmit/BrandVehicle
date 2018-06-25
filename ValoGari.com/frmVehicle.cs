using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValoGari.com
{
    public partial class frmVehicle : Form
    {
        protected clsVehicle _Work;
        public frmVehicle()
        {
            InitializeComponent();
        }
        public void SetDetails(clsVehicle prWork)
        {
            _Work = prWork;
            updateForm();
            ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                pushData();
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected virtual bool isValid()
        {
            return true;
        }

        protected virtual void updateForm()
        {
            txtName.Text = _Work.Name;
            txtRegistrationNo.Text = _Work.RegustrationNo;
            txtDescription.Text = _Work.Description;
            txtOrigin.Text = _Work.Origin;
            txtDate.Text = _Work.Date.ToShortDateString();

            
        }

        protected virtual void pushData()
        {
            _Work.Name = txtName.Text;
            _Work.Date = DateTime.Parse(txtDate.Text);
            
        }

        
    }
}
