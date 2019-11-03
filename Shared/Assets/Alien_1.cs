using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shared
{
    public class Alien_1 : IAlien
    {


        public Rectangle alienRectangle;

        public bool isActive = true;

        public Texture2D alienImage { get; set; }

        public Alien_1(Vector2 position, int width, int height)
        {
            this.alienRectangle = new Rectangle((int)position.X, (int)position.Y, width, height);
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
                if (alienRectangle.Contains(playerBullet.playerRectangle))
                {
                    this.isActive = false;
                }
            }

            int moveSpeed = 1;
            alienRectangle.X += moveSpeed;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(alienImage, alienRectangle, Color.White);
        }


    }
}