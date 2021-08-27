using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace seainvaders
{
    class Player
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

        public int x;
        public int y;
        public int vx;
        public int Width;
        public int Height;
        public Bitmap sprite;

        public Player()
        {
            vx = 0;
            y = 211;
            x = 105;
            Width = 13;
            Height = 8;
            sprite = new Bitmap(Width, Height);
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
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
        public void Update()
        {
            x += vx;
        }
        public void Render(Graphics graphics)
        {
            graphics.DrawImage(sprite, x, y);
        }
    }
}