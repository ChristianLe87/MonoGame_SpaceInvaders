using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class PlayerBullet
    {
        Texture2D image;
        public Rectangle rectangle;
        public bool isActive;

        public PlayerBullet(Rectangle rectangle)
        {
            this.isActive = true;
            this.rectangle = rectangle;
            this.image = Tools.CreateColorTexture(Color.White);
        }

        internal void Update()
        {
            int moveSpeed = 7;
            int maxPosition_Y = 15;

            if (maxPosition_Y < rectangle.Y)
                rectangle.Y -= moveSpeed;
            else
                isActive = false;

            foreach (var shelter in Level_1.shelters)
            {
                if (rectangle.Intersects(shelter.rectangle)) { isActive = false; }
            }


            foreach (var alien in Level_1.aliens)
            {
                if (rectangle.Intersects(alien.rectangle))
                {
                    isActive = false;
                }
            }
        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            if (isActive)
            {
                spriteBatch.Draw(image, rectangle, Color.White);
            }
        }

    }
}
