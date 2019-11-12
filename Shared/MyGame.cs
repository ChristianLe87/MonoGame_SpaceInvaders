using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class MyGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // Levels
        public static string actualScene;
        Dictionary<string, ILevel> levels = new Dictionary<string, ILevel>() {
            { "Menu", new Menu() },
            { "Level_1", new Level_1() }
        };

        public static GraphicsDevice graphicsDevice;

        public static bool soundEffectsOn = true;

        public MyGame()
        {
            string relativePath = $"../../../../MonoGame_SpaceInvaders/Shared/Assets/";
            string absolutePath = new DirectoryInfo(Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, relativePath))).ToString();

            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = absolutePath;

            // Window size
            graphics.PreferredBackBufferWidth = 500;
            graphics.PreferredBackBufferHeight = 500;
        }


        protected override void Initialize()
        {
            actualScene = "Level_1";

            base.Initialize();
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            MyGame.graphicsDevice = GraphicsDevice;

            levels[actualScene].LoadContent(Content);
        }


        protected override void Update(GameTime gameTime)
        {
            levels[actualScene].Update();
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            levels[actualScene].Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}