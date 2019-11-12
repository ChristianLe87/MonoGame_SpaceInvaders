using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class FadeOut
    {
        Texture2D fadeOut;
        Rectangle rectangle;
        float alpha;

        public FadeOut(int width, int height)
        {
            this.alpha = 0f;
            this.fadeOut = Tools.CreateColorTexture(new Color(Color.Black, this.alpha));
            this.rectangle = new Rectangle(0, 0, width, height);
        }

        public void Update(float spead)
        {
            this.alpha += spead;
            this.fadeOut = Tools.CreateColorTexture(new Color(Color.Black, this.alpha));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(fadeOut, rectangle, Color.White);
        }
    }
}
