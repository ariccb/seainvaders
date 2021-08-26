using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace seainvaders
{
    abstract class Enemy // difference to regular class is: Can't make new ones - can't create an 'instance' of an abstract class
    {
        public abstract char[,] graphic0 { get; } // this is called a "get" function, this is how to get "inheritance"
        public abstract char[,] graphic1 { get; }

        public Bitmap spriteArmsDown;
        public Bitmap spriteArmsUp;
        public Bitmap sprite;
        public int x;
        public int y;
        public abstract int width { get; }
        public abstract int height { get; }
        public bool activeSprite;
        public int xMove = 2;
        public int yMove = 8;

        public Enemy(int x, int y)
        {
            this.x = x;
            this.y = y;
            spriteArmsDown = new Bitmap(width, height);
            spriteArmsUp = new Bitmap(width, height);
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (graphic0[i, j] == '.')
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
                    if (graphic1[i, j] == '.')
                    {
                        spriteArmsUp.SetPixel(j, i, Color.Transparent);
                    }
                    else
                    {
                        spriteArmsUp.SetPixel(j, i, Color.DarkSeaGreen);
                    }
                }
            }
            sprite = spriteArmsDown;



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
            if (x <= 0)
            {
                return true;
            }
            if (x >= 208)
            {
                return true;
            }
            return false;

        }
        public void Update()
        {
            if (activeSprite)
            {
                sprite = spriteArmsDown;
            }
            else
            {
                sprite = spriteArmsUp;

            }
        }
        public void Render(Graphics graphics)
        {
            graphics.DrawImage(sprite, x, y);
        }
    }
}
