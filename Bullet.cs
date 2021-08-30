using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace seainvaders
{
    class Bullet : Entity
    {
        
        public override int width
        {
            get
            {
                return 1;
            }
        }
        public override int height
        {
            get
            {
                return 4;
            }
        }

        public Bullet() : base()
        {
            y = 0;
            sprite = new Bitmap(width, height);
            
            for(int i = 0; i < 4; i++)
            {
                sprite.SetPixel(0, i, Color.Wheat);
            }
        }
        public override void Update()
        {
            y -= 4;
        }
    }
}
