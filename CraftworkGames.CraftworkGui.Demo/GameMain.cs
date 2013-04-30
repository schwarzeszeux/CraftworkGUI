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
            var playRegion = textureAtlas.AddRegion("play", 0, 0, 128, 128);
            var upRegion = textureAtlas.AddRegion("up", 128, 0, 64, 64);
            var cogRegion = textureAtlas.AddRegion("cog", 128, 64, 64, 64);
            var tickRegion = textureAtlas.AddRegion("tick", 192, 0, 64, 64);
            var crossRegion = textureAtlas.AddRegion("cross", 192, 64, 64, 64);
            var pauseRegion = textureAtlas.AddRegion("pause", 256, 0, 64, 64);
            var resetRegion = textureAtlas.AddRegion("reset", 256, 64, 64, 64);
            var boxRegion = textureAtlas.AddRegion("box", 496, 0, 16, 16);

            var redRegion = textureAtlas.AddRegion("red", 0, 164, 128, 111);
            var blueRegion = textureAtlas.AddRegion("blue", 0, 276, 128, 111);
            var squareRegion = textureAtlas.AddRegion("square", 128, 164, 128, 128);
            var greenSquareRegion = textureAtlas.AddRegion("greenSquare", 256, 164, 128, 128);

            _gui = new MonoGameGuiManager(GraphicsDevice, Content);
            _gui.LoadContent(new GuiContent(textureAtlas, "ExampleFont.fnt", "ExampleFont_0.png"));
            var backgroundRegion = _gui.LoadTexture("Background.png");

            var screen = new Screen(800, 480);
            screen.Background = new VisualStyle(backgroundRegion);

            _moneyLabel = new Label(new VisualStyle(squareRegion))
            {
                X = 600,
                Y = 0,
                Width = 200,
                Height = 32,
                HorizontalAlignment = HorizontalAlignment.Right
            };

            var dockLayout = new DockLayout()
            {
                Width = screen.Width,
                Height = screen.Height,
            };

            _gridLayout = new GridLayout(5, 8);

            for(int x = 0; x < _gridLayout.Columns; x++)
            {
                for(int y = 0; y < _gridLayout.Rows; y++)
                {
                    var image = new Image(new VisualStyle(squareRegion)) 
                    { 
                        Width = 80, 
                        Height = 80 
                    };

                    _gridLayout.Items.Add(new GridItem(image, y, x));
                }
            }

            for(int r = 0; r < _gridLayout.Rows; r++)
            {
                _gridLayout.Items.Add(new Pawn(redRegion, r, 0, 1));
                _gridLayout.Items.Add(new Pawn(blueRegion, r, _gridLayout.Columns - 1, -1));
            }

            dockLayout.Items.Add(new DockItem(_gridLayout, DockStyle.Fill));
            dockLayout.Items.Add(new DockItem(_moneyLabel, DockStyle.Top));

            screen.Items.Add(dockLayout);

            _gui.Screen = screen;

            // TODO: Refactor this to be auto
            dockLayout.PerformLayout();
            _gridLayout.PerformLayout();
        }

        private void SellButton_Clicked (object sender, EventArgs e)
        {

        }

        private Button CreateButton(ITextureRegion textureRegion, int width, int height)
        {
            return CreateButton(textureRegion, width, height, Color.White);
        }

        private Button CreateButton(ITextureRegion textureRegion, int width, int height, Color colour)
        {
            var button = new Button() 
            { 
                NormalStyle = new VisualStyle(textureRegion) { BackColour = colour },
                HoverStyle = new VisualStyle(textureRegion) 
                { 
                    Scale = new Vector2(1.05f, 1.05f),
                },
                PressedStyle = new VisualStyle(textureRegion)
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
            _gridLayout.PerformLayout();    // HACK to force an update

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

