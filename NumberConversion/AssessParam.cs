/*
 * Created by SharpDevelop.
 * User: samuel
 * Date: 2/3/2007
 * Time: 10:18 PM

 */

using System;
using System.Windows.Forms;

namespace NumberConverter
{
	/// <summary>
	/// Assesses parameters for errors [error checking]
	/// </summary>
	public partial class CalculateIt
	{
	    static int flag;
	    
	    public CalculateIt() 
	    {
	    }
	    
	    public static int Flag
	    {
	        get { return flag; }
	        set { flag = value; }
	    }
		
		/// <summary>
		/// checks to see if parameter are entered and they are of the right values.
		/// </summary>
		/// <param name="numConvert">number to convert</param>
		/// <param name="baseFrom">the present base of number to convert</param>
		/// <param name="baseTo">base you want to convert to</param>
		public void PassReq( string numConvert, string baseFrom, string baseTo )
		{
		    Flag = 0;
            numConvert = numConvert.Trim();
            baseFrom = baseFrom.Trim();
            baseTo = baseTo.Trim();
            string logger = "";
            
             if( IsEmpty( numConvert ) )
             {
                MessageBox.Show( "Number to convert box is empty. Fill it!", "Error" );
                Flag++;
             }
             else
             {
                if( CheckBases( baseFrom, baseTo ) )
                {
          
          		    if( Flag == 1 )
        		    {
                            //MessageBox.Show( "TRy aGaIn!! \n\n" +
                              //  "Please enter a valid number to Convert" );
                              Flag = 0;
                            //ConversionGui restart = new ConversionGui( true );
                            //restart.Restart();
                    }
                    else
                    { 
        				numConvert = numConvert.ToUpper();
        				
        				//additional error checking. Don't need now
        				/*
        				for( char a = 'G'; a <= 'Z'; a++ )
        				{
        					for( int i = 0; i < numConvert.Length; i++ )
        					{
        						if( numConvert[i] == a )
        						{
        							Flag++;
        							MessageBox.Show( a + " cannot be entered \n\n It is an invalid character.", "Error" );
        							logger = "errorfound";
        						}
        					}
        				} */
        				
        				//checks to make sure all characters in the number entered are supported
    					for( int i = 0; i < numConvert.Length; i++ )
    					{
    						if( !IsInteger( numConvert[i].ToString() ) )
    						{
    						    if( !IsValidChar( numConvert[i] ) )
    						    {
    						        Flag++;
    						        MessageBox.Show( numConvert + " cannot be entered.\n\nIt has an invalid character.\n\nEnter the" +
    						            " the appropriate number, please", "Error" );
    						        logger = "errorfound";
    						    }
    						}
    					}
        				if( logger == "" )
        				{
        				    CalculateIt convert = new CalculateIt( numConvert, baseFrom, baseTo );
        				}
        			}
        		}
        	}
		}
		
		/// <summary>
		/// verifies if string is an integer.
		/// </summary>
		/// <param name="theValue">string to be parsed to int and checked</param>
		/// <returns>true if string is an integer</returns>
        public static bool IsInteger( string theValue)
        {
            try
            {
                Convert.ToInt32( theValue );
                return true;
            } 
            catch 
            {
                return false;
            }
	    }
	    
	    /// <summary>
	    /// checks if all characters are supported
	    /// </summary>
	    /// <param name="theValue">character to be checked if belongs to range</param>
	    /// <returns>true if character is valid</returns>
	    public static bool IsValidChar( char theValue )
        {
            for( char a = 'A'; a <= 'F'; a++ )
		    {
			    if( theValue == a )
			    {
                    return true;
                }
            }
            return false;        
        }
        
        /// <summary>
        /// Checks if input is empty
        /// </summary>
        /// <param name="theValue">string to be checked</param>
        /// <returns>true if string is empty</returns>
        public static bool IsEmpty( string theValue )
        {
            if( theValue.Trim() == "" )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        /// <summary>
        /// verifies that the bases entered are entered and in the right format and range
        /// </summary>
        /// <param name="baseFrom">base the number is already in</param>
        /// <param name="baseTo">base being converted to</param>
        /// <returns>true if bases are entered right</returns>
        public bool CheckBases( string baseFrom, string baseTo )
        {
            if( IsEmpty( baseTo ) || IsEmpty( baseFrom ) )
            {
                MessageBox.Show( "One or all of the bases have not been filled. Fill it!", "Error" );
                Flag++;
                return false;
            }
            if( IsInteger( baseFrom ) && IsInteger( baseTo ) )
            {
                if( !( int.Parse( baseFrom ) > 1 ) || !( int.Parse( baseFrom ) <= 16 ) )
                {
                    MessageBox.Show( "Base from is out of range. \n Please enter a base from 2 to 16 for each.", "Error" );
                    Flag++;
                    return false;
                }
                else if( !( int.Parse( baseTo ) > 1 ) || !( int.Parse( baseTo ) <= 16 ) )
                {
                    MessageBox.Show( "Base To is out of range. \n Please enter a base from 2 to 16 for each.", "Error" );
                    Flag++;
                    return false;
                }
            }
            else
            {
                MessageBox.Show( "Enter a valid number as a base, please!", "Error" );
                Flag++;
                return false;
            }
            return true;
        }
      
    }        
}
