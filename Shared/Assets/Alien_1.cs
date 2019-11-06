using System;
using System.Linq;
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
        public Point arrayPoint;
        int frameShootInterval;

        public Alien_1(Rectangle rectangle,Point arrayPoint)
        {
            this.isActive = true;
            this.direcction = Dir.MoveR;
            this.rectangle = rectangle;
            this.image = Tools.CreateColorTexture(Color.Red);
            this.canShoot = false;
            this.arrayPoint = arrayPoint;
            this.frameShootInterval = new Random().Next(100, 400);
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
                if (frameCount > frameShootInterval)
                {
                    Level_1.alienBullets.Add(new AlienBullets(new Rectangle(rectangle.X, rectangle.Y, 5, 5)));
                    frameCount = 0;
                    this.frameShootInterval = new Random().Next(100, 400);
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

            // check if can shoot
            var result = Level_1.aliens.Where(x => x.arrayPoint.Y > arrayPoint.Y).ToList();
            if (result.Count == 0) { canShoot = true; }
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