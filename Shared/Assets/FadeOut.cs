using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class FadeOut
    {
        Texture2D fadeOut;
        Rectangle rectangle;
        public float alpha;
        SoundEffect sound_GameOverSound;
        bool playSound = true;


        public FadeOut(int width, int height)
        {
            this.alpha = 0f;
            this.fadeOut = Tools.CreateColorTexture(new Color(Color.Black, this.alpha));
            this.rectangle = new Rectangle(0, 0, width, height);
            this.sound_GameOverSound = Tools.GetSoundEffect("GameOver");
        }

        public void Reset()
        {
            this.alpha = 0f;
            this.fadeOut = Tools.CreateColorTexture(new Color(Color.Black, this.alpha));
            //this.rectangle = new Rectangle(0, 0, width, height);
            //this.sound_GameOverSound = Tools.GetSoundEffect("GameOver");
        }

        public void Update(float spead)
        {
            this.alpha += spead;
            this.fadeOut = Tools.CreateColorTexture(new Color(Color.Black, this.alpha));

            if (playSound)
            {
                sound_GameOverSound.Play();
                playSound = false;
            }

            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(fadeOut, rectangle, Color.White);
        }
    }
}
