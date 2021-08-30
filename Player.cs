using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace seainvaders
{
    class Player : Entity
    {
        public char[,] graphic =
            {
                { '.','.','.','.','.','.','0','.','.','.','.','.','.'},
                { '.','.','.','.','.','0','0','0','.','.','.','.','.'},
                { '.','.','.','.','.','0','0','0','.','.','.','.','.'},
                { '.','0','0','0','0','0','0','0','0','0','0','0','.'},
                { '0','0','0','0','0','0','0','0','0','0','0','0','0'},
                { '0','0','0','0','0','0','0','0','0','0','0','0','0'},
                { '0','0','0','0','0','0','0','0','0','0','0','0','0'},
                { '0','0','0','0','0','0','0','0','0','0','0','0','0'},
            };

        public int vx;
        public override int height
        {
            get
            {
                return 8;
            }
        }
        public override int width
        {
            get
            {
                return 13;
            }
        }

        public Player()
        {
            vx = 0;
            y = 211;
            x = 105;
            sprite = new Bitmap(width, height); // homework - try to abstract out this code into all other classes
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (graphic[i, j] == '.')
                    {
                        sprite.SetPixel(j, i, Color.Transparent);
                    }
                    else
                    {
                        sprite.SetPixel(j, i, Color.DarkSeaGreen);
                    }
                }
            }
        }
        public override void Update()
        {
            if (Game.keys.Contains("a") && x > 0)
            {
                vx = -2;
            }
            else if (Game.keys.Contains("d") && x < 223)
            {
                vx = 2;
            }
            else
            {
                vx = 0;
            }
            x += vx;
        }
     
    }
}