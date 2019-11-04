using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shared
{
    public class Alien_1 : IAlien
    {

        int direcction;
        public Rectangle alienRectangle;

        //public bool isActive = true;

        public Texture2D alienImage { get; set; }

        public bool isActive { get; set; }

        public Alien_1(Rectangle rectangle)
        {
            this.isActive = true;
            this.direcction = (int)Dir.MoveR;
            this.alienRectangle = rectangle;
            this.alienImage = Tools.CreateColorTexture(Color.Red);
        }

        public void LoadContent()
        {
            throw new NotImplementedException();
        }

        public void Update(int bb)
        {

            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.P))
            {
                var bla = 0;
            }
            foreach (var playerBullet in Level_1.playerBullets)
            {
                if (alienRectangle.Intersects(playerBullet.playerBulletRectangle))
                {
                    this.isActive = false;
                }
            }

            if(alienRectangle.X > 490)
            {
                direcction = (int)Dir.MoveL;
                alienRectangle.Y += 10;
            }

            if (alienRectangle.X < 0)
            {
                direcction = (int)Dir.MoveR;
                alienRectangle.Y += 10;
            }

            int moveSpeed = 1;
            alienRectangle.X += moveSpeed * direcction;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isActive)
            {
                spriteBatch.Draw(alienImage, alienRectangle, Color.White);
            }
        }


        public enum Dir
        {
            MoveR = 1,
            MoveL = -1
        }

    }
}