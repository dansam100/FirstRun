using System.Drawing;

namespace RemoteController
{
    public partial class CommandExecutor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommandExecutor));
            this.commandTaker = new System.Windows.Forms.TextBox();
            this.sampleHelpList = new System.Windows.Forms.Button();
            this.ekzecuteButton = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.Ex3kuteMenu = new System.Windows.Forms.ContextMenu();
            this.RestoreProg = new System.Windows.Forms.MenuItem();
            this.minimizeProg = new System.Windows.Forms.MenuItem();
            this.helpProg = new System.Windows.Forms.MenuItem();
            this.aboutProg = new System.Windows.Forms.MenuItem();
            this.closeProg = new System.Windows.Forms.MenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // commandTaker
            // 
            this.commandTaker.Location = new System.Drawing.Point(18, 3);
            this.commandTaker.Name = "commandTaker";
            this.commandTaker.Size = new System.Drawing.Size(242, 20);
            this.commandTaker.TabIndex = 0;
            this.commandTaker.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CommandTaker_KeyDown);
            // 
            // sampleHelpList
            // 
            this.sampleHelpList.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.sampleHelpList.Font = new System.Drawing.Font("Comic Sans MS", 8F, System.Drawing.FontStyle.Bold);
            this.sampleHelpList.Location = new System.Drawing.Point(0, 6);
            this.sampleHelpList.Name = "sampleHelpList";
            this.sampleHelpList.Size = new System.Drawing.Size(12, 12);
            this.sampleHelpList.TabIndex = 3;
            this.sampleHelpList.Text = "+";
            this.sampleHelpList.MouseLeave += new System.EventHandler(this.sampleHelpList_MouseLeave);
            this.sampleHelpList.Click += new System.EventHandler(this.sampleHelpList_Click);
            this.sampleHelpList.MouseEnter += new System.EventHandler(this.sampleHelpList_MouseEnter);
            // 
            // ekzecuteButton
            // 
            this.ekzecuteButton.Location = new System.Drawing.Point(300, 300);
            this.ekzecuteButton.Name = "ekzecuteButton";
            this.ekzecuteButton.Size = new System.Drawing.Size(26, 20);
            this.ekzecuteButton.TabIndex = 2;
            this.ekzecuteButton.Click += new System.EventHandler(this.ekzecuteButton_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "App is running minimized. Right-click to activate";
            this.notifyIcon.BalloonTipTitle = "EX3CuTE";
            this.notifyIcon.ContextMenu = this.Ex3kuteMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "eX3CuTE";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // Ex3kuteMenu
            // 
            this.Ex3kuteMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.RestoreProg,
            this.minimizeProg,
            this.helpProg,
            this.aboutProg,
            this.closeProg});
            // 
            // RestoreProg
            // 
            this.RestoreProg.DefaultItem = true;
            this.RestoreProg.Index = 0;
            this.RestoreProg.Text = "&Restore...";
            this.RestoreProg.Click += new System.EventHandler(this.RestoreProg_Click);
            // 
            // minimizeProg
            // 
            this.minimizeProg.Index = 1;
            this.minimizeProg.Text = "&Minimize";
            this.minimizeProg.Click += new System.EventHandler(this.minimizeProg_Click);
            // 
            // helpProg
            // 
            this.helpProg.Index = 2;
            this.helpProg.Text = "&Help...";
            this.helpProg.Click += new System.EventHandler(this.helpProg_Click);
            // 
            // aboutProg
            // 
            this.aboutProg.Index = 3;
            this.aboutProg.Text = "&About...";
            this.aboutProg.Click += new System.EventHandler(this.aboutProg_Click);
            // 
            // closeProg
            // 
            this.closeProg.Index = 4;
            this.closeProg.Text = "&Close...";
            this.closeProg.Click += new System.EventHandler(this.closeProg_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // CommandExecutor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(296, 39);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.commandTaker);
            this.Controls.Add(this.ekzecuteButton);
            this.Controls.Add(this.sampleHelpList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Location = new System.Drawing.Point(300, 200);
            this.MaximizeBox = false;
            this.MaximumSize = this.Size;
            this.MinimizeBox = false;
            this.MinimumSize = this.Size;
            this.Name = "CommandExecutor";
            this.ShowInTaskbar = false;
            this.Text = "EkZ3KUtE";
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CommandExecutor_MouseUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CommandExecutor_MouseDown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CommandExecutor_FormClosing);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CommandExecutor_MouseMove);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CommandExecutor_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ekzecuteButton;
        public System.Windows.Forms.Button sampleHelpList;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenu contextMenu;
        private System.Windows.Forms.MenuItem closeProg;
        private System.Windows.Forms.MenuItem  RestoreProg;
        private System.Windows.Forms.MenuItem  minimizeProg;
        private System.Windows.Forms.MenuItem  helpProg;
        private System.Windows.Forms.MenuItem  aboutProg;
        private System.Windows.Forms.ContextMenu Ex3kuteMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox commandTaker;
    }
}

