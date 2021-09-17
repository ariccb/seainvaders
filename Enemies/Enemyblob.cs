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
        public List<Enemy> Enemies;
        public int StartingX = 16;
        public int StartingY = 40;
        public int FrameCount = 0;
        public bool LeftToRight;
        public bool MoveDown;
        public Enemy LastMoved;
        public Enemy SecondLastMoved;
        private Spiral spiral = null;
        private Plunger plunger = null;
        private Squiggly squiggly = null;
        private Random rnd = new Random();
        

        public Enemyblob()
        {
            Enemies = new List<Enemy>();
            for (int i = 0; i < 1; i++)
            {
                StartingX = 16;                                     // Clarifies the X coordinates of the first sprite in the row.
                for (int j = 0; j < 11; j++)                        // The range of j defines the number of sprites in a row.
                {
                    Enemies.Add(new Squid(StartingX, StartingY));   // Adds a sprite at the coordinates defined by StartingX and StartingY
                    StartingX += 16;                                // Moves the starting position for the next sprite by 16 pixels.
                }
                StartingY += 16;                                    // Moves the starting position for the next row by 16 pixels on the Y axis.
            } // Creates Squid sprites on the first row, as defined by the range of "i".
            for (int i = 1; i < 3; i++)
            {
                StartingX = 16;
                for (int j = 0; j < 11; j++)                        // The range of j defines the number of sprites in a row.
                {
                    Enemies.Add(new Crabbypatty(StartingX, StartingY));    // Adds a sprite at the coordinates defined by StartingX and StartingY
                    StartingX += 16;                                // Moves the starting position of the next sprite by 16 pixels on the X axis.
                }
                StartingY += 16;                                    // Moves the starting position for the next row by 16 pixels on the Y axis.

            } // Creates Crab sprites on the second and third rows, as defined by the range of "i".
            for (int i = 3; i < 5; i++)
            {
                StartingX = 16;
                for (int j = 0; j < 11; j++)
                {
                    Enemies.Add(new Octopus(StartingX, StartingY));
                    StartingX += 16;
                }
                StartingY += 16;
            } // Creates Octopus sprites on the fourth and fifth rows, as defined by the range of "i".

            for (int i = 0; i < Enemies.Count; i++)
            {
                Enemies[i].Deleted += Enemyblob_Deleted; //this is the event listener 
            }
            LastMoved = Enemies[Enemies.Count - 1];
            SecondLastMoved = Enemies[Enemies.Count - 2];
        }

        private void Enemyblob_Deleted(object sender, EventArgs e)
        {
            Enemies.Remove((Enemy) sender); // static cast this sender as an Enemy 
        }

        private void Squiggly_Deleted(object sender, EventArgs e)
        {
            squiggly = null;
        }

        private void Plunger_Deleted(object sender, EventArgs e)
        {
            plunger = null;
        }

        private void Spiral_Deleted(object sender, EventArgs e)
        {
            spiral = null;
        }

        public void Update()
        {
            int move = 0; // move is holding the integer that is of the enemy that is moving this frame
            bool hitWall;
            if (Enemies.Count > 0)
            {
                if (Enemies.FindIndex(x => x == LastMoved) != -1) // if FindIndex doesn't find what it's looking for it outputs -1
                {
                    move = Enemies.FindIndex(x => x == LastMoved);
                }
                else
                {
                    move = Enemies.FindIndex(x => x == SecondLastMoved); // the reason we have secondlastmoved is because we can kill only one enemy per frame, so we're guaranteed to have an enemy left 
                }
                move++;
                if( move >= Enemies.Count)
                {
                    move = 0;
                }
                hitWall = Enemies[move].Move(LeftToRight); // .Move(leftToRight) is the function that actually moves things
                if (hitWall)
                {
                    MoveDown = true;
                }
                if (move == Enemies.Count - 1 && MoveDown)
                {
                    foreach (Enemy enemy in Enemies)
                    {
                        enemy.y += enemy.YMove;
                    }
                    MoveDown = false;
                    LeftToRight = !LeftToRight;
                }
                SecondLastMoved = LastMoved;
                LastMoved = Enemies[move];
                Enemy firing = Enemies[rnd.Next(Enemies.Count)];
                if (rnd.Next(3) == 0 && spiral == null)
                {
                    spiral = new Spiral(firing.x + (firing.width - 3) / 2, firing.y + firing.height);
                    spiral.Deleted += Spiral_Deleted;
                }
                if (rnd.Next(3) == 1 && plunger == null)
                {
                    plunger = new Plunger(firing.x + (firing.width - 3) / 2, firing.y + firing.height);
                    plunger.Deleted += Plunger_Deleted;
                }
                if (rnd.Next(3) == 2 && squiggly == null)
                {
                    squiggly = new Squiggly(firing.x + (firing.width - 3) / 2, firing.y + firing.height);
                    squiggly.Deleted += Squiggly_Deleted;
                }
            }
        }
    }
}
