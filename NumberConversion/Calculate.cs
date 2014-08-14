/*
 * Created by SharpDevelop.
 * User: samuel
 * Date: 2/4/2007
 * Time: 12:08 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Windows.Forms;
using NumberConverter;
using System.ComponentModel;

namespace NumberConverter {


    public partial class CalculateIt {
    
        string convertThis;
        
    	public CalculateIt( string numToConvert, string baseFrom, string baseTo )
    	{
    		convertThis = numToConvert;
            
            try
            {
                int fromBase = int.Parse( baseFrom );
                int toBase = int.Parse( baseTo );
                //int ans1 = ChangeToDecimal( convertThis, fromBase );
                //string ans2 = ChangeFromTen( ans1, toBase );
                string result = ChangeFromTen( ChangeToDecimal( convertThis, fromBase ), toBase );
                
                //ConversionGui display = new ConversionGui( true );
                //display.answerBox.Text = result;
                //display.Restart();
                
                MessageBox.Show( "The conversion of " + numToConvert +" from base " +  baseFrom + " to base " + baseTo + " is: " + result, "Result" );
            }
            catch
            {
                 MessageBox.Show( "TRy aGaIn!!\n\n" +
                    "Please enter a valid base you want to convert to: ex: 10 or 12", "Error" );   
            }       
        	
    	}
    	
    	
    	//properties to get values just in case it's being am using it in another program.	
    	
    	public string ConvertThis
    	{
    		get{ return convertThis; }
    	}
    
        /// <summary>
        /// Change from decimal to any base
        /// </summary>
        /// <param name="number">number to convert</param>
        /// <param name="baseIn">base number to convert to</param>
        /// <returns> string containing converted number</returns>
    	public string ChangeFromTen( int number, int baseIn )
    	{
    		string result = "";
    		string remainder;
    		string finResult = "";
    		while( number > 1 )
    		{
                remainder = ( number % baseIn ).ToString();
                switch( remainder )
                {
                    case "10":
                            remainder = "A";
                            break;
                    case "11":
                            remainder = "B";
                            break;
                    case "12":
                            remainder = "C";
                            break;
                    case "13":
                            remainder = "D";
                            break;
                    case "14":
                            remainder = "E";
                            break;
                    case "15":
                            remainder = "F";
                            break;
                }
                
                result += ( remainder ).ToString();
                number = number / baseIn;
            }
            result += number.ToString();
            for( int i = result.Length; i > 0; i-- )
            {
                finResult += ( result[i-1] );
            }
            return finResult;
        }
        
        /// <summary>
        /// Change from any other base to decimal
        /// </summary>
        /// <param name="numberLen">number to convert</param>
        /// <param name="baseIn">base the number is already in</param>
        /// <returns>an int of the result in base 10</returns>
        public int ChangeToDecimal( string numberLen, int baseIn )
        {
            double result = 0;
            int c, i;
            for( i = numberLen.Length, c = 0; i > 0; i--, c++ )
            {    
                string x = numberLen[i-1].ToString();
                switch( x )
                {
                    case "A":
                            x = "10";
                            break;
                    case "B":
                            x = "11";
                            break;
                    case "C":
                            x = "12";
                            break;
                    case "D":
                            x = "13";
                            break;
                    case "E":
                            x = "14";
                            break;
                    case "F":
                            x = "15";
                            break;
                }    
                result += ( int.Parse( x.ToString() ) * ( Math.Pow( (double)baseIn, (double)c ) ) );
            }
            return (int)result;
        }  
    }
}

