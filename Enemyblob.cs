using System.Collections.Generic;
using System.Drawing;


namespace seainvaders
{
    class Enemyblob
    {
 
        public List <Crabbypatty> crabs;
        public int startingx = 16;
        public int startingy = 120;
        public int frameCount = 0;
        public bool leftToRight;
        public bool moveDown;
        

        public Enemyblob()
        {
            crabs = new List<Crabbypatty>();
            for (int i = 0; i < 5; i++)
            {
                startingx = 16;
                for (int j = 0; j < 11; j++)
                {
                    crabs.Add(new Crabbypatty(startingx, startingy));
                    
                    startingx += 16;
                    
                }
                startingy += 16;
            }
        }
        public void Update()
        {
            if(crabs.Count > 0)
            {
                
                int move = frameCount % crabs.Count;
                bool hitWall = crabs[move].Move(leftToRight);
                if (hitWall)
                {
                    moveDown = true;
                }
                if (move == crabs.Count - 1 && moveDown)
                {
                    foreach(Crabbypatty crab in crabs)
                    {
                        crab.y += crab.yMove;
                    }
                    moveDown = false;
                    leftToRight = !leftToRight;
                }
                frameCount++;

            }
        }

        public void Render(Graphics graphics)
        {
           //* //this is the same code as below
           // for(int i = 0; i < crabs.Count; i++)
           // {
           //     crabs[i].Render(graphics);
           // }
           foreach(Crabbypatty crab in crabs)
            {
                crab.Render(graphics);
            }
           
        }
    }
}
