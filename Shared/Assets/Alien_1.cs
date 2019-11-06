using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shared
{
    public class Alien_1
    {
        Dir direcction;
        public Rectangle rectangle;
        public Texture2D image;
        public bool isActive;
        public bool canShoot;
        int frameCount;

        public Alien_1(Rectangle rectangle)
        {
            this.isActive = true;
            this.direcction = Dir.MoveR;
            this.rectangle = rectangle;
            this.image = Tools.CreateColorTexture(Color.Red);
            this.canShoot = true;
        }

        public void LoadContent()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            frameCount++;
            if (canShoot)
            {
                if (frameCount > 50)
                {
                    Level_1.alienBullets.Add(new AlienBullets(new Rectangle(rectangle.X, rectangle.Y, 5, 5)));
                    frameCount = 0;
                }
                
            }

            KeyboardState keyboardState = Keyboard.GetState();

            foreach (var playerBullet in Level_1.playerBullets)
            {
                if (rectangle.Intersects(playerBullet.rectangle)) { isActive = false; }
            }

            if(rectangle.X > 490)
            {
                direcction = Dir.MoveL;
                rectangle.Y += 10;
            }

            if (rectangle.X < 0)
            {
                direcction = Dir.MoveR;
                rectangle.Y += 10;
            }

            int moveSpeed = 1;
            rectangle.X += moveSpeed * (int)direcction;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isActive)
            {
                spriteBatch.Draw(image, rectangle, Color.White);
            }
        }


        public enum Dir
        {
            MoveR = 1,
            MoveL = -1
        }

    }
}