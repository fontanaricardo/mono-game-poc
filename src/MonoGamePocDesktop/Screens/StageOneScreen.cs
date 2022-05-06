using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Sprites;

namespace MonoGamePocDesktop.Screens
{
    public class StageOneScreen : GameScreen
    {
        private Texture2D _backgroundTexture;
        private Sprite _sprite;
        private readonly List<Sprite> _spriteList = new List<Sprite>();
        private Vector2 _referenceVector = new Vector2(0, 0);
        private Vector2 _scale = new Vector2(2.0f, 2.0f);

        private new Game1 Game => (Game1)base.Game;

        public StageOneScreen(Game game) : base(game)
        {
            _backgroundTexture = Content.Load<Texture2D>("parallax-mountain-montain-far");
            _sprite = new Sprite(_backgroundTexture);
            _spriteList.Add(_sprite);
        }

        public override void Draw(GameTime gameTime)
        {
            Game.GraphicsDevice.Clear(Color.White);
            Game.SpriteBatch.Begin();

            var currentVector = new Vector2(_referenceVector.X * _scale.X, _referenceVector.Y);
            Game.SpriteBatch.Draw(_sprite, currentVector, 0, _scale);

            for (int i = 0; i < 100; i++)
            {
                var newVector = new Vector2(currentVector.X + _backgroundTexture.Width * _scale.X, 0);
                var currentSprite = new Sprite(_backgroundTexture);
                Game.SpriteBatch.Draw(currentSprite, newVector, 0, _scale);
                currentVector = newVector;
            }

            
            
            Game.SpriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Right))
            {
                _referenceVector.X -= 1;
            }
            else if (keyboardState.IsKeyDown(Keys.Left))
            {
                _referenceVector.X += 1;
            }
        }
    }
}