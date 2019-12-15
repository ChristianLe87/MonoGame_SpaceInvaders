using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SharedMultiplataforma
{
    public class Player
    {

        Texture2D image;
        double frameCount;
        Rectangle rectangle;
        public int health;
        //SoundEffect sound_Laser_Shoot_1;
        //SoundEffect sound_Hit_Hurt_1;

        // Initial values
        PlayerInitialValues playerInitialValues;

        public Player(Rectangle rectangle)
        {
            // initial values
            playerInitialValues = new PlayerInitialValues(rectangle, 50);


            this.rectangle = playerInitialValues.initialRectangle;
            this.frameCount = 0;
            this.health = playerInitialValues.health;

            image = Tools.CreateColorTexture(Color.LightGreen);
            //sound_Laser_Shoot_1 = Tools.GetSoundEffect(WK.File.Laser_Shoot_1);
            //sound_Hit_Hurt_1 = Tools.GetSoundEffect(WK.File.HurtSound);
        }

        internal void Update()
        {
            frameCount++;

            KeyboardState keyboardState = Keyboard.GetState();

            int moveSpeed = 2;
            int minPosition = 50;
            int maxPosition = MyGame.canvasWidth - 50;

            var result = Tools.MovePlayer(keyboardState, new Vector2(rectangle.X, rectangle.Y), minPosition, maxPosition, moveSpeed);
            rectangle.X = (int)result.X;
            rectangle.Y = (int)result.Y;


            if (keyboardState.IsKeyDown(Keys.Space))
            {
                if (frameCount > 30)
                {
                    //if (MyGame.soundEffectsOn) sound_Laser_Shoot_1.Play();
                    Level_1.playerBullets.Add(new PlayerBullet(rectangle.Center, 10, 10));
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
                        //if (MyGame.soundEffectsOn) sound_Hit_Hurt_1.Play();
                        health -= 10;
                        alienBullet.isActive = false;
                    }
                }
            }

            if (health <= 0)
            {
                health = 0;
                Level_1.gameMode = Level_1.GameMode_Enum.GameOver;
            }
        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, rectangle, Color.White);
        }

        internal void Reset()
        {
            this.rectangle = playerInitialValues.initialRectangle;
            this.health = playerInitialValues.health;
        }

        private class PlayerInitialValues
        {
            public Rectangle initialRectangle { get; private set; }
            public int health { get; private set; }

            public PlayerInitialValues(Rectangle initialRectangle, int health)
            {
                this.initialRectangle = initialRectangle;
                this.health = health;
            }

        }
    }
}