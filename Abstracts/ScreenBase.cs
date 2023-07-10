using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Scrappers.Abstracts
{
    public class ScreenBase : UIElementBase
    {
        private List<PopupBase> _popupsStack = new();

        protected ScreenBase()
        {
        }

        public virtual void Dispose()
        {
            foreach (PopupBase popup in _popupsStack)
                popup.Dispose();
        }

        public override void Draw(GameTime gameTime, SpriteBatch toDrawto)
        {
            base.Draw(gameTime, toDrawto);
            for (int x = 0; x < _popupsStack.Count; x++)
            {
                _popupsStack[x].Draw(gameTime, toDrawto);
            }
        }

        public void PopPopup()
        {
            if (_popupsStack.Count > 0)
            {
                _popupsStack[^1].Dispose();
                _popupsStack.RemoveAt(_popupsStack.Count - 1);
            }
        }

        public void PushPopup(PopupBase popup)
        {
            if (!_popupsStack.Contains(popup))
            {
                _popupsStack.Add(popup);
            }
        }

        public override void Update(GameTime gameTime)
        {
            for (int x = 0; x < _popupsStack.Count; x++)
            {
                _popupsStack[x].Update(gameTime);
            }
            base.Update(gameTime);
        }
    }
}