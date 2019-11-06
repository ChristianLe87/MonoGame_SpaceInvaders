using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class AlienBullets
    {
        Rectangle rectangle;
        public bool isActive;
        public Texture2D image;

        public AlienBullets(Rectangle rectangle)
        {
            this.isActive = true;
            this.rectangle = rectangle;
            this.image = Tools.CreateColorTexture(Color.Yellow);
        }

        public void Update()
        {
            int speed = 5;
            rectangle.Y += speed;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, rectangle, Color.White);
        }
    }
}
