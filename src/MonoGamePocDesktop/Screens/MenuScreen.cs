using System;
using ImGuiNET;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Screens;

namespace MonoGamePocDesktop.Screens
{
    public class MenuScreen : GameScreen
    {
        private new Game1 Game => (Game1)base.Game;

        public MenuScreen(Game game) : base(game)
        {
        }

        public override void Draw(GameTime gameTime)
        {
            Game.GraphicsDevice.Clear(Color.White);

            Game.ImGuiRenderer.BeforeLayout(gameTime); // Must be called prior to calling any ImGui controls

            if (ImGui.Button("Start"))
            {
                Game.StartGame = true;
            }

            Game.ImGuiRenderer.AfterLayout(); // Must be called after ImGui control calls
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}