using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Alien_1 : IAlien
    {


        public Rectangle alienRectangle => throw new NotImplementedException();

        public bool isActive => throw new NotImplementedException();

        public Texture2D alienImage { get; set; }
        public Vector2 position;


        int width;
        int height;


        public Alien_1(Vector2 position, int width, int height)
        {
            this.width = width;
            this.height = height;

            this.position = position;
            this.alienImage = Tools.CreateColorTexture(Color.Red);
        }

        public void LoadContent()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            int moveSpeed = 1;
            position.X += moveSpeed;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(alienImage, position, new Rectangle(0, 0, width, height), Color.White);
        }


    }
}