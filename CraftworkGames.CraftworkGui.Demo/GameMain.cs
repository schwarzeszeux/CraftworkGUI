using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using CraftworkGames.CraftworkGui;
using CraftworkGames.CraftworkGui.MonoGame;

namespace CraftworkGames.CraftworkGui.Test
{
    public class GameMain : Game
    {
        private GraphicsDeviceManager _graphicsDeviceManager;
        private SpriteBatch _spriteBatch;
        private GuiManager _gui;
        private TradingGame _tradingGame = new TradingGame();
        private Label _moneyLabel;
        private Label _productionLabel;

        public GameMain()
        {
            _graphicsDeviceManager = new GraphicsDeviceManager(this);
            _graphicsDeviceManager.IsFullScreen = false;        

            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();				
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            var textureAtlas = new TextureAtlas("ExampleAtlas2.png");
            textureAtlas.AddRegion("play", 0, 0, 128, 128);
            textureAtlas.AddRegion("up", 128, 0, 64, 64);
            textureAtlas.AddRegion("cog", 128, 64, 64, 64);
            textureAtlas.AddRegion("tick", 192, 0, 64, 64);
            textureAtlas.AddRegion("cross", 192, 64, 64, 64);
            textureAtlas.AddRegion("pause", 256, 0, 64, 64);
            textureAtlas.AddRegion("reset", 256, 64, 64, 64);

            _gui = new MonoGameGuiManager(GraphicsDevice, Content);
            _gui.LoadContent(new GuiContent(textureAtlas, "ExampleFont.fnt", "ExampleFont_0.png"));
            _gui.LoadTexture("Background.png");

            var layer = new GuiLayer(800, 480);
            layer.BackgroundName = "Background.png";

            _productionLabel = new Label()
            {
                X = 0,
                Y = 0,
                Width = 200,
                Height = 32
            };
            layer.Controls.Add(_productionLabel);

            _moneyLabel = new Label()
            {
                X = 600,
                Y = 0,
                Width = 200,
                Height = 32
            };
            layer.Controls.Add(_moneyLabel);

            var playButton = new Button() 
            { 
                NormalStyle = new VisualStyle("play"),
                HoverStyle = new VisualStyle("play") 
                { 
                    Scale = new Vector2(1.05f, 1.05f),
                },
                PressedStyle = new VisualStyle("play")
                {
                    Scale = new Vector2(0.95f, 0.95f),
                },
                X = 400,
                Y = 240,
                Width = 128,
                Height = 128
            };
            layer.Controls.Add(playButton);


            _gui.Layers.Add(layer);
        }

        private void SellButton_Clicked (object sender, EventArgs e)
        {

        }

        private Button CreateButton(string text, int x, int y)
        {
            var button = new Button() 
            { 
                NormalStyle = new VisualStyle("button"),
                HoverStyle = new VisualStyle("button") 
                { 
                    BackColour = Color.LightGray, 
                    ForeColour = Color.LightGray,
                },
                PressedStyle = new VisualStyle("button")
                {
                    BackColour = Color.Gray, 
                    ForeColour = Color.Gray,
                    Effect = SpriteEffects.FlipVertically,
                    Scale = new Vector2(0.95f, 0.95f),
                },
                Text = text,
                X = x,
                Y = y,
                Width = 256,
                Height = 64
            };

            return button;
        }

        private void BuyButton_Clicked (object sender, EventArgs e)
        {
            _tradingGame.Buy();
        }

        private void QuitButton_Clicked(object sender, EventArgs e)
        {
            Exit();
        }

        protected override void Update(GameTime gameTime)
        {
            var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            var gamePadState = GamePad.GetState(PlayerIndex.One);
            var keyboardState = Keyboard.GetState();

            // For Mobile devices, this logic will close the Game when the Back button is pressed
            if (gamePadState.Buttons.Back == ButtonState.Pressed || keyboardState.IsKeyDown(Keys.Escape))
                Exit();

            _tradingGame.Update(deltaTime);
            _productionLabel.Text = string.Format("{0:#,##0}", 
                _tradingGame.PlayerRed.Inventory.GetQuantity(_tradingGame.PlayerRed.Production));
            _moneyLabel.Text = string.Format("${0:#,##0.00}", _tradingGame.PlayerRed.Account.Balance);

            _gui.Update(deltaTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _graphicsDeviceManager.GraphicsDevice.Clear(Color.Black);

            _gui.Draw();

            base.Draw(gameTime);
        }
    }
}

