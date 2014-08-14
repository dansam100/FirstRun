using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RemoteController
{
    public partial class CommandExecutor : Form
    {
        
        private System.Drawing.Point startPoint;
        private System.Boolean drag = false;
        public static System.String commandSelected = "";
        
        public CommandExecutor()
        {
            InitializeComponent();
        }

        #region Effects...

        private void cmdIndicator_Click(object sender, EventArgs e)
        {
            commandTaker.Text = "cmd";
        }


        void CommandExecutor_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.drag = false;
        }

        void CommandExecutor_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (this.drag == true)
            {
                System.Drawing.Point p1 = new System.Drawing.Point(e.X, e.Y);
                System.Drawing.Point p2 = this.PointToScreen(p1);
                System.Drawing.Point p3 = new System.Drawing.Point(p2.X - this.startPoint.X,
                                     p2.Y - this.startPoint.Y);
                this.Location = p3;
            }
        }

        void CommandExecutor_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            startPoint = new System.Drawing.Point(e.X, e.Y);
            this.drag = true;
        }

        void CommandTaker_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == System.Windows.Forms.Keys.Enter)
            {
                ekzecuteButton_Click(sender, (System.EventArgs)e);
            }
            if (e.KeyData == System.Windows.Forms.Keys.Escape)
            {
                this.WindowState = FormWindowState.Minimized;
                this.Hide();
                this.notifyIcon.ShowBalloonTip( 2 );
            }
        }
        
        void CommandExecutor_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == System.Windows.Forms.Keys.Enter)
            {
                ekzecuteButton_Click(sender, (System.EventArgs)e);
            }
            if (e.KeyData == System.Windows.Forms.Keys.Escape)
            {
                this.WindowState = FormWindowState.Minimized;
                this.Hide();
                this.notifyIcon.ShowBalloonTip( 2 );
            }
        }

        static void commandTaker_Click(object sender, System.EventArgs e)
        {
            ((TextBox)sender).SelectAll();
            //commandTaker.SelectAll();
        }

        public System.Windows.Forms.TextBox CommandTaker
        {
            get { return commandTaker; }
            set { commandTaker = value; }
        }

        void sampleHelpList_MouseEnter(object sender, System.EventArgs e)
        {
            this.sampleHelpList.BackColor = Color.DarkGreen;
        }
        void sampleHelpList_MouseLeave(object sender, System.EventArgs e)
        {
            this.sampleHelpList.BackColor = this.BackColor;
        }

        void sampleHelpList_Click(object sender, System.EventArgs e)
        {
            this.ShowMyDialogBox();
            //commandTaker.Text = "Type \"help\" for some instructions";
        }

        void ekzecuteButton_Click(object sender, System.EventArgs e)
        {
            throw new System.Exception("The method or operation is not implemented.");
        }

        void CommandExecutor_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (e.CloseReason == System.Windows.Forms.CloseReason.WindowsShutDown ||
                e.CloseReason == System.Windows.Forms.CloseReason.TaskManagerClosing ||
                e.CloseReason == System.Windows.Forms.CloseReason.ApplicationExitCall ||
                e.CloseReason == System.Windows.Forms.CloseReason.UserClosing)
            {
                this.notifyIcon.Dispose();
                Application.Exit();
                                
            }
            else
            {
                this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
                this.Hide();
                
            }
        }

        #region NotifyIcon Effects...

        void notifyIcon_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
           
            if (this.WindowState == System.Windows.Forms.FormWindowState.Normal)
            {
                this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
                this.Hide();
            }
            else
            {
                this.Show();
                this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }

        void aboutProg_Click(object sender, System.EventArgs e)
        {
            Extras.AboutBox aboutDialog = new RemoteController.Extras.AboutBox();
            aboutDialog.ShowDialog();
        }

        void helpProg_Click(object sender, System.EventArgs e)
        {
            throw new System.Exception("The method or operation is not implemented.");
        }

        void RestoreProg_Click(object sender, System.EventArgs e)
        {
            this.Show();
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            
        }


        void minimizeProg_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
        }

        void closeProg_Click(object sender, System.EventArgs e)
        {
            this.Show();
            Application.Exit();
        }

        void notifyIcon_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
           
        }

        #endregion

        #endregion

        public void ShowMyDialogBox()
        {
            Extras.HelpBox Dialog = new Extras.HelpBox();

            // Show testDialog as a modal dialog and determine if DialogResult = OK.
            if (Dialog.ShowDialog(this) == DialogResult.OK)
            {
                Dialog.ShowDialog();
            }
        }

    }
}
