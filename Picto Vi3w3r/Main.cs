using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ImageShower
{
    public partial class ViewGui
    {
        #region Main...
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new ViewGui());
        }
        #endregion

        #region ExitProgram...
        protected void _OnCloseClick(object sender, EventArgs a)
        {
            Dispose();
            Application.Exit();
        }
        #endregion
    }
}
