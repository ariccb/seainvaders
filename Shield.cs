using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seainvaders
{
    class Shield : Entity
    {
        public char[,] Graphic
        {
            get
            {
                char[,] val =
                {
                    {'.','.','.','.','0','0','0','0','0','0','0','0','0','0','0','0','0','0','.','.','.','.'},
                    {'.','.','.','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','.','.','.'},
                    {'.','.','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','.','.'},
                    {'.','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','.'},
                    {'0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0'},
                    {'0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0'},
                    {'0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0'},
                    {'0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0'},
                    {'0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0'},
                    {'0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0'},
                    {'0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0'},
                    {'0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0'},
                    {'0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0'},
                    {'0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0'},
                    {'0','0','0','0','0','0','0','.','.','.','.','.','.','.','0','0','0','0','0','0','0','0'},
                    {'0','0','0','0','0','0','.','.','.','.','.','.','.','.','.','0','0','0','0','0','0','0'},
                    {'0','0','0','0','0','.','.','.','.','.','.','.','.','.','.','.','0','0','0','0','0','0'},
                    {'0','0','0','0','0','.','.','.','.','.','.','.','.','.','.','.','0','0','0','0','0','0'},
                };

                return val;
            }

        }
        public Shield(int x, int y) : base()
        {
            this.x = x; // this.x is from the Entity, and the = x is from our arguments from public Shield( int x, int y) : base()
            this.y = y;
            SetGraphic(Graphic);

        }

        public int[] FindIntersect(Entity entity) // read through the sprite and find the intersecting pixel between the two sprites
        {
            int[,] points1 = GetBoundingPoints();
            int[,] points2 = entity.GetBoundingPoints();

            int XOverlap = Math.Max(0, Math.Min(points1[3, 0], points2[3, 0]) - Math.Max(points1[0, 0], points2[0, 0])); 
            int YOverlap = Math.Max(0, Math.Min(points1[3, 1], points2[3, 1]) - Math.Max(points1[0, 1], points2[0, 1]));

            int X1Start;
            int Y1Start;

            int X2Start;
            int Y2Start;

            if(points1[0, 0] < points2[0, 0])
            {
                X2Start = 0;
                X1Start = points2[0, 0] - points1[0, 0];
            }
            else
            {
                X1Start = 0;
                X2Start = points1[0, 0] - points2[0, 0];
            }
            if (points1[0, 1] < points2[0, 1])
            {
                Y2Start = 0;
                Y1Start = points2[0, 1] - points1[0, 1];
            }
            else
            {
                Y1Start = 0;
                Y2Start = points1[0, 1] - points2[0, 1];
            }
            int relY = 0;
            int j = Y1Start;
            int j2 = Y2Start;
            for (; relY < YOverlap; relY++, j++, j2++) // this is the key for this function 
            {

            }
            return new int[] { -1, -1 }; // this is how you declare an array
        }

        public void Damage(Entity explosion) // draws an explosion, ie. deletes pixels on the shield as it gets hit
        {

        }

        public override void Update()
        {
            
        }
    }
}
