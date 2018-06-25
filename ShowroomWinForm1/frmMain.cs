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
    public sealed partial class frmMain : Form
    {
        //Singleton
        private static readonly frmMain _Instance = new frmMain();

  

        public delegate void Notify(string prGalleryName);

        public event Notify ShowroomNameChanged;
        private frmMain()
        {
            InitializeComponent();
        }

        public static frmMain Instance
        {
            get { return frmMain._Instance; }
        }

        private void updateTitle(string prShowroomName)
        {
            if (!string.IsNullOrEmpty(prShowroomName))
                Text = "Showroom - " + prShowroomName;
        }

        //private clsBrandList _BrandList = new clsBrandList();

        public async void UpdateDisplay()
        {
            /*lstBrands.DataSource = null;
            string[] lcDisplayList = new string[_ArtistList.Count];
            _ArtistList.Keys.CopyTo(lcDisplayList, 0);
            lstBrands.DataSource = lcDisplayList;
            lblValue.Text = Convert.ToString(_ArtistList.GetTotalValue());
            */
           
            try

            {
              lstBrands.DataSource = null;
              lstBrands.DataSource = await ServiceClient.GetBrandNamesAsync();
            }
            catch (Exception ex)
            {
                
            }



        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //frmBrand.Run(new clsBrand(_ArtistList));
                frmBrand.Run(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error adding new Brand");
            }
            
        }



        private void lstBrands_DoubleClick(object sender, EventArgs e)
        {
            string lcKey;

            lcKey = Convert.ToString(lstBrands.SelectedItem);
            if (lcKey != null)
                try
                {
                    frmBrand.Run(lstBrands.SelectedItem as string);        
            //frmBrand.Run(_ArtistList[lcKey]);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, "This should never occur");
                }
                
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            /*try
            {
                _ArtistList.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "File Save Error");
            }
            */
            Close();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            string lcKey;
            
             lcKey = Convert.ToString(lstBrands.SelectedItem);
             if (lcKey != null && MessageBox.Show("Are you sure?", "Deleting artist", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                 try
                 {
                     /*_ArtistList.Remove(lcKey);
                     lstBrands.ClearSelected();
                     UpdateDisplay();
                     */
                    MessageBox.Show(await ServiceClient.DeleteArtist(lcKey));

                }
                 catch (Exception ex)
                 {
                     MessageBox.Show(ex.Message, "Error deleting artist");
                 }
                 
           
        }


        
        private void frmMain_Load_1(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        private void lstBrands_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstBrands_DoubleClick_1(object sender, EventArgs e)
        {
            string lcKey;

            lcKey = Convert.ToString(lstBrands.SelectedItem);
            if (lcKey != null)
                try
                {
                    frmBrand.Run(lstBrands.SelectedItem as string);
                    //frmBrand.Run(_ArtistList[lcKey]);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, "This should never occur");
                }
        }

        private void btnQuit_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
