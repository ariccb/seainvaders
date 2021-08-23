using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace seainvaders
{
    class Crabbiepatty
    {
        char[,] val =
                {
                    { '.','.','0','.','.','.','.','.','0','.','.'},
                    { '.','.','.','0','.','.','.','0','.','.','.'},
                    { '.','.','0','0','0','0','0','0','0','.','.'},
                    { '.','0','0','.','0','0','0','.','0','0','.'},
                    { '0','0','0','0','0','0','0','0','0','0','0'},
                    { '0','.','0','0','0','0','0','0','0','.','0'},
                    { '0','.','0','.','.','.','.','.','0','.','0'},
                    { '.','.','.','0','0','.','0','0','.','.','.'},
                };

        public Bitmap sprite;
        public int x;
        public int y;
        public int width;
        public int height;

        public Crabbiepatty(int x, int y)
        {
            width = 11;
            height = 8;
            this.x = x;
            this.y = y;
            sprite = new Bitmap(width, height);
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (val[i, j] == '.')
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
        public void Render(Graphics graphics)
        {
            graphics.DrawImage(sprite, x, y);
        }
    }
}



