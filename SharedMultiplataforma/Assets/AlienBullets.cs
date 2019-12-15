using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SharedMultiplataforma
{
    public class AlienBullets
    {
        public Rectangle rectangle;
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

            foreach (var shelter in Level_1.shelters)
            {
                if (rectangle.Intersects(shelter.rectangle))
                {
                    isActive = false;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, rectangle, Color.White);
        }
    }
}
