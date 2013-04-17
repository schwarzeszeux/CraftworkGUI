using System;
using System.Collections.Generic;

namespace CraftworkGames.CraftworkGui.MonoGame
{
    public class TextureAtlas
    {
        public TextureAtlas(string textureName)
        {
            TextureName = textureName;
            _regionList = new List<TextureRegion>();
        }

        public TextureAtlas()
            : this(null)
        {
        }

        private List<TextureRegion> _regionList;

        public string TextureName { get; set; }

        public ITextureRegion AddRegion(string name, int x, int y, int width, int height)
        {
            var region = new TextureRegion(this, name, x, y, width, height);
            _regionList.Add(region);
            return region;
        }

        public void RemoveRegion(string name)
        {
            var textureRegion = GetRegion(name);
            _regionList.Remove(textureRegion as TextureRegion);
        }

        public ITextureRegion GetRegion(string textureRegionName)
        {
            return _regionList.Find(i => i.Name == textureRegionName);
        }
    }
}

