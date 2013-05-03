using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using CraftworkGames.CraftworkGui;
using CraftworkGames.CraftworkGui.MonoGame;
using System.Diagnostics;

namespace CraftworkGames.CraftworkGui.Test
{
    public class GameMain : Game
    {
        private GraphicsDeviceManager _graphicsDeviceManager;
        private SpriteBatch _spriteBatch;
        private MonoGameGuiManager _gui;
        private Label _timeLabel;

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
            var twitterRegion = textureAtlas.AddRegion("twitter", 417, 1, 62, 62);
            var facebookRegion = textureAtlas.AddRegion("facebook", 353, 1, 62, 62);
            var titleRegion = textureAtlas.AddRegion("title", 0, 435, 448, 77);

            //var tickRegion = textureAtlas.AddRegion("tick", 192, 0, 64, 64);
            //var crossRegion = textureAtlas.AddRegion("cross", 192, 64, 64, 64);
            //var pauseRegion = textureAtlas.AddRegion("pause", 256, 0, 64, 64);
            //var resetRegion = textureAtlas.AddRegion("reset", 256, 64, 64, 64);
            //var boxRegion = textureAtlas.AddRegion("box", 496, 0, 16, 16);
            //var redRegion = textureAtlas.AddRegion("red", 0, 164, 128, 111);
            //var blueRegion = textureAtlas.AddRegion("blue", 0, 276, 128, 111);
            //var squareRegion = textureAtlas.AddRegion("square", 128, 164, 128, 128);
            //var greenSquareRegion = textureAtlas.AddRegion("greenSquare", 256, 164, 128, 128);

            _gui = new MonoGameGuiManager(GraphicsDevice, Content);
            _gui.LoadContent(new GuiContent(textureAtlas, "ExampleFont.fnt", "ExampleFont_0.png"));
            var backgroundRegion = _gui.LoadTexture("Background.png");

            var screen = new Screen(800, 480);
            var dockLayout = new DockLayout();
            var gridLayout = new GridLayout(1, 2);
            var leftStackLayout = new StackLayout() { Orientation = Orientation.Horizontal, VerticalAlignment = VerticalAlignment.Bottom };
            var rightStackLaout = new StackLayout() { Orientation = Orientation.Vertical, HorizontalAlignment = HorizontalAlignment.Right };
            var playButton = CreateButton(playRegion);
            var cogButton = CreateButton(cogRegion);
            var upButton = CreateButton(upRegion);
            var facebookButton = new Button(new VisualStyle(twitterRegion)) { HoverStyle = new VisualStyle(twitterRegion) { Rotation = 0.05f } };
            var twitterButton = new Button(new VisualStyle(facebookRegion)) { HoverStyle = new VisualStyle(facebookRegion) { Rotation = 0.05f } };
            var titleImage = new Image(new VisualStyle(titleRegion)) { Margin = new Margin(0, 50, 0, 0) };

            _timeLabel = new Label() { Height = 32 };

            screen.Background = new VisualStyle(backgroundRegion);

            dockLayout.Items.Add(new DockItem(playButton, DockStyle.Fill));
            dockLayout.Items.Add(new DockItem(gridLayout, DockStyle.Bottom));
            dockLayout.Items.Add(new DockItem(_timeLabel, DockStyle.Top));
            dockLayout.Items.Add(new DockItem(titleImage, DockStyle.Top));

            leftStackLayout.Items.Add(cogButton);
            leftStackLayout.Items.Add(upButton);

            rightStackLaout.Items.Add(facebookButton);
            rightStackLaout.Items.Add(twitterButton);

            gridLayout.Items.Add(new GridItem(leftStackLayout, 0, 0));
            gridLayout.Items.Add(new GridItem(rightStackLaout, 0, 1));

            screen.Items.Add(dockLayout);

            _gui.Screen = screen;

            facebookButton.Clicked += (object sender, EventArgs e) => Process.Start("https://www.facebook.com/CraftworkGames"); 
            twitterButton.Clicked += (object sender, EventArgs e) => Process.Start("https://twitter.com/craftworkgames"); 
        }

        private Button CreateButton(ITextureRegion textureRegion)
        {
            var button = new Button(new VisualStyle(textureRegion)) 
            { 
                NormalStyle = new VisualStyle(textureRegion),
                HoverStyle = new VisualStyle(textureRegion) 
                { 
                    Scale = new Vector2(1.05f, 1.05f),
                },
                PressedStyle = new VisualStyle(textureRegion)
                {
                    Scale = new Vector2(0.95f, 0.95f),
                }
            };

            return button;
        }

        protected override void Update(GameTime gameTime)
        {
            var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            var gamePadState = GamePad.GetState(PlayerIndex.One);
            var keyboardState = Keyboard.GetState();

            // For Mobile devices, this logic will close the Game when the Back button is pressed
            if (gamePadState.Buttons.Back == ButtonState.Pressed || keyboardState.IsKeyDown(Keys.Escape))
                Exit();

            _timeLabel.Text = string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now);
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

