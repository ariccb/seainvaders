using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace seainvaders
{
    class Enemyblob
    {
 
        public List <Crabbiepatty> crabs;
        public int startingx = 16;
        public int startingy = 120;
        

        public Enemyblob()
        {
            crabs = new List<Crabbiepatty>();
            for (int i = 0; i < 5; i++)
            {
                startingx = 16;
                for (int j = 0; j < 11; j++)
                {
                    crabs.Add(new Crabbiepatty(startingx, startingy));
                    
                    startingx += 16;
                    
                }
                startingy += 16;
            }
        }

        public void Render(Graphics graphics)
        {
           //*
           // for(int i = 0; i < crabs.Count; i++)
           // {
           //     crabs[i].Render(graphics);
           // }
           foreach(Crabbiepatty crab in crabs)
            {
                crab.Render(graphics);
            }
           
        }
    }
}
