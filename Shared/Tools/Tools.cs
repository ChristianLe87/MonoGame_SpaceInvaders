using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shared
{
    public static class Tools
    {
        internal static Texture2D CreateColorTexture(Color color)
        {
            Texture2D newTexture = new Texture2D(MyGame.graphicsDevice, 1, 1, false, SurfaceFormat.Color);
            newTexture.SetData<Color>(new Color[] { color });
            return newTexture;
        }

        internal static Texture2D GetImageTexture(string imageName)
        {
            string relativePath = $"../../../../MonoGame_SpaceInvaders/Assets/Images/{imageName}.png"; //Bullet_40x80.png
            string absolutePath = new DirectoryInfo(Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, relativePath))).ToString();

            FileStream fileStream = new FileStream(absolutePath, FileMode.Open);

            var result = Texture2D.FromStream(MyGame.graphicsDevice, fileStream);
            fileStream.Dispose();

            return result;
        }

        internal static Vector2 MovePlayer(KeyboardState keyboardState, Vector2 position, int minPosition, int maxPosition, int moveSpeed)
        {
            if (keyboardState.IsKeyDown(Keys.D) || keyboardState.IsKeyDown(Keys.Right))
            {
                if (position.X < maxPosition) position.X += moveSpeed;
            }
            else if (keyboardState.IsKeyDown(Keys.A) || keyboardState.IsKeyDown(Keys.Left))
            {
                if (position.X > minPosition) position.X -= moveSpeed;
            }

            return position;
        }

        internal static void PlayerShoot(KeyboardState keyboardState, Vector2 bulletPosition)
        {
            if (keyboardState.IsKeyDown(Keys.J))
            {
                MyGame.playerBullets.Add(new PlayerBullet(bulletPosition));
            }
        }
    }
}