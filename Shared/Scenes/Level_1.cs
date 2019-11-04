using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Level_1 : ILevel
    {
        // --- Aliens ---
        List<IAlien> aliens = new List<IAlien>();

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
        public static List<IShelter> shelters = new List<IShelter>();
        char[,] sheltersMap =
        {
            {' ','x',' ','x',' ','x',' ','x',' ','x',' ' }
        };


        // --- Player ---
        Player player;
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
            player.Update();

            foreach (var alien in aliens) alien.Update(8);

            foreach (var playerBullet in playerBullets) playerBullet.Update();

            foreach (var shelter in shelters) shelter.Update();


            // Clean array (just active bullets)
            playerBullets = playerBullets.Where(x => x.isActive == true).ToList();
            aliens = aliens.Where(x => x.isActive == true).ToList();



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
                        this.aliens.Add(new Alien_1(new Rectangle(element * 25, row * 25, 20, 20)));
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
