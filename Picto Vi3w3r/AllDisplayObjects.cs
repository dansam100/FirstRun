/*
 * Created by SharpDevelop.
 * User: samuel
 * Date: 4/2/2007
 * Time: 8:37 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Windows.Forms;

namespace ImageShower
{
	/// <summary>
	/// this class will handle the tabbed viewing stuff.
	/// </summary>
	public partial class ViewGui : System.Windows.Forms.Form
	{
		//private System.Windows.Forms.TabControl tabs;
		public static System.Int32 nextItem = 0;
		public System.Collections.ArrayList tabArray = new System.Collections.ArrayList();

        public class TabbedView
        {

            public Picture pic = null;
            private System.Boolean isCloned = false;
            private System.Windows.Forms.TabPage tabPage;

            public TabbedView()
            {
                MakeTabPage();
            }

            public System.Boolean IsCloned
            {
                get { return IsCloned; }
                set { IsCloned = value; }
            }

            public void MakeTabPage()
            {
                tabPage = new System.Windows.Forms.TabPage("n0 Pic");

                tabPage.Size = new Size( 100, 30 );
                //tabPage.AutoSize = true;

                tabPage.TabIndex = nextItem;

                //tabPage.Location = new Point( 0, -23 );
                tabPage.Anchor = AnchorStyles.Top;

                //System.Console.WriteLine( tabPages.Count + "!" );
                tabPage.Controls.AddRange(new PictureBox().TabControls);

                nextItem += 1;
                tabPage.PerformLayout();

                //this.tabPage.Invalidated += new InvalidateEventHandler(_OnThisInvalidated );
            }

            public void _OnThisInvalidated(object sender, System.EventArgs e)
            {
                this.TabPage.Invalidate();
            }

            public System.Windows.Forms.TabPage TabPage
            {
                get
                {
                    return (System.Windows.Forms.TabPage)tabPage;
                }
            }

            public class PictureBox : System.Windows.Forms.Control
            {
                private System.Windows.Forms.PictureBox pictureBox;
                private System.Windows.Forms.PictureBox clonedBox;
                private System.Windows.Forms.Control[] controls = null;

                //private TabbedView Tab;


                public PictureBox()
                {
                    //pictureBox
                    this.pictureBox = new System.Windows.Forms.PictureBox();
                    this.pictureBox.Location = this.PictureBoxLocation;
                    this.pictureBox.Size = this.PictureBoxSize;
                    this.pictureBox.BorderStyle = (BorderStyle.Fixed3D);
                    this.pictureBox.Dock = DockStyle.Fill;
                    this.pictureBox.BackColor = Color.Gray;
                    this.pictureBox.TabStop = false;
                    this.pictureBox.TabIndex = 0;
                    this.pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
                    this.pictureBox.BackgroundImage = null;
                    this.pictureBox.Name = String.Format("picture Box {0}", ViewGui.nextItem);
                    this.pictureBox.Anchor = AnchorStyles.Top;
                    this.pictureBox.AutoSize = false;
                    this.pictureBox.ClientSizeChanged += new EventHandler(this._OnPictureBoxChange);
                    this.pictureBox.AllowDrop = true;
                    this.pictureBox.DragDrop += new DragEventHandler(_OnDragDrop);
                    this.pictureBox.DragEnter += new DragEventHandler(_OnDragEnter);
                    this.pictureBox.DragLeave += new EventHandler(_OnDragLeave);
                    this.pictureBox.MouseWheel += new MouseEventHandler(_OnMouseWheelMove);

                    //clonedBox
                    this.clonedBox = new System.Windows.Forms.PictureBox();
                    //clonedBox.Location = new Point( 0, 0 );
                    clonedBox.Size = this.ClonedBoxSize;
                    clonedBox.BorderStyle = (BorderStyle.Fixed3D);
                    clonedBox.Dock = DockStyle.Fill;
                    clonedBox.BackColor = Color.Gray;
                    clonedBox.TabStop = false;
                    clonedBox.TabIndex = 1;
                    clonedBox.SizeMode = PictureBoxSizeMode.CenterImage;
                    clonedBox.BackgroundImage = null;
                    clonedBox.Name = "picture Box";
                    clonedBox.Anchor = AnchorStyles.Top;
                    clonedBox.AutoSize = false;
                    clonedBox.ClientSizeChanged += new EventHandler(this._OnPictureBoxChange);
                    clonedBox.Visible = false;


                    //add controls
                    controls = new System.Windows.Forms.Control[] { 
                        PictBox,
        		        ClonedBox,
                        //ViewGui.cloneClosebtn
        		    };


                    //( (System.ComponentModel.ISupportInitialize)(this.pictureBox.BeginInit() ) );
                }

                /*
                System.ComponentModel.ISupportInitialize PicInit( )
                {
                    ( (System.ComponentModel.ISupportInitialize)(this.pictureBox.BeginInit() ) );
                }*/

                public System.Windows.Forms.Control[] TabControls
                {
                    get
                    {
                        return this.controls;
                    }
                }

                public PhotoBoxSizeMode SizeMode
                {
                    get
                    {
                        return SizeMode;
                    }
                }
                public System.Windows.Forms.PictureBox PictBox
                {
                    get
                    {
                        return this.pictureBox;
                    }
                }

                public System.Windows.Forms.PictureBox ClonedBox
                {
                    get
                    {
                        return clonedBox;
                    }
                    set
                    {
                        clonedBox = value;
                    }
                }



                private void _OnDragEnter(object sender, DragEventArgs e)
                {
                    this.pictureBox.BackColor = Color.DodgerBlue;
                    e.Effect = DragDropEffects.All;
                }

                private void _OnDragLeave(object sender, EventArgs e)
                {
                    this.pictureBox.BackColor = Color.DarkGray;
                }

                protected void _OnPictureBoxChange(object sender, EventArgs e)
                {
                    if (Text != "No pic - Pict0 Vi3w3r!" || !(Text.Length < 30) || Text.EndsWith("*.*"))
                    {
                        this.pictureBox.Invalidate();
                    }
                }

                public System.Drawing.Size ClonedBoxSize
                {
                    get
                    {
                        return new Size((Convert.ToInt32(ImageShower.ViewGui.GetTabRect().Width / 2.2d)),
                            ImageShower.ViewGui.GetTabRect().Height - 100);
                    }
                }

                public System.Drawing.Size PictureBoxSize
                {
                    get
                    {
                        return new Size(ImageShower.ViewGui.GetTabRect().Width - 50,
                            ImageShower.ViewGui.GetTabRect().Height - 100);
                    }
                }

                public System.Drawing.Point PictureBoxLocation
                {
                    get
                    {
                        return new Point(ImageShower.ViewGui.TabLocation.X,
                            ImageShower.ViewGui.TabLocation.Y);
                    }
                }


                private void _OnDragDrop(object sender, DragEventArgs e)
                {
                    try
                    {

                        this.pictureBox.BackColor = Color.DarkGray;

                        if (!e.Data.GetDataPresent(DataFormats.FileDrop))
                        {
                            e.Effect = DragDropEffects.None;
                            return;
                        }
                        e.Effect = DragDropEffects.All;
                        ImageShower.ViewGui.picToDisplay = (System.String)((System.Array)e.Data.GetData(
                            DataFormats.FileDrop)).GetValue(0);

                        ImageShower.Picture picture = new ImageShower.Picture(picToDisplay);
                        //newPicEnum = picture.GetEnumerator();
                        //DisplayPics( );
                        this.Invalidate();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "ERROR!");
                    }

                }

                protected void _OnMouseWheelMove(object sender, MouseEventArgs e)
                {
                    //this.pictureBox.Visible = false;
                }

            }

            public enum PhotoBoxSizeMode
            {
                CenterImage = System.Windows.Forms.PictureBoxSizeMode.CenterImage,
                Normal = System.Windows.Forms.PictureBoxSizeMode.Normal,
                ScaleImage
            }
        }
	}
}
