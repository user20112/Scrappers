using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Myra.Graphics2D.UI;
using Scrappers.Abstracts;

namespace Scrappers.Screens
{
    public class StartScreen : ScreenBase
    {
        private Texture2D _background;
        private Desktop _desktop;
        private Myra_StartScreen _screen;

        public StartScreen()
        {
            _background = Scrappers.ContentManager.Load<Texture2D>("Backgrounds\\bg_lonelyBlueStar");
            _screen = new Myra_StartScreen();

            _desktop = new Desktop();
            _desktop.Root = _screen;

            _desktop.KeyDown += (s, a) =>
            {
            };
            // Inform Myra that external text input is available
            // So it stops translating Keys to chars
            _desktop.HasExternalTextInput = true;
            // Provide that text input
            //Window.TextInput += (s, a) =>
            //{
            //    _desktop.OnChar(a.Character);
            //};
        }

        public override void Draw(GameTime gameTime, SpriteBatch toDrawto)
        {
            base.Draw(gameTime, toDrawto);
            toDrawto.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied);
            toDrawto.Draw(_background, new Rectangle(0, 0, (int)Scrappers.Width, (int)Scrappers.Height), Color.White);
            toDrawto.End();
            _desktop.Render();
        }
    }
}