using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace seainvaders
{
    abstract class Enemy : Entity // difference to regular class is: Can't make new ones - can't create an 'instance' of an abstract class
    {
        public abstract char[,] Graphic0 { get; } // this is called a "get" function, this is how to get "inheritance"
        public abstract char[,] Graphic1 { get; }

        public Bitmap SpriteArmsDown;
        public Bitmap SpriteArmsUp;
        public bool ActiveSprite;
        public int XMove = 2;
        public int YMove = 8;
        public char[,] DeathGraphic
        {
            get
            {
                char[,] val =
                {
                    {'.','.','.','.','.','0','.','.','.','0','.','.','.','.','.','.'},
                    {'.','.','0','.','.','.','0','.','0','.','.','.','0','.','.','.'},
                    {'.','.','.','0','.','.','.','.','.','.','.','0','.','.','.','.'},
                    {'.','.','.','.','0','.','.','.','.','.','0','.','.','.','.','.'},
                    {'.','0','0','.','.','.','.','.','.','.','.','.','0','0','.','.'},
                    {'.','.','.','.','0','.','.','.','.','.','0','.','.','.','.','.'},
                    {'.','.','.','0','.','.','0','.','0','.','.','0','.','.','.','.'},
                    {'.','.','0','.','.','0','.','.','.','0','.','.','0','.','.','.'}
                };
                return val;
            }
        }

        public Enemy(int x, int y) : base() //this calls the constructor for the parent class
        {
            this.x = x;
            this.y = y;
            SpriteArmsDown = CharArrayToBitmap(Graphic0);
            SpriteArmsUp = CharArrayToBitmap(Graphic1);
            sprite = SpriteArmsDown;
            SetDeathGraphic(DeathGraphic);
        }

        public void Hit()
        {
            Delete();
        }

        public bool Move(bool leftToRight)
        {
            ActiveSprite = !ActiveSprite;

            if (leftToRight) { x += XMove; }
            else { x -= XMove; }

            if (x <= 0) { return true; }
            if (x >= 208) { return true; }

            return false;
        }

        public override void Update()
        {
            if (ActiveSprite)
            {
                sprite = SpriteArmsDown;
            }
            else
            {
                sprite = SpriteArmsUp;

            }
        }
       
    }
}
