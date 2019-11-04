using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Shelter : IShelter
    {
        public Rectangle rectangle { get; set; }
        Texture2D shelterImage;

        public Shelter(Rectangle rectangle)
        {
            this.rectangle = rectangle;
            this.shelterImage = Tools.CreateColorTexture(Color.Black);
        }


        public void Update()
        {
            var bullets = Level_1.playerBullets;
            if (bullets.Count > 0)
            {
                if (bullets[0].playerBulletRectangle.Intersects(rectangle))
                {
                    var bla = 0;
                }
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(shelterImage, rectangle, Color.White);
        }

        
    }
}
