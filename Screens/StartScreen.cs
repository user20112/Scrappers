using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Input.InputListeners;
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

            KeyboardListener listener = new KeyboardListener();
            listener.KeyPressed += KeyPressed;
        }

        public override void Draw(GameTime gameTime, SpriteBatch toDrawto)
        {
            base.Draw(gameTime, toDrawto);
            //toDrawto.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied);
            //toDrawto.Draw(_background, new Rectangle(0, 0, (int)Scrappers.Width, (int)Scrappers.Height), Color.White);
            //toDrawto.End();
            _desktop.Render();
        }

        private void KeyPressed(object sender, KeyboardEventArgs e)
        {
            switch (e.Key)
            {
                case Microsoft.Xna.Framework.Input.Keys.E:
                    Scrappers.Instance.PopScreen();
                    Scrappers.Instance.Close();
                    break;

                case Microsoft.Xna.Framework.Input.Keys.P:
                    break;

                case Microsoft.Xna.Framework.Input.Keys.O:
                    break;

                case Microsoft.Xna.Framework.Input.Keys.D:
                    break;

                case Microsoft.Xna.Framework.Input.Keys.H:
                    break;

                case Microsoft.Xna.Framework.Input.Keys.S:
                    break;
            }
        }
    }
}