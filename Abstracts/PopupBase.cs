using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Scrappers.Abstracts
{
    public abstract class PopupBase : UIElementBase
    {
        private PopupBase()
        {
        }

        public virtual void Dispose()
        {
        }

        public override void Draw(GameTime gameTime, SpriteBatch toDrawto)
        {
            base.Draw(gameTime, toDrawto);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}