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
	public class FontLoader
	{
        public static FontFile Load(Stream stream)
        {
            var deserializer = new XmlSerializer(typeof(FontFile));
            var file = (FontFile)deserializer.Deserialize(stream);
            return file;
        }
	}
}
