using System;

namespace CraftworkGames.CraftworkGui.MonoGame
{
    public class GuiContent
    {
        public GuiContent(TextureAtlas textureAtlas, string fontFile, string fontTexture)
        {
            TextureAtlas = textureAtlas;
            FontFile = fontFile;
            FontTexture = fontTexture;
        }

        public TextureAtlas TextureAtlas { get; set; }
        public string FontFile { get; set; }
        public string FontTexture { get; set; }
    }
}

