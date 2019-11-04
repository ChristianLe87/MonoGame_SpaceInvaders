using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class PlayerBullet
    {
        Texture2D bulletImage;
        public Rectangle playerBulletRectangle;
        public bool isActive = true;

        public PlayerBullet(Rectangle rectangle)
        {
            this.playerBulletRectangle = rectangle;
            this.bulletImage = Tools.CreateColorTexture(Color.White);
        }

        internal void Update()
        {
            int moveSpeed = 5;
            int maxPosition_Y = 15;

            if (maxPosition_Y < playerBulletRectangle.Y)
                playerBulletRectangle.Y -= moveSpeed;
            else
                isActive = false;

            foreach (var shelter in Level_1.shelters)
            {
                if (playerBulletRectangle.Intersects(shelter.rectangle))
                {
                    isActive = false;
                }
            }
        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            if (isActive)
            {
                spriteBatch.Draw(bulletImage, playerBulletRectangle, Color.White);
            }
        }

    }
}
