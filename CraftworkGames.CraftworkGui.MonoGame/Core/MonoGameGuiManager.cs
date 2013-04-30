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
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace CraftworkGames.CraftworkGui.MonoGame
{
    public class MonoGameGuiManager : GuiManager
    {
        private Dictionary<string, Texture2D> _textureMap;
        private ContentManager _contentManager;
        private FontRenderer _fontRenderer;

        public MonoGameGuiManager(GraphicsDevice graphicsDevice, ContentManager contentManager)
        {
            _spriteBatch = new SpriteBatch(graphicsDevice);
            _contentManager = contentManager;
            _textureMap = new Dictionary<string, Texture2D>();
        }

        public override ITextureRegion LoadTexture(string name)
        {
            Texture2D texture;

            if(!_textureMap.TryGetValue(name, out texture))
            {
                texture = _contentManager.Load<Texture2D>(name);
                _textureMap.Add(name, texture);
            }

            return new TextureRegion(new TextureAtlas(name), name, 0, 0, texture.Width, texture.Height);
        }

        internal override void LoadFont(string fontFile, string fontTexture)
        {
            LoadTexture(fontTexture);

            string path = Path.Combine(_contentManager.RootDirectory, fontFile);
            using(var stream = TitleContainer.OpenStream(path))
            {
                var fontData = FontLoader.Load(stream);
                var texture = _textureMap[fontTexture];
                _fontRenderer = new FontRenderer(fontData,  texture);
            }

        }

        public override event ItemEventHandler<Keys> KeyPressed;

        internal override void ReadInputState()
        {
            var previousKeys = _keyboardState.GetPressedKeys();

            _mouseState = Mouse.GetState();
            _keyboardState = Keyboard.GetState();

            if(previousKeys != null)
            {
                foreach(var key in previousKeys)
                {
                    if(_keyboardState.IsKeyUp(key))
                    {
                        if(KeyPressed != null)
                            KeyPressed(this, new ItemEventArgs<Keys>(key));
                    }
                }
            }
        }

        // TODO: Refactor this out
        private Rectangle ToRectangle(IRectangle rectangle)
        {
            return new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
        }

        public override void Draw(ITextureRegion textureRegion, IRectangle destinationRectangle)
        {
            // TODO: Remove this slight hack
            Draw(new VisualStyle(textureRegion), destinationRectangle);
        }

        public override void Draw(IGuiSprite sprite, IRectangle destinationRectangle)
        {
            var textureRegion = sprite.TextureRegion as TextureRegion;
            var texture = _textureMap[textureRegion.TextureAtlas.TextureName];
            
            if(texture != null)
            {
                var sourceRectangle = ToRectangle(textureRegion);
                var destRectangle = ToRectangle(destinationRectangle);

                if(sprite.Scale != Vector2.One)
                {
                    var scaledWidth = sprite.Scale.X * destRectangle.Width;
                    var scaledHeight = sprite.Scale.Y * destRectangle.Height;
                    var offsetX = (int)(destRectangle.Width - scaledWidth) / 2;
                    var offsetY = (int)(destRectangle.Height - scaledHeight) / 2;
                    destRectangle = new Rectangle(offsetX + destRectangle.X, offsetY + destRectangle.Y, (int)scaledWidth, (int)scaledHeight);
                }

                _spriteBatch.Draw(texture, destRectangle, sourceRectangle, sprite.BackColour, 
                                  sprite.Rotation, sprite.Origin, sprite.Effect, sprite.Depth);
            }
        }

        internal void Draw(TextureRegion textureRegion, IRectangle destinationRectangle)
        {
            var texture = _textureMap[textureRegion.TextureAtlas.TextureName];

            if(texture != null)
            {
                var sourceRectangle = new Rectangle(textureRegion.X, textureRegion.Y, textureRegion.Width, textureRegion.Height);

                _spriteBatch.Draw(texture, ToRectangle(destinationRectangle), sourceRectangle, Color.White);
            }
        }

        public override void DrawText(string text, IRectangle destinationRectangle, IGuiSprite style)
        {
            var destRectangle = ToRectangle(destinationRectangle);
            var size = _fontRenderer.MeasureText(text);
            var centre = destRectangle.Center;
            var lineHeight = _fontRenderer.FontFile.Common.LineHeight;
            var textPosition = new Point(centre.X - size.Width / 2, centre.Y - lineHeight / 2);

            _fontRenderer.DrawText(_spriteBatch, textPosition.X, textPosition.Y, text, style.ForeColour);        
        }

        private SpriteBatch _spriteBatch;
        public override void StartBatch()
        {
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, 
                               SamplerState.AnisotropicClamp, DepthStencilState.Default, 
                               RasterizerState.CullNone, null, Matrix.CreateScale(1));
        }

        public override void EndBatch()
        {
            _spriteBatch.End();
        }

        private MouseState _mouseState;
        private KeyboardState _keyboardState;

        public override bool IsInputPressed
        {
            get
            {
                return _mouseState.LeftButton == ButtonState.Pressed;
            }
        }

        public override bool IsShiftDown
        {
            get
            {
                return _keyboardState.IsKeyDown(Keys.LeftShift) || _keyboardState.IsKeyDown(Keys.RightShift);
            }
        }

        public override int X
        {
            get
            {
                return _mouseState.X;
            }
        }

        public override int Y
        {
            get
            {
                return _mouseState.Y;
            }
        }
    }
}

