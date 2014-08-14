using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteController.Extras
{
    partial class HelpBox : System.Windows.Forms.Form
    {
        private object[] ListBoxItemsGet()
        {
            System.String[] items = new System.String[]{
                "cmd", "appwiz.cpl", "winword", "excel", "run"
            };
            return items;
        }
    }
}
