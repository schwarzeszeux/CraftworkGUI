#region License
/*
MIT License
Copyright © 2013 Craftwork Games

All rights reserved.

Authors:
Dylan Wilson

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
#endregion License

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

