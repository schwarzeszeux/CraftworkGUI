using System;

namespace CraftworkGames.CraftworkGui.MonoGame
{
    public interface IGuiProvider : IUpdateManager, IDrawManager
    {
        void LoadTexture(string name);
        void Update(float deltaTime);
        void Draw(ITextureRegion textureRegion, int x, int y, int width, int height);
    }
    
}
