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
        public abstract char[,] graphic0 { get; } // this is called a "get" function, this is how to get "inheritance"
        public abstract char[,] graphic1 { get; }

        public Bitmap spriteArmsDown;
        public Bitmap spriteArmsUp;
        public bool activeSprite;
        public int xMove = 2;
        public int yMove = 8;

        public Enemy(int x, int y) : base() //this calls the constructor for the parent class
        {
            this.x = x;
            this.y = y;
            spriteArmsDown = CharArrayToBitmap(graphic0);
            spriteArmsUp = CharArrayToBitmap(graphic1);
            sprite = spriteArmsDown;
        }

        public void Hit()
        {
            Delete();
        }

        public bool Move(bool leftToRight)
        {
            activeSprite = !activeSprite;

            if (leftToRight) { x += xMove; }
            else { x -= xMove; }

            if (x <= 0) { return true; }
            if (x >= 208) { return true; }

            return false;
        }

        public override void Update()
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
       
    }
}
