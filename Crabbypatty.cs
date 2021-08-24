using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace seainvaders
{
    class Crabbypatty
    {
        char[,] var1 =
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

        char[,] var2 =
                {
                    {'.','.','0','.','.','.','.','.','0','.','.'},
                    {'0','.','.','0','.','.','.','0','.','.','0'},
                    {'0','.','0','0','0','0','0','0','0','.','0'},
                    {'0','0','0','.','0','0','0','.','0','0','0'},
                    {'0','0','0','0','0','0','0','0','0','0','0'},
                    {'.','0','0','0','0','0','0','0','0','0','.'},
                    {'.','.','0','.','.','.','.','.','0','.','.'},
                    {'.','0','.','.','.','.','.','.','.','0','.'},
                };

        public Bitmap spriteArmsDown;
        public Bitmap spriteArmsUp;
        public int x;
        public int y;
        public int width;
        public int height;
        public bool activeSprite;
        public int xMove = 2;
        public int yMove = 8;

        public Crabbypatty(int x, int y)
        {
            width = 11;
            height = 8;
            this.x = x;
            this.y = y;
            spriteArmsDown = new Bitmap(width, height);
            spriteArmsUp = new Bitmap(width, height);
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (var1[i, j] == '.')
                    {
                        spriteArmsDown.SetPixel(j, i, Color.Transparent);
                    }
                    else
                    {
                        spriteArmsDown.SetPixel(j, i, Color.DarkSeaGreen);
                    }
                }
            }
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (var2[i, j] == '.')
                    {
                        spriteArmsUp.SetPixel(j, i, Color.Transparent);
                    }
                    else
                    {
                        spriteArmsUp.SetPixel(j, i, Color.DarkSeaGreen);
                    }
                }
            }


        }
        public bool Move(bool leftToRight)
        {
            
            activeSprite = !activeSprite;
            if (leftToRight)
            {
                x += xMove;
            }
            else
            {
                x -= xMove;
            }
            if( x <= 0)
            {
                return true;
            }
            if (x >= 208)
            {
                return true;
            }
            return false;

        }
        public void Render(Graphics graphics)
        {
            /*
             sprite.SetResolution(16, 12);*/
            if (activeSprite)
            {
                graphics.DrawImage(spriteArmsDown, x, y);
            }
            else
            {
                graphics.DrawImage(spriteArmsUp, x, y);

            }
        }
    }
}



