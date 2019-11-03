using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shared
{
    public class Player
    {
        Texture2D ImageOne;
        double frameCount;
        Rectangle rectangle;

        public Player(Vector2 position, int width, int heigh)
        {
            rectangle = new Rectangle((int)position.X, (int)position.Y, width, heigh);
            this.frameCount = 0;
        }

        internal void LoadContent()
        {
            ImageOne = Tools.CreateColorTexture(Color.LightGreen);
        }

        internal void Update()
        {
            frameCount++;

            KeyboardState keyboardState = Keyboard.GetState();

            int moveSpeed = 2;
            int minPosition = 50;
            int maxPosition = 450;
            
            var result = Tools.MovePlayer(keyboardState, new Vector2(rectangle.X, rectangle.Y), minPosition, maxPosition, moveSpeed);
            rectangle.X = (int)result.X;
            rectangle.Y = (int)result.Y;


            if (keyboardState.IsKeyDown(Keys.J))
            {
                if (frameCount > 30)
                {
                    Level_1.playerBullets.Add(new PlayerBullet(new Vector2(rectangle.X, rectangle.Y),10,10));
                    frameCount = 0;
                }
            }
            

        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ImageOne, rectangle, Color.White);
        }


    }
}