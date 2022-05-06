using ImGuiNET;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Screens;

namespace MonoGamePocDesktop.Screens
{
    public class MapScreen : GameScreen
    {
        private Texture2D _mapTexture;
        private Texture2D _characterTexture;
        private Point _mousePosition = new Point();
        private Point _stageOne = new Point(355, 254);
        private Point _stageTwo = new Point(410, 254);
        private Point _selectedStage;
        private Point _characterPosition;
        private Point _characterSize = new Point(40, 40);
        private int _speed = 1;

        private new Game1 Game => (Game1)base.Game;

        public MapScreen(Game game) : base(game)
        {
            _mapTexture = Content.Load<Texture2D>("map");
            _characterTexture = Content.Load<Texture2D>("character");
            _selectedStage = _stageOne;
            _characterPosition = _stageOne;
        }

        public override void Draw(GameTime gameTime)
        {
            Game.GraphicsDevice.Clear(Color.White);

            Game.SpriteBatch.Begin();
            Game.SpriteBatch.Draw(_mapTexture, new Vector2(0, 0), Color.White);
            Game.SpriteBatch.Draw(_characterTexture, new Rectangle(_characterPosition, _characterSize), Color.White);
            Game.SpriteBatch.End();

            Game.ImGuiRenderer.BeforeLayout(gameTime); // Must be called prior to calling any ImGui controls

            ImGui.LabelText(_mousePosition.X.ToString(), "");
            ImGui.LabelText(_mousePosition.Y.ToString(), "");

            Game.ImGuiRenderer.AfterLayout(); // Must be called after ImGui control calls
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            _mousePosition.X = Mouse.GetState().Position.X;
            _mousePosition.Y = Mouse.GetState().Position.Y;

            if (_characterPosition.X < _selectedStage.X)
            {
                _characterPosition.X += _speed;
            }

            if (_characterPosition.X > _selectedStage.X)
            {
                _characterPosition.X -= _speed;
            }

            if (keyboardState.IsKeyDown(Keys.Left))
            {
                _selectedStage = _stageOne;
            }
            else if (keyboardState.IsKeyDown(Keys.Right))
            {
                _selectedStage = _stageTwo;
            }
            if (keyboardState.IsKeyDown(Keys.Enter))
            {
                Game.SelectedStage = _selectedStage;
            }
        }
    }
}