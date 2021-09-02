using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System;


namespace seainvaders
{
    class Enemyblob
    {
        public List<Enemy> enemies;
        public int startingx = 16;
        public int startingy = 120;
        public int frameCount = 0;
        public bool leftToRight;
        public bool moveDown;
        public Enemy lastMoved;
        public Enemy secondLastMoved;
        

        public Enemyblob()
        {
            enemies = new List<Enemy>();
            for (int i = 0; i < 1; i++)
            {
                startingx = 16;                                     // Clarifies the X coordinates of the first sprite in the row.
                for (int j = 0; j < 11; j++)                        // The range of j defines the number of sprites in a row.
                {
                    enemies.Add(new Squid(startingx, startingy));   // Adds a sprite at the coordinates defined by startingx and startingy
                    startingx += 16;                                // Moves the starting position for the next sprite by 16 pixels.
                }
                startingy += 16;                                    // Moves the starting position for the next row by 16 pixels on the Y axis.
            } // Creates Squid sprites on the first row, as defined by the range of "i".
            for (int i = 1; i < 3; i++)
            {
                startingx = 16;
                for (int j = 0; j < 11; j++)                        // The range of j defines the number of sprites in a row.
                {
                    enemies.Add(new Crabbypatty(startingx, startingy));    // Adds a sprite at the coordinates defined by startingx and startingy
                    startingx += 16;                                // Moves the starting position of the next sprite by 16 pixels on the X axis.
                }
                startingy += 16;                                    // Moves the starting position for the next row by 16 pixels on the Y axis.

            } // Creates Crab sprites on the second and third rows, as defined by the range of "i".
            for (int i = 3; i < 5; i++)
            {
                startingx = 16;
                for (int j = 0; j < 11; j++)
                {
                    enemies.Add(new Octopus(startingx, startingy));
                    startingx += 16;
                }
                startingy += 16;
            } // Creates Octopus sprites on the fourth and fifth rows, as defined by the range of "i".

            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].Deleted += Enemyblob_Deleted; //this is the event listener 
            }
            lastMoved = enemies[enemies.Count - 1];
            secondLastMoved = enemies[enemies.Count - 2];
        }

        private void Enemyblob_Deleted(object sender, EventArgs e)
        {
            enemies.Remove((Enemy) sender); // static cast this sender as an Enemy 
        }

        public void Update()
        {
            int move = 0; // move is holding the integer that is of the enemy that is moving this frame
            bool hitWall;
            if (enemies.Count > 0)
            {
                if (enemies.FindIndex(x => x == lastMoved) != -1) // if FindIndex doesn't find what it's looking for it outputs -1
                {
                    move = enemies.FindIndex(x => x == lastMoved);
                }
                else
                {
                    move = enemies.FindIndex(x => x == secondLastMoved); // the reason we have secondlastmoved is because we can kill only one enemy per frame, so we're guaranteed to have an enemy left 
                }
                move++;
                if( move >= enemies.Count)
                {
                    move = 0;
                }
                hitWall = enemies[move].Move(leftToRight); // .Move(leftToRight) is the function that actually moves things
                if (hitWall)
                {
                    moveDown = true;
                }
                if (move == enemies.Count - 1 && moveDown)
                {
                    foreach (Enemy enemy in enemies)
                    {
                        enemy.y += enemy.yMove;
                    }
                    moveDown = false;
                    leftToRight = !leftToRight;
                }
                secondLastMoved = lastMoved;
                lastMoved = enemies[move];
            }
        }
    }
}
