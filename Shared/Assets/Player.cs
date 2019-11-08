using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shared
{
    public class Player
    {
        Texture2D image;
        double frameCount;
        Rectangle rectangle;
        public int health;

        public Player(Rectangle rectangle)
        {
            this.rectangle = rectangle;
            this.frameCount = 0;
            this.health = 100;
        }

        internal void LoadContent()
        {
            image = Tools.CreateColorTexture(Color.LightGreen);
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


            if (keyboardState.IsKeyDown(Keys.J) || keyboardState.IsKeyDown(Keys.Space))
            {
                if (frameCount > 30)
                {
                    Level_1.playerBullets.Add(new PlayerBullet(new Rectangle(rectangle.X, rectangle.Y,10,10)));
                    frameCount = 0;

                    int minusScore = 5;
                    Level_1.score = Level_1.score > minusScore ? Level_1.score - minusScore : 0;
                }
            }

            foreach (var alienBullet in Level_1.alienBullets)
            {
                if (rectangle.Intersects(alienBullet.rectangle))
                {
                    if (alienBullet.isActive)
                    {
                        health -= 10;
                        alienBullet.isActive = false;
                    }
                }
            }
            

        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, rectangle, Color.White);
        }


    }
}