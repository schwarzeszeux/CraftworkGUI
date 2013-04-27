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
        private Label _moneyLabel;
        private GridLayout _gridLayout;

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
            textureAtlas.AddRegion("box", 496, 0, 16, 16);

            textureAtlas.AddRegion("red", 0, 164, 128, 111);
            textureAtlas.AddRegion("blue", 0, 276, 128, 111);
            textureAtlas.AddRegion("square", 128, 164, 128, 128);
            textureAtlas.AddRegion("greenSquare", 256, 164, 128, 128);

            _gui = new MonoGameGuiManager(GraphicsDevice, Content);
            _gui.LoadContent(new GuiContent(textureAtlas, "ExampleFont.fnt", "ExampleFont_0.png"));
            _gui.LoadTexture("Background.png");

            var layer = new GuiLayer(800, 480);
            layer.BackgroundName = "Background.png";

            _moneyLabel = new Label()
            {
                X = 600,
                Y = 0,
                Width = 200,
                Height = 32,
                HorizontalAlignment = HorizontalAlignment.Right
            };

            var dockLayout = new DockLayout()
            {
                Width = layer.Width,
                Height = layer.Height,
            };

            _gridLayout = new GridLayout(5, 8);

            for(int x = 0; x < _gridLayout.Columns; x++)
            {
                for(int y = 0; y < _gridLayout.Rows; y++)
                {
                    var image = new Image() 
                    { 
                        NormalStyle = new VisualStyle("square"), 
                        Width = 80, 
                        Height = 80 
                    };

                    _gridLayout.Items.Add(new GridItem(image, y, x));
                }
            }

            for(int r = 0; r < _gridLayout.Rows; r++)
            {
                _gridLayout.Items.Add(new Pawn("red", r, 0, 1));
                _gridLayout.Items.Add(new Pawn("blue", r, _gridLayout.Columns - 1, -1));
            }

            dockLayout.Items.Add(new DockItem(_gridLayout, DockStyle.Fill));
            dockLayout.Items.Add(new DockItem(_moneyLabel, DockStyle.Top));

            layer.Controls.Add(dockLayout);

            _gui.Layers.Add(layer);

            // TODO: Refactor this to be auto
            dockLayout.PerformLayout();
            _gridLayout.PerformLayout();
        }

        private void SellButton_Clicked (object sender, EventArgs e)
        {

        }

        private Button CreateButton(string textureRegionName, int width, int height)
        {
            return CreateButton(textureRegionName, width, height, Color.White);
        }

        private Button CreateButton(string textureRegionName, int width, int height, Color colour)
        {
            var button = new Button() 
            { 
                NormalStyle = new VisualStyle(textureRegionName) { BackColour = colour },
                HoverStyle = new VisualStyle(textureRegionName) 
                { 
                    Scale = new Vector2(1.05f, 1.05f),
                },
                PressedStyle = new VisualStyle(textureRegionName)
                {
                    Scale = new Vector2(0.95f, 0.95f),
                },
                Width = width,
                Height = height,
            };

            return button;
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

            _moneyLabel.Text = "Red's turn";
            _gridLayout.PerformLayout();

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

