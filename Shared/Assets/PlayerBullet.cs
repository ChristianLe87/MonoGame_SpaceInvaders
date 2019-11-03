using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class PlayerBullet
    {
        public Vector2 position;
        Texture2D bulletImage;

        public bool isActive = true;

        public PlayerBullet(Vector2 bulletPosition)
        {
            this.position = bulletPosition;
            this.bulletImage = Tools.CreateColorTexture(Color.White);// Tools.GetImageTexture("Bullet_40x80");
        }

        internal void Update()
        {
            int moveSpeed = 2;
            int maxPosition_Y = 10;

            if (maxPosition_Y < position.Y)
                position.Y -= moveSpeed;
            else
                isActive = false;

        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(bulletImage, position, new Rectangle(0, 0, 100, 100), Color.White);
        }

    }
}
