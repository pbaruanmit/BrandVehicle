using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValoGari.com
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //clsPainting.LoadPaintingForm = new clsPainting.LoadPaintingFormDelegate(frmPainting.Run);
            clsNew.LoadPhotographForm = new clsNew.LoadPhotographFormDelegate(frmNew.Run);
            clsOld.LoadSculptureForm = new clsOld.LoadSculptureFormDelegate(frmOld.Run);
            Application.Run(frmMain.Instance);
        }
    }
}
