using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Shelter
    {
        public Rectangle rectangle;
        Texture2D shelterImage;
        public bool isActive;
        int life;

        public Shelter(Rectangle rectangle)
        {
            this.isActive = true;
            this.rectangle = rectangle;
            this.shelterImage = Tools.CreateColorTexture(Color.Black);
            this.life = 3;
        }


        public void Update()
        {
            foreach (var bullet in Level_1.playerBullets)
            {
                if (bullet.rectangle.Intersects(rectangle)) { life--; }

                if (life < 1) { isActive = false; }
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(shelterImage, rectangle, Color.White);
        }

        
    }
}
