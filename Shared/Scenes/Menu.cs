using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Menu : ILevel
    {
        Button button;

        public Menu(ContentManager content)
        {
            button = new Button(new Microsoft.Xna.Framework.Rectangle(100,100,100,100));
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