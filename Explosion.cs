using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace seainvaders
{
    class Explosion : Entity
    {
        public int Timer;

        public Explosion( int x, int y, Bitmap DeathSprite) : base()
        {
            this.x = x;
            this.y = y;
            sprite = DeathSprite; // the only reason you need to use this.x and this.y is because there are already x and y from the arguments in Explosion. That's why sprite doensn't need to be this.sprite
        }

        public override void Update()
        {
            if (Timer < 20)
            {
                Timer++; 
            }
            else
            {
                Delete();
            }
        }
    }
}
