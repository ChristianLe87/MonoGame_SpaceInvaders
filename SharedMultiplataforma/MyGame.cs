using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SharedMultiplataforma
{
    public class MyGame : Game
    {
        SpriteBatch spriteBatch;

        // Levels
        public static string actualScene;
        Dictionary<string, ILevel> levels;

        // Statics
        public static GraphicsDeviceManager graphicsDeviceManager;
        public static bool soundEffectsOn = true;
        public const int canvasWidth = 500;
        public const int canvasHeight = 500;

        public MyGame()
        {
            /*string relativePath = $"../../../../MonoGame_SpaceInvaders/Shared/Assets/";
            string absolutePath = new DirectoryInfo(Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, relativePath))).ToString();
            this.Content.RootDirectory = absolutePath;*/
            graphicsDeviceManager = new GraphicsDeviceManager(this);

            // Window size
            graphicsDeviceManager.PreferredBackBufferWidth = canvasWidth;
            graphicsDeviceManager.PreferredBackBufferHeight = canvasHeight;
        }


        protected override void Initialize()
        {
            base.Initialize();
        }


        protected override void LoadContent()
        {
            actualScene = WK.Scene.Menu;

            spriteBatch = new SpriteBatch(GraphicsDevice);

            this.levels = new Dictionary<string, ILevel>() {
                { WK.Scene.Menu, new Menu(Content) },
                { WK.Scene.Level_1, new Level_1(Content) }
            };
        }


        protected override void Update(GameTime gameTime)
        {
            levels[actualScene].Update();

            if (actualScene == WK.Scene.Menu)
                this.IsMouseVisible = true;
            else
                this.IsMouseVisible = false;


            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            graphicsDeviceManager.GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            levels[actualScene].Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
