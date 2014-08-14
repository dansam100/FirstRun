/*
 * Created by SharpDevelop.
 * User: samuel
 * Date: 2/3/2007
 * Time: 3:00 AM
 */
using System.Reflection;
using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using NumberConverter;

namespace NumberConverter
{
	/// <summary>
	/// GUI for conversion class.
	/// </summary>
	/// 
	
	public class ConversionGui: Form
	{
		private Container components;
		
		//buttons  to push.
        private Button  solveButton;
        private Button  closeButton;
        
        //Labels for screen.
        private Label   selectLabel;
		private Label menuLabel;
		private Label baseToLabel;
		private Label baseFromLabel;
		
		//text boxes for input.
		private TextBox insertBaseFrom;
		private TextBox insertBaseTo;
		private TextBox insertNumber;
		private TextBox answerBox;
		 
		//Menu strips
		private MainMenu menu;
		private MenuItem menuFileItem;
		private MenuItem menuAboutItem;
		private MenuItem exitItem;
		
		public ConversionGui( bool varDummy )
		{
		}
		
		public ConversionGui()
		{
		    InitializeComponents();
		}
		
		public virtual void Dispose()
		{
			base.Dispose();
			components.Dispose();
		}

		public void InitializeComponents()
		{
		    components  = new Container();
		    solveButton = new Button();
		    closeButton = new Button();
		    
		    selectLabel   = new Label();
		    menuLabel     = new Label();
		    baseToLabel   = new Label();
		    baseFromLabel = new Label();
		    
		    insertNumber   = new TextBox();
		    insertBaseFrom = new TextBox();
		    answerBox      = new TextBox();
		    insertBaseTo   = new TextBox();
		    
		    menuFileItem = new MenuItem();
		    menuAboutItem = new MenuItem();
		    exitItem = new MenuItem();
		    
		    menu = new MainMenu();
		    
		    this.menuFileItem = menu.MenuItems.Add( "&File" );
		    this.menuAboutItem = menu.MenuItems.Add( "&About" );
		    
		    menuFileItem.MenuItems.AddRange( new System.Windows.Forms.MenuItem[] {
		       exitItem
		    } );
		    
		    //menu item FILE
		    menuFileItem.Text = "&File";
		    menuFileItem.Shortcut = Shortcut.AltF1;
		    
		    solveButton.Text     = "Solve";
		    solveButton.Click   += new EventHandler( _onSolveClick );
		    solveButton.Location = new Point( 200, 220 );
		    solveButton.TabIndex = 0;
		    solveButton.Size     = new Size( 73, 25 );
		    
		    
		    
		    closeButton.Text     = "Close";
		    closeButton.Click   += new EventHandler( _onCloseClick );
		    closeButton.Location = new Point( 300, 220 );
		    closeButton.TabIndex = 1;
		    closeButton.Size     = new Size( 73, 25 );
		    
		    menuLabel.Text        = "** PERFORM CONVERSIONS FROM BASE TO BASE **";
		    menuLabel.Font        = new Font( "Times New Roman", 12, FontStyle.Bold );
		    menuLabel.AutoSize    = true;
		    menuLabel.Size        = new Size( 20, 20 );
		    menuLabel.Location    = new Point( 25, 50);
		    menuLabel.BorderStyle = BorderStyle.None;
		    menuLabel.TabIndex    = 2;
		    
		    selectLabel.Text        = "Number to convert:";
		    selectLabel.Font        = new Font( "Comic Sans MS", 10, FontStyle.Bold );
		    selectLabel.BorderStyle = BorderStyle.None;
		    selectLabel.Size        = new Size( 45, 30 );
		    selectLabel.Location    = new Point( 20, 100 );
		    selectLabel.AutoSize    = true;
		    selectLabel.TabIndex    = 3;
		    
		    baseToLabel.Text        = "Base To:";
		    baseToLabel.Font        = new Font( "Comic Sans MS", 10, FontStyle.Bold );
		    baseToLabel.BorderStyle = BorderStyle.None;
		    baseToLabel.Size        = new Size( 45, 30 );
		    baseToLabel.Location    = new Point( 20, 185 );
		    baseToLabel.AutoSize    = true;
		    baseToLabel.TabIndex    = 4;
		    
		    baseFromLabel.Text        = "Base from: ";
		    baseFromLabel.Font        = new Font( "Comic Sans MS", 10, FontStyle.Bold );
		    baseFromLabel.BorderStyle = BorderStyle.None;
		    baseFromLabel.Size        = new Size( 45, 30 );
		    baseFromLabel.Location    = new Point( 20, 145 );
		    baseFromLabel.AutoSize    = true;
		    baseFromLabel.TabIndex    = 5;
		    
		    insertNumber.Text      = "";
		    insertNumber.Name      = "number";
		    insertNumber.Location  = new Point( 175, 105 );
		    insertNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
		    insertNumber.TabIndex  = 6;
		    
		    insertBaseFrom.Text      = "";
		    insertBaseFrom.Location  = new Point( 175, 145 );
		    insertBaseFrom.Name      = "baseFrom";
		    insertBaseFrom.TextAlign = HorizontalAlignment.Left;
		    insertBaseFrom.TabIndex  = 7;
		    
		    insertBaseTo.Text      = "";
		    insertBaseTo.Location  = new Point( 175, 185 );
		    insertBaseTo.Name      = "baseTo";
		    insertBaseTo.TextAlign = HorizontalAlignment.Left;
		    insertBaseTo.TabIndex  = 8;
		    
		    //not included yet
		    answerBox.Location  = new Point( 310, 145 );
		    answerBox.Name      = "Answer Box";
		    answerBox.TextAlign = HorizontalAlignment.Left;
		    answerBox.TabIndex  = 9;
		    answerBox.Text      = "";
		    
		     //menutItemExit
		    this.exitItem.Text = "&Exit";
		    this.exitItem.Index = 0;
		    this.exitItem.Shortcut = Shortcut.CtrlQ;
		    this.exitItem.Click += new EventHandler( _onCloseClick );
		    
		    //about box
		    this.menuAboutItem.Text = "About";
		    this.menuAboutItem.Click += new EventHandler( _onAboutClick );
		    this.menuAboutItem.Shortcut = Shortcut.F1;
		    this.menuAboutItem.Index = 1;
		    
		    Text       = "Number Base Converter";
		    ClientSize = new Size( 475, 250 );
		    this.BackColor = Color.SlateGray;
		    this.Menu = menu;
		    
		    Controls.Add( menuLabel );
		    Controls.Add( selectLabel );
		    Controls.Add( baseToLabel );
		    Controls.Add( baseFromLabel );
		    
		    Controls.Add( insertNumber );
		    Controls.Add( insertBaseFrom );
		    Controls.Add( insertBaseTo );
		    
		    Controls.Add( solveButton );
		    Controls.Add( closeButton );
		    //Controls.Add( answerBox );
		    
		}
		
		
		protected void _onSolveClick( object sender, EventArgs e )
		{
		    string baseFrom     = insertBaseFrom.Text;
		    string numToConvert = insertNumber.Text;
		    string baseTo       = insertBaseTo.Text;
		    CalculateIt calc    = new CalculateIt();
		    calc.PassReq( numToConvert, baseFrom, baseTo );
		}
		
		protected void _onCloseClick( object sender, EventArgs e )
		{
		    Application.Exit();
		}
		
		protected void _onAboutClick( object sender, EventArgs e )
		{
		    System.Windows.Forms.MessageBox.Show( "This program converts numbers between" +
		        " 2 and 16 which ever way you want it", "About" );
		}
		
		[STAThread]
		public static void Main( )
        {
            Application.Run( new ConversionGui() );
        }
	}
}
