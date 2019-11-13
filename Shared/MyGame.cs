using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class MyGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // Levels
        public static string actualScene;
        Dictionary<string, ILevel> levels;

        public static GraphicsDevice graphicsDevice;

        public static bool soundEffectsOn = true;

        public MyGame()
        {
            string relativePath = $"../../../../MonoGame_SpaceInvaders/Shared/Assets/";
            string absolutePath = new DirectoryInfo(Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, relativePath))).ToString();
            this.Content.RootDirectory = absolutePath;

            this.graphics = new GraphicsDeviceManager(this);

            // Window size
            this.graphics.PreferredBackBufferWidth = 500;
            this.graphics.PreferredBackBufferHeight = 500;
        }


        protected override void Initialize()
        {
            base.Initialize();
        }


        protected override void LoadContent()
        {

            actualScene = "Level_1";

            spriteBatch = new SpriteBatch(GraphicsDevice);
            MyGame.graphicsDevice = GraphicsDevice;


            this.levels = new Dictionary<string, ILevel>() {
            { "Menu", new Menu(Content) },
            { "Level_1", new Level_1(Content) }
            };
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