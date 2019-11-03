using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class PlayerBullet
    {
        Texture2D bulletImage;
        public Rectangle playerRectangle;
        public bool isActive = true;

        public PlayerBullet(Vector2 bulletPosition, int width, int heigh)
        {
            this.playerRectangle = new Rectangle((int)bulletPosition.X, (int)bulletPosition.Y, width, heigh);
            this.bulletImage = Tools.CreateColorTexture(Color.White);// Tools.GetImageTexture("Bullet_40x80");
        }

        internal void Update()
        {
            int moveSpeed = 5;
            int maxPosition_Y = 15;

            if (maxPosition_Y < playerRectangle.Y)
                playerRectangle.Y -= moveSpeed;
            else
                isActive = false;

        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(bulletImage, playerRectangle, Color.White);
        }

    }
}
