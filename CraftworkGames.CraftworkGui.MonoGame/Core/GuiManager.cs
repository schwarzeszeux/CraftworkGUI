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
    public abstract class GuiManager : IDrawManager, IUpdateManager
    {
        public GuiManager()
        {
            Layers = new List<GuiLayer>();
        }

        public TextureAtlas TextureAtlas { get; private set; }
        public List<GuiLayer> Layers { get; private set; }

        public void LoadContent(GuiContent guiContent)
        {
            TextureAtlas = guiContent.TextureAtlas;
            LoadTexture(guiContent.TextureAtlas.TextureName);
            LoadFont(guiContent.FontFile, guiContent.FontTexture);
        }

        private void LoadFont(string fontFile)
        {

        }

        public void Update(float deltaTime)
        {
            ReadInputState();

            foreach(var layer in Layers)
                layer.Update(this, deltaTime);
        }

        public void Draw()
        {
            foreach(var layer in Layers)
                layer.Draw(this);
        }

        public abstract void LoadTexture(string textureName);
        internal abstract void LoadFont(string fontFile, string fontTexture);

        public abstract void StartBatch();
        public abstract void EndBatch();
        public abstract void DrawTexture(string textureName, IRectangle destinationRectangle);
        public abstract void Draw(string textureRegionName, IRectangle destinationRectangle);
        public abstract void Draw(IGuiSprite sprite, IRectangle destinationRectangle);
        public abstract void DrawText(string text, IRectangle destinationRectangle, IGuiSprite style);

        internal abstract void ReadInputState();
        public abstract bool IsInputPressed { get; }
        public abstract int X { get; }
        public abstract int Y { get; }
    }
    
}
