using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Screens;

namespace MonoGamePocDesktop.Screens
{
    public class SplashScreen : GameScreen
    {
        private SpriteFont _font;
        private readonly SpriteBatch _spriteBatch;
        private Vector2 _position = new Vector2(50,50);

        public SplashScreen(Game1 game) : base(game)
        {
            _spriteBatch = game.SpriteBatch;
        }

        public override void LoadContent()
        {
            base.LoadContent();

            _font = Content.Load<SpriteFont>(@"File");
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();

            _spriteBatch.DrawString(_font, "Logo", new Vector2(600, 350), Color.Black, 0, new Vector2(0, 0), 3f, SpriteEffects.None, 0);

            _spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}