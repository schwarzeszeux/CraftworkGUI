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
        private MonoGameGuiManager _gui;

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

            var stackLayout = new StackLayout()
            {
                Orientation = Orientation.Vertical
            };

            var button0 = CreateButton(playRegion, 64, 64);
            button0.HorizontalAlignment = HorizontalAlignment.Centre;
            button0.VerticalAlignment = VerticalAlignment.Centre;
            stackLayout.Items.Add(button0);

            var button1 = CreateButton(cogRegion, 64, 64);
            button1.HorizontalAlignment = HorizontalAlignment.Centre;
            button1.VerticalAlignment = VerticalAlignment.Centre;
            stackLayout.Items.Add(button1);

            var button2 = CreateButton(tickRegion, 64, 64);
            button2.HorizontalAlignment = HorizontalAlignment.Centre;
            button2.VerticalAlignment = VerticalAlignment.Centre;
            stackLayout.Items.Add(button2);

            var label = new Label(new VisualStyle(squareRegion) { Colour = new Color(Color.White, 0.5f) })
            {
                Text = "Hello World!"
            };
            stackLayout.Items.Add(label);

            var canvasLayout = new RelativeLayout()
            {
                HorizontalAlignment = HorizontalAlignment.Centre,
                VerticalAlignment = VerticalAlignment.Centre
            };

            var button3 = CreateButton(crossRegion, 50, 50);
            canvasLayout.Items.Add(new RelativeItem(button3, -32, -32));
            stackLayout.Items.Add(canvasLayout);

            screen.Items.Add(stackLayout);

            _gui.Screen = screen;

            // TODO: Refactor this to be auto
            screen.PerformLayout();
            stackLayout.PerformLayout();
            canvasLayout.PerformLayout();
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
                NormalStyle = new VisualStyle(textureRegion) { Colour = colour },
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

