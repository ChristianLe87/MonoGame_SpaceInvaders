using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SharedMultiplataforma
{
    public class PlayerBullet
    {
        Texture2D image;
        public Rectangle rectangle;
        public bool isActive;

        public PlayerBullet(Point position, int Width, int Height)
        {
            this.isActive = true;
            this.rectangle = new Rectangle(position.X - Width / 2, position.Y - Height / 2, Width, Height);
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