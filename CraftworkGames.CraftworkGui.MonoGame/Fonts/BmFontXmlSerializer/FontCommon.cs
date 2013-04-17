using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace CraftworkGames.CraftworkGui.MonoGame
{
	// ---- AngelCode BmFont XML serializer ----------------------
	// ---- By DeadlyDan @ deadlydan@gmail.com -------------------
	// ---- There's no license restrictions, use as you will. ----
	// ---- Credits to http://www.angelcode.com/ -----------------	
	[Serializable]
	public class FontCommon
	{
		[XmlAttribute ( "lineHeight" )]
		public Int32 LineHeight
		{
			get;
			set;
		}
		
		[XmlAttribute ( "base" )]
		public Int32 Base
		{
			get;
			set;
		}
		
		[XmlAttribute ( "scaleW" )]
		public Int32 ScaleW
		{
			get;
			set;
		}
		
		[XmlAttribute ( "scaleH" )]
		public Int32 ScaleH
		{
			get;
			set;
		}
		
		[XmlAttribute ( "pages" )]
		public Int32 Pages
		{
			get;
			set;
		}
		
		[XmlAttribute ( "packed" )]
		public Int32 Packed
		{
			get;
			set;
		}
		
		[XmlAttribute ( "alphaChnl" )]
		public Int32 AlphaChannel
		{
			get;
			set;
		}
		
		[XmlAttribute ( "redChnl" )]
		public Int32 RedChannel
		{
			get;
			set;
		}
		
		[XmlAttribute ( "greenChnl" )]
		public Int32 GreenChannel
		{
			get;
			set;
		}
		
		[XmlAttribute ( "blueChnl" )]
		public Int32 BlueChannel
		{
			get;
			set;
		}
	}	
}
