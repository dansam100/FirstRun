using System;
using System.Windows.Forms;
using System.Drawing;
using RemoteController;

namespace RemoteController.Extras
{
    public partial class HelpBox : Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox cmdListBox;
        

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        public HelpBox()
        {
            InitializeComponents();
        }

        public void InitializeComponents()
        {
            System.Resources.ResourceManager resources =
                new System.Resources.ResourceManager(typeof(HelpBox));
            
            this.cmdListBox = new System.Windows.Forms.ListBox();

            System.Int32 tabIndex = 0;

            this.SuspendLayout();

            //
            // cmdListBox
            //
            this.cmdListBox.BackColor = System.Drawing.Color.CornflowerBlue;
            this.cmdListBox.Name = "cmdListBox";
            this.cmdListBox.Items.AddRange(ListBoxItemsGet());
            this.cmdListBox.ItemHeight = 50;
            this.cmdListBox.TabIndex = tabIndex;
            this.cmdListBox.Size = new System.Drawing.Size(150, 150);
            this.cmdListBox.SelectedIndexChanged += new System.EventHandler(cmdListBox_SelectedIndexChanged);
            this.cmdListBox.MouseMove += new MouseEventHandler(cmdListBox_MouseMove);
            this.cmdListBox.LostFocus += new EventHandler(cmdListBox_LostFocus);
            
            
            this.cmdListBox.Sorted = true;

            this.MaximizeBox = false;
            this.MinimizeBox = false;
            ClientSize = new Size(150, 150);
            this.Visible = false;
            this.ShowInTaskbar = false;
            this.ShowIcon = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Padding = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.Controls.Add(cmdListBox);
            

            this.ResumeLayout(false);
        }

        
        //public extern void ApplyCommand( System.String command );

        void cmdListBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //CommandExecutor.CommandTaker.Text = cmdListBox.SelectedItems[0].ToString();            
            this.Close();
        }
        
        void cmdListBox_MouseMove(object sender, System.EventArgs e)
        {
            
        }
        
        void cmdListBox_LostFocus(object sender, System.EventArgs e)
        {
            this.Close();
        }

    }
}
