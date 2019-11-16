using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Menu : ILevel
    {
        Button button;

        public Menu(ContentManager contentManager)
        {
            button = new Button(contentManager, new Rectangle(100, 100, 100, 100), "Play !");
        }

        public void Update()
        {
            button.Update();
            //throw new NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            button.Draw(spriteBatch);
            //throw new NotImplementedException();
        }
    }
}