using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SharedMultiplataforma
{
    public class Button
    {
        Texture2D noState_Texture;
        Texture2D hoverState_Texture;
        Texture2D pressedState_Texture;

        //Text text;

        Rectangle rectangle;

        ButtonState buttonState;

        public Button(ContentManager contentManager, Rectangle rectangle, string text)
        {
            this.noState_Texture = Tools.CreateColorTexture(Color.Gray);
            this.hoverState_Texture = Tools.CreateColorTexture(Color.LightGray);
            this.pressedState_Texture = Tools.CreateColorTexture(Color.DarkGray);

            this.rectangle = new Rectangle(rectangle.X - rectangle.Width / 2, rectangle.Y - rectangle.Height / 2, rectangle.Width, rectangle.Height);

            this.buttonState = ButtonState.noState;

            //this.text = new Text(contentManager, new Vector2(rectangle.X - rectangle.Width / 2, rectangle.Y - rectangle.Height / 2), WK.File.Font, text);

        }

        public void Update()
        {
            MouseState mouseState = Mouse.GetState();


            if (rectangle.Contains(mouseState.X, mouseState.Y))
            {
                if ((int)mouseState.LeftButton == (int)ButtonState.pressedState)
                {
                    this.buttonState = ButtonState.pressedState;
                    MyGame.actualScene = WK.Scene.Level_1;
                }
                else
                {
                    this.buttonState = ButtonState.hoverState;
                }
            }
            else
            {
                this.buttonState = ButtonState.noState;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            switch (buttonState)
            {
                case ButtonState.noState:
                    spriteBatch.Draw(noState_Texture, rectangle, Color.White);
                    break;
                case ButtonState.hoverState:
                    spriteBatch.Draw(hoverState_Texture, rectangle, Color.White);
                    break;
                case ButtonState.pressedState:
                    spriteBatch.Draw(pressedState_Texture, rectangle, Color.White);
                    break;
                default:
                    break;
            }

            //text.Draw(spriteBatch);

        }
    }

    enum ButtonState
    {
        noState = 0,
        pressedState = 1,
        hoverState = 2
    }
}
