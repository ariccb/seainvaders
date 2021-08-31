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
        public event EventHandler Deleted;
        public float scale = 3;

        public Entity()
        {
            Game.EntityList.Add(this);
        }

        public virtual void Delete() // virtual is like a placeholder - this is the function that's going to call the event handler
        {
            Game.EntityList.Remove(this);
            EventHandler handler = Deleted;
            handler?.Invoke(this, new EventArgs()); // ? means if there is a handler, do this. If there is no handler, then don't do anything.
        }

        public abstract void Update(); // this tells classes inheriting "entity" that there needs to be an Update() function at the bottom of their script

        public void Render(Graphics graphics)
        {
            graphics.DrawImage(sprite, scale*x, scale*y, scale*width, scale*height);

        }
    }
}
