using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace seainvaders
{
    abstract class Entity
    {
        public abstract int width { get; }
        public abstract int height { get; }
        public int x;
        public int y;
        public Bitmap sprite;


        public abstract void Update(); // this tells classes inheriting "entity" that there needs to be an Update() function at the bottom of their script.

        public void Render(Graphics graphics)
        {
            graphics.DrawImage(sprite, x, y);
        }
    }
}
