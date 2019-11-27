using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Shared
{
    public static class Tools
    {
        internal static Texture2D CreateColorTexture(Color color)
        {
            Texture2D newTexture = new Texture2D(MyGame.graphicsDeviceManager.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            newTexture.SetData(new Color[] { color });
            return newTexture;
        }

        internal static Texture2D GetImageTexture(string imageName)
        {
            string relativePath = $"../../../../MonoGame_SpaceInvaders/Assets/Images/{imageName}.png"; //Bullet_40x80.png
            string absolutePath = new DirectoryInfo(Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, relativePath))).ToString();

            FileStream fileStream = new FileStream(absolutePath, FileMode.Open);

            var result = Texture2D.FromStream(MyGame.graphicsDeviceManager.GraphicsDevice, fileStream);
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

        internal static SoundEffect GetSoundEffect(string soundName)
        {
            string relativePath = $"../../../../MonoGame_SpaceInvaders/Shared/Assets/{soundName}.wav";
            string absolutePath = new DirectoryInfo(Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, relativePath))).ToString();

            FileStream fileStream = new FileStream(absolutePath, FileMode.Open);

            var result = SoundEffect.FromStream(fileStream);
            fileStream.Dispose();

            return result;
        }

        internal static void SaveHighScore(int score)
        {
            string relativePath = $"{WK.File.Json}.txt";
            string absolutePath = new DirectoryInfo(Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, relativePath))).ToString();


            if (File.Exists(absolutePath))
            {

                int oldScore = GetHighScore();

                if (oldScore < score)
                {
                    File.Delete(absolutePath);

                    using (TextWriter file = new StreamWriter(absolutePath))
                    {
                        file.Write(score);
                    }
                }
            }
            else
            {
                using (TextWriter file = new StreamWriter(absolutePath))
                {
                    file.Write(score);
                }
            }
        }

        internal static int GetHighScore()
        {
            string relativePath = $"{WK.File.Json}.txt";
            string absolutePath = new DirectoryInfo(Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, relativePath))).ToString();

            if (File.Exists(absolutePath))
            {
                var highScore = File.ReadAllText(absolutePath);
                return Int32.Parse(highScore);
            }
            else
            {
                using (TextWriter file = new StreamWriter(absolutePath))
                {
                    file.Write(0);
                    return 0;
                }
            }
            
        }

    }
}