using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shared
{
    public class Player
    {
        Texture2D ImageOne;
        Vector2 position;

        double frameCount;

        public Player(Vector2 position)
        {
            this.frameCount = 0;
            this.position = position;
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
            
            position = Tools.MovePlayer(keyboardState, position, minPosition, maxPosition, moveSpeed);


            if (keyboardState.IsKeyDown(Keys.J))
            {
                if (frameCount > 30)
                {
                    MyGame.playerBullets.Add(new PlayerBullet(position));
                    frameCount = 0;
                }
            }
            

        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ImageOne, position, new Rectangle(0, 0, 100, 100), Color.White);
        }


    }
}