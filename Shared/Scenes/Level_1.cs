using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Level_1
    {
        // --- Player ---
        Player player;


        // --- Aliens ---
        public static List<Alien_1> aliens = new List<Alien_1>();
        char[,] aliensMap = {
            {'x','x','x','x','x','x','x','x','x','x','x','x','x','x','x' },
            {'x','x','x','x','x','x','x','x','x','x','x','x','x','x','x' },
            {'x','x','x','x','x','x','x','x','x','x','x','x','x','x','x' },
            {'x','x','x','x','x','x','x','x','x','x','x','x','x','x','x' },
            {'x','x','x','x','x','x','x','x','x','x','x','x','x','x','x' },
            {'x','x','x','x','x','x','x','x','x','x','x','x','x','x','x' },
            {'x','x','x','x','x','x','x','x','x','x','x','x','x','x','x' }
        };


        // --- Shelters ---
        public static List<Shelter> shelters = new List<Shelter>();
        char[,] sheltersMap =
        {
            {' ','x',' ','x',' ','x',' ','x',' ','x',' ' }
        };


        // --- PlayerBullets ---
        public static List<PlayerBullet> playerBullets = new List<PlayerBullet>();


        public Level_1()
        {
            player = new Player(new Rectangle(250, 400, 25, 25));
        }

        public void LoadContent(GraphicsDevice graphicsDevice)
        {
            player.LoadContent();

            SetUpAliensPosition();
            SetUpSheltersMap();
        }

        public void Update()
        {
            // Update Assets
            player.Update();
            foreach (var playerBullet in playerBullets) playerBullet.Update();
            foreach (var alien in aliens) alien.Update(8);
            foreach (var shelter in shelters) shelter.Update();

            // Clean lists
            playerBullets = playerBullets.Where(x => x.isActive == true).ToList();
            aliens = aliens.Where(x => x.isActive == true).ToList();
            shelters = shelters.Where(x => x.isActive == true).ToList();

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            player.Draw(spriteBatch);
            foreach (var alien in aliens) alien.Draw(spriteBatch);
            foreach (var playerBullet in playerBullets) playerBullet.Draw(spriteBatch);
            foreach (var shelter in shelters) shelter.Draw(spriteBatch);
        }

        internal void SetUpAliensPosition()
        {
            for (int row = 0; row < aliensMap.GetLength(0); row++)
            {
                for (int element = 0; element < aliensMap.GetLength(1); element++)
                {
                    if (aliensMap[row, element] == 'x')
                    {
                        aliens.Add(new Alien_1(new Rectangle(element * 25, row * 25, 20, 20)));
                    }
                }
            }
        }

        internal void SetUpSheltersMap()
        {
            for (int row = 0; row < sheltersMap.GetLength(0); row++)
            {
                for (int element = 0; element < sheltersMap.GetLength(1); element++)
                {
                    if (sheltersMap[row, element] == 'x')
                    {
                        shelters.Add(new Shelter(new Rectangle(element *45, 300, 40, 20)));
                    }
                }
            }
        }
    }
}
