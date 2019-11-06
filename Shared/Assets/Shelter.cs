using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Shelter
    {
        public Rectangle rectangle;
        Texture2D image_3;
        Texture2D image_2;
        Texture2D image_1;
        public bool isActive;
        int life;

        public Shelter(Rectangle rectangle)
        {
            this.isActive = true;
            this.rectangle = rectangle;
            this.image_3 = Tools.CreateColorTexture(Color.Black);
            this.image_2 = Tools.CreateColorTexture(Color.Gray);
            this.image_1 = Tools.CreateColorTexture(Color.LightGray);
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
            if (life == 3)
            {
                spriteBatch.Draw(image_3, rectangle, Color.White);
            }
            else if (life == 2)
            {
                spriteBatch.Draw(image_2, rectangle, Color.White);
            }
            else if (life == 1)
            {
                spriteBatch.Draw(image_1, rectangle, Color.White);
            }

        }

        
    }
}
