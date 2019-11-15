using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shared
{
    public class Button
    {
        Texture2D noState_Texture;
        Texture2D hoverState_Texture;
        Texture2D pressedState_Texture;

        Rectangle rectangle;

        string buttonState = "";

        public Button(Rectangle rectangle)
        {
            this.noState_Texture = Tools.CreateColorTexture(Color.Gray);
            this.hoverState_Texture = Tools.CreateColorTexture(Color.LightGray);
            this.pressedState_Texture = Tools.CreateColorTexture(Color.DarkGray);

            this.rectangle = rectangle;

            this.buttonState = "noState";
        }

        public void Update()
        {
            MouseState mouseState = Mouse.GetState();


            if (rectangle.Contains(mouseState.X, mouseState.Y))
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    this.buttonState = "pressedState";
                    MyGame.actualScene = "Level_1";
                }
                else
                {
                    this.buttonState = "hoverState";
                }
            }
            else
            {
                this.buttonState = "noState";
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            switch (buttonState)
            {
                case "noState":
                    spriteBatch.Draw(noState_Texture, rectangle, Color.White);
                    break;
                case "hoverState":
                    spriteBatch.Draw(hoverState_Texture, rectangle, Color.White);
                    break;
                case "pressedState":
                    spriteBatch.Draw(pressedState_Texture, rectangle, Color.White);
                    break;
                default:
                    break;
            }

        }

    }
}
