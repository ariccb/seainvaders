using System.Collections.Generic;
using System.Drawing;


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
        

        public Enemyblob()
        {
            enemies = new List<Enemy>();
            
            for (int i = 0; i < 3; i++)
            {
                startingx = 16;
                for (int j = 0; j < 11; j++)
                {
                    enemies.Add(new Crabbypatty(startingx, startingy));
                    
                    startingx += 16;
                    
                }
                startingy += 16;

            }
            for (int i = 3; i < 5; i++)
            {
                startingx = 16;
                for (int j = 0; j < 11; j++)
                {
                    enemies.Add(new Octopus(startingx, startingy));

                    startingx += 16;
                }
                startingy += 16;
            }
        }
        public void Update()
        {
            /*int move = frameCount % (crabs.Count + octopi.Count); // gets the remainder
            bool hitWall;
            if (crabs.Count > 0)
            {
                if (move < crabs.Count )
                {
                    hitWall = crabs[move].Move(leftToRight);
                    if (hitWall)
                    {
                        moveDown = true;
                    }
                    if (move == crabs.Count - 1 && moveDown)
                    {
                        foreach (Crabbypatty crab in crabs)
                        {
                            crab.y += crab.yMove;
                        }
                        moveDown = false;
                        leftToRight = !leftToRight;
                    }
                }
            }
           
            frameCount++;*/
        }

        public void Render(Graphics graphics)
        {
           //* //this is the same code as below
           // for(int i = 0; i < crabs.Count; i++)
           // {
           //     crabs[i].Render(graphics);
           // }
           foreach(Enemy enemy in enemies)
            {
                enemy.Render(graphics);
               
            }
                    
           
        }
    }
}
