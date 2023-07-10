using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Scrappers.Abstracts
{
    public class UIElementBase
    {
        public virtual void Draw(GameTime gameTime, SpriteBatch toDrawto)
        {
        }

        public virtual void Update(GameTime gameTime)
        {
        }
    }
}