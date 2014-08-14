/*
 * Created by SharpDevelop.
 * User: samuel
 * Date: 2/19/2007
 * Time: 6:01 PM
 * 

 */

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Windows.Forms;

namespace ImageShower
{
	/// <summary>
	/// Creates Gui for vi3wing 7h3 pics.
	/// </summary>
	public partial class ViewGui:Form
	{
		private System.ComponentModel.IContainer components;
		private MainMenu menu1;
		private MenuItem menuItemFile;
		private MenuItem menuItemOpen;
		private MenuItem menuItemExit;
		private MenuItem menuItemView;
        private MenuItem menuNewTabView;
		
		private MenuItem menuItemClone;
		public  static System.Windows.Forms.Button cloneClosebtn;
		private Button nextButton;
		private Button prevButton;
		private Button closeButton;
		private MenuItem menuRemoveClone;
		private TextBox tBox;
		private TableLayoutPanel panel;
		private OpenFileDialog openFileDialog1;

		public System.Windows.Forms.TabControl tabs;
		System.Int32 currentTab = 0;
        static System.Drawing.Size FormTab = new Size(0,0);
        static System.Drawing.Point TabLocation = new Point(0, 0);

		ImageShower.Picture picture = null;
        ImageShower.Picture pictureCloned = null;

	
		public ViewGui()
		{
		    MakeComponents();
		}

        public void MakeComponents()
        {
            this.components = new Container();
            menu1 = new MainMenu();
            this.nextButton = new Button();
            this.prevButton = new Button();
            this.closeButton = new Button();
            cloneClosebtn = new Button();
            this.tBox = new TextBox();
            this.panel = new TableLayoutPanel();
            this.menuItemFile = new MenuItem();
            this.menuItemOpen = new MenuItem();
            this.menuItemExit = new MenuItem();
            this.menuItemView = new MenuItem();
            this.menuItemClone = new MenuItem();
            this.menuRemoveClone = new MenuItem();
            this.menuNewTabView = new MenuItem();
            this.openFileDialog1 = new OpenFileDialog();
            tabs = new System.Windows.Forms.TabControl();

            //make tablelayoutpanel.
            //_MakePanel();

            //menuItemFile
            this.menuItemFile = menu1.MenuItems.Add("&File");

            //View
            this.menuItemView = menu1.MenuItems.Add("&View");

            //add File Controls
            menuItemFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
		        menuItemOpen,
                menuNewTabView,
                menuItemExit
		    });

            //Add view controls

            menuItemView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
		        menuItemClone, 
                menuRemoveClone 
		    });

            //menuItemOpen

            this.menuItemOpen.Text = "&Open...";
            this.menuItemOpen.Index = 0;
            this.menuItemOpen.Shortcut = Shortcut.CtrlO;
            this.menuItemOpen.Click += new EventHandler(_OnOpenClick);

            //menuNewTabView

            this.menuNewTabView.Text = "New &Tab";
            this.menuNewTabView.Index = 1;
            this.menuNewTabView.Shortcut = Shortcut.CtrlT;
            this.menuNewTabView.Click += new EventHandler(_OnNewTabClick);

            //menutItemExit

            this.menuItemExit.Text = "E&xit";
            this.menuItemExit.Index = 2;
            this.menuItemExit.Shortcut = Shortcut.CtrlQ;
            this.menuItemExit.Click += new EventHandler(_OnCloseClick);


            //menuItemClone

            this.menuItemClone.Text = "Clo&ne Against...";
            this.menuItemClone.Index = 0;
            this.menuItemClone.Shortcut = Shortcut.CtrlN;
            this.menuItemClone.Click += new EventHandler(_OnCloneClick);
            this.menuItemClone.Enabled = false;

            //removeClone

            this.menuRemoveClone.Text = "&Remove Clone...";
            this.menuRemoveClone.Index = 1;
            this.menuRemoveClone.Shortcut = Shortcut.CtrlR;
            this.menuRemoveClone.Click += new EventHandler(_OnCloneRemove);
            this.menuRemoveClone.Enabled = false;


            //nextButton

            //this.nextButton.Location = new Point( 380, 590 );
            this.nextButton.Size = new Size(35, 20);
            this.nextButton.TabIndex = 0;
            this.nextButton.AutoSize = true;
            this.nextButton.Anchor = AnchorStyles.Bottom;
            this.nextButton.Font = new Font("Comic Sans Ms", 9, FontStyle.Bold);
            this.nextButton.FlatStyle = FlatStyle.Standard;
            this.nextButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.nextButton.Name = "next button";
            this.nextButton.Text = "&N3xt >>";
            this.nextButton.BackColor = Color.SlateGray;
            this.nextButton.Click += new EventHandler(_OnNextClick);
            this.nextButton.MouseEnter += new EventHandler(_OnMouseOverNext);
            this.nextButton.MouseLeave += new EventHandler(_OnMouseLeaveNext);

            //prevButton

            //this.prevButton.Location = new Point( 260, 590);
            this.prevButton.Size = new Size(35, 20);
            this.prevButton.TabIndex = 1;
            this.prevButton.AutoSize = true;
            this.prevButton.Anchor = AnchorStyles.Bottom;
            this.prevButton.FlatStyle = FlatStyle.Standard;

            this.prevButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.prevButton.Font = new Font("Comic Sans Ms", 9, FontStyle.Bold);
            this.prevButton.Name = "prevButton";
            this.prevButton.Text = "&<<Pr3vi0us";
            this.prevButton.BackColor = Color.SlateGray;
            this.prevButton.Click += new EventHandler(_OnPrevClick);
            this.prevButton.MouseEnter += new EventHandler(_OnMouseOverPrev);
            this.prevButton.MouseLeave += new EventHandler(_OnMouseLeavePrev);

            //closeButton.
            this.closeButton.Location = new Point(650, 250);
            this.closeButton.Size = new Size(35, 20);
            this.closeButton.AutoSize = true;
            this.closeButton.TabIndex = 2;
            this.closeButton.FlatStyle = FlatStyle.Standard;
            this.closeButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.closeButton.Anchor = AnchorStyles.Bottom;
            this.closeButton.Name = "closeButton";
            this.closeButton.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            this.closeButton.Text = "&Close";
            this.closeButton.BackColor = Color.SlateGray;
            this.closeButton.Click += new EventHandler(_OnCloseClick);
            this.closeButton.MouseEnter += new EventHandler(_OnMouseOverClose);
            this.closeButton.MouseLeave += new EventHandler(_OnMouseLeaveClose);

            //close clone
            cloneClosebtn.MouseEnter += new EventHandler(_OnMouseOverCloneBtn);
            cloneClosebtn.MouseLeave += new EventHandler(_OnMouseLeaveCloneBtn);
            //this.cloneClosebtn.Location = new Point( 600, 20 );
            cloneClosebtn.Font = new Font("Comic Sans MS", 7, FontStyle.Bold);
            cloneClosebtn.BackColor = Color.White;
            cloneClosebtn.Anchor = AnchorStyles.Right;
            cloneClosebtn.Text = "x";
            cloneClosebtn.Name = "CloneCloseBtn";
            cloneClosebtn.Click += new EventHandler(_OnCloneRemove);
            cloneClosebtn.Size = new Size(15, 15);
            cloneClosebtn.AutoSize = false;
            cloneClosebtn.FlatStyle = FlatStyle.Standard;
            cloneClosebtn.TabIndex = 10;

            cloneClosebtn.Enabled = false;
            cloneClosebtn.Visible = false;

            //tabs
            this.tabs.SuspendLayout();
            tabs.Location = new System.Drawing.Point(0, 0);
            this.tabs.Size = new System.Drawing.Size(Width - 100, ClientSize.Height - 100);
            this.tabs.Appearance = TabAppearance.Normal;
            this.tabs.Dock = DockStyle.Fill;
            
            //tabs.Size =  new System.Drawing.Size(400, 400 );
            tabs.TabPages.Add(new ImageShower.ViewGui.TabbedView().TabPage);

            tabs.Name = "tabs";
            tabs.MouseClick += new MouseEventHandler(tabs_MouseClick);
            tabs.Selected += new TabControlEventHandler(_OnTabSelect);
            this.tabs.DoubleClick += new EventHandler(tabs_DoubleClick);

            //testing stuff 
            System.Console.WriteLine(tabs.DisplayRectangle.Height + "\n" + tabs.DisplayRectangle.Width);
            System.Console.WriteLine(tabs.Location.X + "\n" + tabs.DisplayRectangle.Location.Y);
            System.Console.WriteLine(tabs.DisplayRectangle.Height + "\n" + tabs.DisplayRectangle.Width);
            //end testing

            tabs.SelectedIndex = ViewGui.nextItem;
            tabs.TabIndex = nextItem;
            tabs.Anchor = AnchorStyles.Bottom;
            tabs.Dock = DockStyle.Top;
            this.tabs.PerformLayout();
            FormTab = tabs.Size;
            TabLocation = tabs.Location;

            //client
            ClientSize = new Size(800, 800);
            this.Font = new Font("Times New Roman", 12);
            this.Text = "No pic - Pict0 Vi3w3r!";
            this.Location = new Point(100, 80);
            this.Name = "Pict0 Vi3w3r console";
            this.ResizeRedraw = true;
            this.AutoSize = false;
            this.Icon = null;
            this.MinimumSize = new Size(600, 600);
            this.ClientSizeChanged += new EventHandler(_OnClientSizeChange);
            this.Menu = menu1;
            this.PerformLayout();
            this.ResumeLayout();

            //invoke IntializeComponents method.
            this.InitializeComponents();
        }

        void tabs_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Middle:
                    
                    System.Windows.Forms.TabControl page =
                        (System.Windows.Forms.TabControl)sender;
                    
                    tabs.Controls[page.TabIndex].Dispose();
                    
                    //
                    System.Console.WriteLine(page.TabIndex);
                    //
                    this.RemoveTabPicture( page.TabIndex );
                    break;

                default:
                    break;

            }
        }
		
		public virtual void Dispose()
		{
			base.Dispose();
			components.Dispose();
		}
		
		//fix
		public void InitializeComponents()
		{
		    Control[] controls = new Control[] { 
		        closeButton, 
                prevButton, 
                nextButton, 
                tabs,
                cloneClosebtn
        };

		    Controls.AddRange( controls );
		    
		}
		
		public delegate void ThreadStart();
		
		//System.Threading.Thread runThis = new System.Threading.Thread( 
		//    System.Threading.ThreadStart( Animate ) );
		/*
		protected void Animate( )
		{
		    
	        System.Drawing.Image gif = System.Drawing.Image.FromFile( picToDisplay );
	        pixt = System.Drawing.Image.FromFile( picToDisplay ); 
	        System.IO.MemoryStream ms = null;
		    try{
    		    while( next < pix.FrameDimensionsList.Length )
    		    {
        		    ms = new System.IO.MemoryStream();
        		    System.Guid imgGuid = pix.FrameDimensionsList[0];
        		    framed = new FrameDimension( imgGuid );
        		    pixt.SelectActiveFrame( framed, next );
        		    pixt.Save( ms, ImageFormat.Gif );
        		    gif = Image.FromStream( ms );
        		    rectangle = ScaleToFit( this.pictureBox.ClientRectangle, gif );
        		    this.pictureBox.Image = new Bitmap( gif, rectangle.Width, rectangle.Height );
        		    next += 1;
        		}
        		next = 0;
            }
    		catch 
    		{
    		    ms.Close();
    		}
		}
		*/
		
		public void _MakePanel()
		{
		    this.panel.SuspendLayout();
        	
        	
		    //table layout
		    
		    this.panel.ColumnCount = 3;
		    this.panel.ColumnStyles.Add( new ColumnStyle( SizeType.Percent, 15F ) );
		    this.panel.ColumnStyles.Add( new ColumnStyle( SizeType.Percent, 30F ) );
		    this.panel.ColumnStyles.Add( new ColumnStyle( SizeType.Percent, 30F ) );
		    this.panel.ColumnStyles.Add( new ColumnStyle( SizeType.Percent, 15F ) );
		    
		    
		    this.panel.RowCount = 4;
		    this.panel.RowStyles.Add( new RowStyle( SizeType.Percent, 10F ) );
		    this.panel.RowStyles.Add( new RowStyle( SizeType.Percent, 70F ) );
		    this.panel.RowStyles.Add( new RowStyle( SizeType.Percent, 10F ) );
		    this.panel.RowStyles.Add( new RowStyle( SizeType.Percent, 10F ) );
		    
		    //this.panel.Controls.Add( (System.Windows.Forms.TabControl)TabbedView.tabs, 1, 1 );
		    this.panel.Controls.Add( this.closeButton, 2, 3 );
		    //this.panel.Controls.Add( this.tabs, 0, 0 );
		    
		    //this.panel.Controls.Add( this.nextButton, 1, 2 );
		    //this.panel.Controls.Add( this.prevButton, 1, 2 );
		    
		    this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
		    this.panel.Location = new Point(50, 50);
		    this.panel.Size = new Size( 800,650 );
		    panel.BorderStyle = (System.Windows.Forms.BorderStyle.Fixed3D );
		    
		    panel.ResumeLayout();
		    panel.PerformLayout();
        }

        #region Effects...
        protected void _OnMouseOverNext( object sender, EventArgs d )
		{
		    nextButton.BackColor = Color.Blue;
		}
		
		protected void _OnMouseLeaveNext( object sender, EventArgs d )
		{
		    nextButton.BackColor = Color.SlateGray;
		}
		
		protected void _OnMouseOverPrev( object sender, EventArgs e )
		{
		    prevButton.BackColor = Color.Goldenrod;
		}
		
		protected void _OnMouseLeavePrev( object sender, EventArgs e )
		{
		    prevButton.BackColor = Color.SlateGray;
		}
		
		protected void _OnMouseOverCloneBtn( object sender, EventArgs e )
        {
            cloneClosebtn.BackColor = Color.Red;
        }

        protected void _OnMouseLeaveCloneBtn( object sender, EventArgs e )
        {
            cloneClosebtn.BackColor = Color.White;
        }

        protected void _OnMouseLeaveClose(object sender, EventArgs f)
        {
            closeButton.BackColor = Color.SlateGray;
        }

        protected void _OnMouseOverClose(object sender, EventArgs g)
        {
            closeButton.BackColor = Color.Red;
        }
        #endregion
		
		//rofl this tooooooooooooo
		protected void _OnClientSizeChange( System.Object sender, System.EventArgs e )
		{
		    int xSize = this.Width;
		    int ySize = this.Height;
            System.Windows.Forms.PictureBox pictureBox = 
                (System.Windows.Forms.PictureBox)tabs.Controls[currentTab].Controls[0];
		   // if( !IsCloned )
		    {
		        this.closeButton.Location = new Point( xSize - 100, ySize - 130 );
                this.prevButton.Location = new Point( ( xSize / 2 ) - 80, ySize - 150);
                this.nextButton.Location = new Point( ( xSize / 2) + 10, ySize - 150);

		        this.tabs.Size = new Size( (xSize) -100 , (ySize)- 200 );
                FormTab = tabs.Size;
                TabLocation = tabs.Location;

                //change picturebox sizes
                for (int i = 0; i < tabs.TabCount; i++)
                {
                    pictureBox = (System.Windows.Forms.PictureBox)tabs.Controls[i].Controls[0];
                    pictureBox.Size =
                        new Size(tabs.Width - 50, tabs.Height - 100);

                    //change picturebox locations
                    pictureBox.Location = new Point(20, 20);
                }
		    }
		    //else
		    {

                this.closeButton.Location = new Point(xSize - 100, ySize - 130);
                this.prevButton.Location = new Point((xSize / 2) - 80, ySize - 150);
                this.nextButton.Location = new Point((xSize / 2) + 10, ySize - 150);

                this.tabs.Size = new Size((xSize) - 100, (ySize) - 200);
               
                System.Windows.Forms.PictureBox clonedBox =
                    (System.Windows.Forms.PictureBox)tabs.Controls[currentTab].Controls[1];

                //change both pictureboxs' size
                //pictureBox
                pictureBox.Size =
                    new Size( Convert.ToInt32( tabs.Width / 2.2d ), tabs.Height - 100);
                //clonedBox
                clonedBox.Size = pictureBox.Size;

                //change both pictureboxs' location
                //pictureBox
                pictureBox.Location = new Point(20, 20);
                //clonedBox
                clonedBox.Location = new Point(pictureBox.Location.X + pictureBox.Width + 10,
                    pictureBox.Location.Y );

                //closebutton for clone
                cloneClosebtn.Location = new Point(clonedBox.Location.X + clonedBox.Width + 10
                    , clonedBox.Location.Y + 5);
                cloneClosebtn.Invalidate();
		    }
		    
		}
		
		public static System.Drawing.Size GetTabRect()
		{
            return FormTab;
		}
		
		//u have to do this too
		private void _OnOpenClick(object sender, EventArgs e)
        {

            openFileDialog1.InitialDirectory = @"C:\Documents and Settings\my documents\my pictures";
            openFileDialog1.Title = "Select a File";
            openFileDialog1.Filter = "Image Files|*.bmp;*.jpg; *.jpeg;*.png; *.gif; *.tif";
            openFileDialog1.FilterIndex = 1;
            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
            { 
            
               picToDisplay = @openFileDialog1.FileName;
               CreateTabPicture( new ImageShower.Picture(picToDisplay).GetEnumerator() ); 
               tabArray.Add( picture = new ImageShower.Picture( picToDisplay ) );

               Console.WriteLine(currentTab);
               //newPicEnum = ((ImageShower.Picture)tabArray[currentTab]).GetEnumerator();
               this.DisplayPics( );
               Text = "Pict0 Vi3w3r! - " + picToDisplay;
               this.menuItemClone.Enabled = true;

               //runThis.Start();                
            }
            else
               { picToDisplay = ""; }
        }

        public void CreateTabPicture( System.Collections.IEnumerator picEnum )
        {
            //Picture.PictureEnumerator[] tempictures = new ImageShower.Picture.PictureEnumerator[currentTab+1];
            Picture.PictureEnumerator[] tempictures = new ImageShower.Picture.PictureEnumerator[tabs.TabCount];
            for(int i = 0; i < pictures.Length; i++)
            {
                tempictures[i] = pictures[i];
            }
            tempictures[currentTab] = (ImageShower.Picture.PictureEnumerator)picEnum;
            pictures = new ImageShower.Picture.PictureEnumerator[tempictures.Length];
            for(int i = 0; i < tempictures.Length; i++ )
            {
                pictures[i] = tempictures[i];
            }
            
        }

        public void RemoveTabPicture(System.Int32 index)
        {
            //Picture.PictureEnumerator[] tempictures = new ImageShower.Picture.PictureEnumerator[currentTab + 1];
            ImageShower.Picture.PictureEnumerator[] tempictures = new ImageShower.Picture.PictureEnumerator[tabs.TabCount];
            for (int i = 0; i < pictures.Length; i++)
            {
                while(i != index)
                {
                    tempictures[i] = pictures[i];
                }
            }
            
            pictures = tempictures;
        }

        #region TabStuff...
        private void _OnTabSelect(object sender, TabControlEventArgs e)
        {
            currentTab = e.TabPageIndex;
            Text = "Pict0 Vi3w3r! - " + picToDisplay;
        }

        void tabs_DoubleClick(object sender, EventArgs e)
        {
            FormTab = tabs.Size;
            tabs.TabPages.Add(new ViewGui.TabbedView().TabPage);
            this.ClientSize = ClientSize;
        }

        protected void _OnNewTabClick( object sender, EventArgs e)
        {
            FormTab = tabs.Size;
            tabs.Controls.Add(new TabbedView().TabPage);
            this.ClientSize = ClientSize;
        }
        #endregion

       
        #region ClonePictures...

        //rmr to fix this crap too
        private void _OnCloneOpen( object sender, EventArgs e )
        {
            System.Windows.Forms.PictureBox clonedBox = 
                (System.Windows.Forms.PictureBox)sender;
               

            openFileDialog1.InitialDirectory = @"C:\Documents and Settings\my documents\my pictures";
            openFileDialog1.Title = "Select a File";
            openFileDialog1.Filter = "Image Files|*.bmp;*.jpg; *.jpeg;*.png; *.gif; *.tif";
            openFileDialog1.FilterIndex = 1;
            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                clonedPic = @openFileDialog1.FileName;
                //pictureCloned = new ImageShower.Picture(clonedPic);
                this.DisplayPics();
                Text = "Cloned View";
                clonedBox.Invalidate();
                menuRemoveClone.Enabled = true;
                //menuItemClone.Enabled = false;
                cloneClosebtn.Enabled = true;
                cloneClosebtn.Visible = true;
            }
            else
            {
                clonedPic = "";
                //TabbedView._IsCloned = false;
                this.ClientSize = ClientSize;
            }
        }
        #endregion


    }
}
