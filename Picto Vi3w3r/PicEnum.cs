/*
 * Created by SharpDevelop.
 * User: samuel
 * Date: 3/22/2007
 * Time: 7:19 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using ImageShower;

namespace ImageShower
{
	/// <summary>
	/// This class handles all picture maneuvers
	/// </summary>
	public class Picture : System.Collections.IEnumerable
	{
		public System.String _PicturePath = null;
		
		public Picture( System.String pictureName )
		{
		    _PicturePath = pictureName;
		    
		}
		
		public class PictureEnumerator : System.Collections.IEnumerator
		{
		    private ImageShower.Picture pictures;
		    private System.String _Dir = null;
		    private System.String[] _Pictures = null;
		    private System.Int32 _FileIndex = -1;
		    public PictureEnumerator( Picture pics )
		    {
		        pictures = pics;
		        System.Int32 index = pictures._PicturePath.LastIndexOf( "\\" );
		        _Dir = pictures._PicturePath.Substring( 0, index );
		        if( _Pictures == null || _Pictures.Length == 0 )
		         {
		            
		            if(_Dir != null || _Dir != "" )
		            {
		                _Pictures = System.IO.Directory.GetFiles( _Dir,
	                    "*.jpg" );
		            }
		        }
		    }
		    
		    public bool MoveNext()
		    {
		        _FileIndex += 1;
		        
		        if( _Pictures != null || _Pictures.Length != 0 )
		        {
		            
		            if( _FileIndex >= _Pictures.Length )
                    {
                        _FileIndex = 0;
                    }
	                if( _FileIndex >= _Pictures.Length )
	                {
	                    return false;
	                }
		        }
		        
		        return true;
		    }
		    
		    public bool MovePrevious()
		    {
		        _FileIndex -= 1;
                
    		    if( _Pictures != null || _Pictures.Length != 0 )
    		    {
    		        if( _FileIndex < 0 )
                    {
                        _FileIndex = _Pictures.Length - 1;
                    }
                    if( _FileIndex < 0 )
                    {
                        return false;
                    }
               }     
    		        return true;
		    }
		    
		    public System.Object Current
		    {
		        get
		        {
    		        if( _FileIndex < 0 || _FileIndex >= _Pictures.Length )
	                {
	                    return null;
	                }
	                return _Pictures[_FileIndex];
		        }
		    }
		    
		    public void Reset()
		    {
		        _FileIndex = -1;
		        _Dir = null;
		        _Pictures = null; 
		    }
		}
		
		public System.Collections.IEnumerator GetEnumerator()
		{
		    return new PictureEnumerator( this );
		}
	}
}
