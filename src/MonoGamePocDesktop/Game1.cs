using System;
using ImGuiNET;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Screens.Transitions;
using MonoGamePocDesktop.Screens;

namespace MonoGamePocDesktop
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private ImGuiRenderer _imGuiRenderer;
        private readonly ScreenManager _screenManager;
        private TimeSpan _delay = TimeSpan.FromSeconds(2);
        private MenuScreen _menuScreen;
        private MapScreen _mapScreen;
        private StageOneScreen _stageOneScreen;
        
        public bool StartGame = false;
        public SpriteBatch SpriteBatch => _spriteBatch;
        public ImGuiRenderer ImGuiRenderer => _imGuiRenderer;
        public Point? SelectedStage { get; set; } = null;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _screenManager = new ScreenManager();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Components.Add(_screenManager);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            IsMouseVisible = true; // So you can see the mouse pointer over the controls
            _imGuiRenderer = new ImGuiRenderer(this); // Initialize the ImGui renderer
            _imGuiRenderer.RebuildFontAtlas(); // Required so fonts are available for rendering

            base.Initialize();

            _screenManager.LoadScreen(new SplashScreen(this));
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            _screenManager.LoadScreen(new SplashScreen(this));

            _delay -= gameTime.ElapsedGameTime;

            if (_delay <= TimeSpan.Zero)
            {
                _screenManager.LoadScreen(new MenuScreen(this));
            }

            if (StartGame)
            {
                _mapScreen = _mapScreen ?? new MapScreen(this);
                _screenManager.LoadScreen(_mapScreen);
            }

            if (SelectedStage != null)
            {
                _stageOneScreen = _stageOneScreen ?? new StageOneScreen(this);
                _screenManager.LoadScreen(_stageOneScreen);
            }
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here
            //_imGuiRenderer.BeforeLayout(gameTime); // Must be called prior to calling any ImGui controls
            //ImGui.ShowDemoWindow(); // Render the built in demonstration window
            //_imGuiRenderer.AfterLayout(); // Must be called after ImGui control calls

            base.Draw(gameTime);
        }
    }
}
