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
        public int x;
        public int y;
        public Bitmap sprite;
        public Bitmap DeathSprite;
        public event EventHandler Deleted;
        public float scale = 3;
        public int height

        {
            get
            {
                return sprite.Height;
            }
        }
        public int width
        {
            get
            {
                return sprite.Width;
            }
        }

        public Entity()
        {
            Game.EntityList.Add(this);
        }

        public Bitmap CharArrayToBitmap(char[,] graphic)
        {
            Bitmap outputsprite = new Bitmap(graphic.GetLength(1), graphic.GetLength(0));
            for (int i = 0; i < graphic.GetLength(0); i++)
            {
                for (int j = 0; j < graphic.GetLength(1); j++)
                {
                    if (graphic[i, j] == '.')
                    {
                        outputsprite.SetPixel(j, i, Color.Transparent);
                    }
                    else
                    {
                        outputsprite.SetPixel(j, i, Color.DarkSeaGreen);
                    }
                }
            }
            return outputsprite;
        }

        public void SetGraphic(char[,] graphic)
        {
            sprite = CharArrayToBitmap(graphic);
        }
        public void SetDeathGraphic(char[,] graphic)
        {
            DeathSprite = CharArrayToBitmap(graphic);
        }

        public int[,] GetBoundingPoints()
        {
            int[,] points = {
                {x, y },                        // 0 top left
                {(x + width), y },              // 1 top right
                {x, (y + height) },             // 2 bottom left
                {(x + width), (y + height)}     // 3 bottom right
            };
            return points;
        }

        public bool IsColliding(Entity entity)
        {
            int[,] points1 = GetBoundingPoints();
            int[,] points2 = entity.GetBoundingPoints();

            int XOverlap = Math.Max(0, Math.Min(points1[3, 0], points2[3, 0]) - Math.Max(points1[0, 0], points2[0, 0])); // this tells you how much x overlap there is
            int YOverlap = Math.Max(0, Math.Min(points1[3, 1], points2[3, 1]) - Math.Max(points1[0, 1], points2[0, 1]));

            if (XOverlap > 0 && YOverlap > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual void Delete() // virtual is like a placeholder - this is the function that's going to call the event handler
        {
            Game.EntityList.Remove(this);
            EventHandler handler = Deleted;
            handler?.Invoke(this, new EventArgs()); // ? means if there is a handler, do this. If there is no handler, then don't do anything.
            if (DeathSprite != null)
            {
                new Explosion(x, y, DeathSprite);
            }
        }

        public abstract void Update(); // this tells classes inheriting "entity" that there needs to be an Update() function at the bottom of their script

        public void Render(Graphics graphics)
        {
            graphics.DrawImage(sprite, scale*x, scale*y, scale*width, scale*height);

        }
    }
}
