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
        public abstract void Draw(ISprite sprite, IRectangle destinationRectangle);
        public abstract void DrawText(string text, IRectangle destinationRectangle, ISprite style);

        internal abstract void ReadInputState();
        public abstract bool IsInputPressed { get; }
        public abstract int X { get; }
        public abstract int Y { get; }
    }
    
}
