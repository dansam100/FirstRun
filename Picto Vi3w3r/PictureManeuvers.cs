/*
 * Created by SharpDevelop.
 * User: samuel
 * Date: 3/23/2007
 * Time: 1:31 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
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
	/// Handles user clicks
	/// </summary>
	public partial class ViewGui: System.Windows.Forms.Form
	{
	    System.Collections.IEnumerator newPicEnum;
	    ImageShower.Picture.PictureEnumerator enumExtend;
	    System.Drawing.Image pix;
	    static System.String picToDisplay = "";
	    System.Drawing.Rectangle rectangle;
	    System.Drawing.Image clonedPict;
	    System.String clonedPic = "";
        ImageShower.Picture.PictureEnumerator[] pictures = new ImageShower.Picture.PictureEnumerator[1];
	    
	    /// <summary>
	    /// get next picture
	    /// </summary>
	    /// <param name="sender">next button</param>
	    /// <param name="b"></param>
	    protected void _OnNextClick( object sender, EventArgs b )
		{
		    if( picture != null )
		    {
                
                while( pictures[currentTab].MoveNext() )
		        {
		            picToDisplay = ( System.String ) pictures[currentTab].Current;
                    int lastIndex = picToDisplay.LastIndexOf("\\") + 1;

                    System.Windows.Forms.TabPage thisTab =
                        (System.Windows.Forms.TabPage)tabs.Controls[currentTab];
                    thisTab.Text = picToDisplay.Substring(lastIndex, picToDisplay.Length - lastIndex);
                    
		            Text = "Pict0 Vi3w3r! - " + picToDisplay;
		            DisplayPics( );
		            System.Console.WriteLine( picToDisplay );
		            break;
		        }
		    }
		    else
		    {
		        return;
		    }
		    
		}
		
		//this too 
		
		protected void _OnPrevClick( object sender, EventArgs c )
		{
            
            enumExtend = (Picture.PictureEnumerator ) pictures[currentTab]; 
		    if( picture != null )
		    {
		        while( enumExtend.MovePrevious() )
		        {
		            picToDisplay = ( System.String ) pictures[currentTab].Current;
		            Text = "Pict0 Vi3w3r! - " + picToDisplay;
		            //System.Console.WriteLine( picToDisplay );
		            DisplayPics();
		            break;
		        }
		    }
		    else
		    {
		        return;
		    }
		}
		
		//really fix this hehe.
		
		public void DisplayPics( )
		{
	        
	        try{
	            pix = System.Drawing.Image.FromFile( picToDisplay );
	        }
	        catch
	        {
	            return;
	        }
            
            try
            {
                System.Windows.Forms.PictureBox picBox =
                (System.Windows.Forms.PictureBox)tabs.Controls[currentTab].Controls[0];

                System.Windows.Forms.PictureBox clonedBox =
                    (System.Windows.Forms.PictureBox)tabs.Controls[currentTab].Controls[1];

                if( picToDisplay.EndsWith( ".png") || picToDisplay.EndsWith(".gif") )
                {
                    LoadAnimatedPics( picBox );
                    return;
                }

                picBox.Image = null;

                rectangle = ScaleToFit(picBox.ClientRectangle, pix);
                //picBox.Image = Image.FromFile(picToDisplay);

                picBox.Image = new Bitmap(pix, rectangle.Width,
                rectangle.Height);

                //if (ImageShower.ViewGui.TabbedView._IsCloned)
                {
                    try
                    {
                        if (picToDisplay.EndsWith(".png") || picToDisplay.EndsWith(".gif"))
                        {
                            LoadAnimatedPics(clonedBox);
                            return;
                        }
                        clonedPict = System.Drawing.Image.FromFile(this.clonedPic);
                    }
                    catch
                    {
                        return;
                    }
                    clonedBox.Image = null;
                    rectangle = ScaleToFit(clonedBox.ClientRectangle, clonedPict);
                    clonedBox.Image = new Bitmap(clonedPict, rectangle.Width,
                    rectangle.Height);
                }
            }
            catch { return; }
		}

        private void LoadAnimatedPics(System.Windows.Forms.PictureBox picBox )
        {
            try
            {
                picBox.Image = System.Drawing.Image.FromFile( picToDisplay );
            }
            catch { return; }
        }
		
		private Rectangle ScaleToFit(
            Rectangle targetArea, System.Drawing.Image img)
        {
            Rectangle r = new Rectangle(
                targetArea.Location, targetArea.Size );

        // Determine best fit: width or height
        if (r.Height * img.Width > r.Width * img.Height)
        {
        // Use width, determine height
            r.Height = r.Width * img.Height / img.Width;
            r.Y += (targetArea.Height - r.Height) / 2;
        }
        else
        {
            // Use height, determine width
            r.Width = r.Height * img.Width / img.Height;
            r.X += (targetArea.Width - r.Width) / 2;
        }

            return r;
        }
        
        //fix this too
        protected void _OnCloneClick( object sender, EventArgs e )
        {
           // TabbedView._IsCloned = true;
            System.Windows.Forms.PictureBox clonedBox =
                (System.Windows.Forms.PictureBox)tabs.Controls[currentTab].Controls[1];

	        clonedBox.Visible = true;
            cloneClosebtn.Visible = true;
            cloneClosebtn.Enabled = true;
	        this.ClientSize = ClientSize;
            this._OnCloneOpen(clonedBox, e);
        }
        
        //must fix this method after the end
        protected void _OnCloneRemove( object sender, EventArgs e )
	    {
	        
	        //TabbedView._IsCloned = false;
            System.Windows.Forms.PictureBox clonedBox =
                (System.Windows.Forms.PictureBox)tabs.Controls[currentTab].Controls[1];

	        clonedBox.Visible = false;
	        this.ClientSize = ClientSize;
	        menuRemoveClone.Enabled = false;
	        //menuItemClone.Enabled = true;
	        cloneClosebtn.Visible = false;
	        cloneClosebtn.Enabled = false;
	        Text = "Pict0 Vi3w3r! - "; //+ picToDisplay;
	    }   
	    
    }
}
