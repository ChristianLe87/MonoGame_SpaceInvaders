using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Level_1 : ILevel
    {

        // --- Score ---
        Text scoreLabel;
        public static int score;


        // --- PlayerHealth ---
        Text playerHealthLabel;
        //public static int playerHealth;

        // --- GameOver ---
        Text gameOver;
        FadeOut fadeOut;

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


        // --- AlienBullets ---
        public static List<AlienBullets> alienBullets = new List<AlienBullets>();


        public Level_1()
        {
            player = new Player(new Rectangle(250, 400, 25, 25));
        }

        public void LoadContent(ContentManager contentManager)
        {
            player.LoadContent();

            SetUpAliensPosition();
            SetUpSheltersMap();

            scoreLabel = new Text(contentManager, new Vector2(10, 10), "MyFont", $"Score {score}");
            playerHealthLabel = new Text(contentManager, new Vector2(350, 10), "MyFont", $"Health {player.health}");
            gameOver = new Text(contentManager, new Vector2(200, 200), "MyFont", "Game Over");

            fadeOut = new FadeOut(500, 500);
        }

        public void Update()
        {
            // Update Assets
            if (player.health > 0)
            {
                player.Update();
                foreach (var playerBullet in playerBullets) playerBullet.Update();
                foreach (var alienBullet in alienBullets) alienBullet.Update();
                foreach (var alien in aliens) alien.Update();
                foreach (var shelter in shelters) shelter.Update();
                scoreLabel.Update($"Score {score}");
                playerHealthLabel.Update($"Health {player.health}");

                // Clean lists
                playerBullets = playerBullets.Where(x => x.isActive == true).ToList();
                alienBullets = alienBullets.Where(x => x.isActive == true).ToList();
                aliens = aliens.Where(x => x.isActive == true).ToList();
                shelters = shelters.Where(x => x.isActive == true).ToList();
            }
            else
            {
                fadeOut.Update(0.003f);
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            player.Draw(spriteBatch);
            foreach (var alien in aliens) alien.Draw(spriteBatch);
            foreach (var alienBullet in alienBullets) alienBullet.Draw(spriteBatch);
            foreach (var playerBullet in playerBullets) playerBullet.Draw(spriteBatch);
            foreach (var shelter in shelters) shelter.Draw(spriteBatch);
            

            // When game over
            if (player.health <= 0) fadeOut.Draw(spriteBatch);
            if (player.health <= 0) gameOver.Draw(spriteBatch);

            // UI
            scoreLabel.Draw(spriteBatch);
            playerHealthLabel.Draw(spriteBatch);
        }

        internal void SetUpAliensPosition()
        {
            for (int row = 0; row < aliensMap.GetLength(0); row++)
            {
                for (int element = 0; element < aliensMap.GetLength(1); element++)
                {
                    if (aliensMap[row, element] == 'x')
                    {
                        aliens.Add(new Alien_1(new Rectangle(element * 25, row * 25, 20, 20), new Point(element, row)));
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
