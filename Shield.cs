using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

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

            int XOverlap = Math.Max(0, Math.Min(points1[3, 0], points2[3, 0]) - Math.Max(points1[0, 0], points2[0, 0])); // XOverlap is how many pixels overlap in the x direction
            int YOverlap = Math.Max(0, Math.Min(points1[3, 1], points2[3, 1]) - Math.Max(points1[0, 1], points2[0, 1])); // YOverlap is how many pixels overlap in the y direction

            int X1Start;
            int Y1Start;

            int X2Start;
            int Y2Start;

            // i believe the following if statements are to determine which pixels in our sprites need to be changed from '0' in their bitmaps, to '.' (to make them transparent)
            if(points1[0, 0] < points2[0, 0])   // if the first sprite(top left, x value) is further left than the 2nd sprite(top left, x value)
            {
                X2Start = 0;                    // the top left, x value of the 2nd sprite already is the beginning of the intersection - no adjustment needed, aka '0'
                X1Start = points2[0, 0] - points1[0, 0]; // example: if points1[0,0] = 30 and points2[0,0] = 38, then 38-30 = 8 pixels, so you'd want to add 8 to the x value of points1[0,0]
            }
            else                                // if the second sprite(top left, x value) is further left than the first sprite(top left, x value)
            {
                X1Start = 0;                             // basically the opposite of above is true, so the first sprite's top left x value is the beginning of the overlap
                X2Start = points1[0, 0] - points2[0, 0]; // and the 2nd sprite's top left x value needs to add the difference between the two sprites' top left 
                                                         // x values to itself to get the 'beginning of the intersection for the 2nd sprite's top left x value'
                                                         // i believe we will be using the sprite array and changing the values at the points of the array = points[0,0] + X1Start
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
            int relY = 0; //relative Y
            int j = Y1Start;
            int j2 = Y2Start;
            for (; relY < YOverlap; relY++, j++, j2++) // this is the key for this function 
            {
                
                int relX = 0; // relative x
                int i = X1Start;
                int i2 = X2Start;
                for (; relX < XOverlap; relX++, i++, i2++)
                {
                    /*this.sprite.SetPixel(i, j, Color.Red);
                    entity.sprite.SetPixel(i2, j2, Color.Yellow);*/
                    if ((this.sprite.GetPixel(i, j).A != Color.Transparent.A) && (entity.sprite.GetPixel(i2, j2).A != Color.Transparent.A))
                    {
                        return new int[] { i, j };
                    }
                }
            }
            return new int[] { -1, -1 }; // this is how you declare an array
        }

        public void Damage(Entity explosion) // draws an explosion, ie. deletes pixels on the shield as it gets hit
        {
            int[,] points1 = GetBoundingPoints();
            int[,] points2 = explosion.GetBoundingPoints();

            int XOverlap = Math.Max(0, Math.Min(points1[3, 0], points2[3, 0]) - Math.Max(points1[0, 0], points2[0, 0])); // XOverlap is how many pixels overlap in the x direction
            int YOverlap = Math.Max(0, Math.Min(points1[3, 1], points2[3, 1]) - Math.Max(points1[0, 1], points2[0, 1])); // YOverlap is how many pixels overlap in the y direction

            int X1Start;
            int Y1Start;

            int X2Start;
            int Y2Start;

            // i believe the following if statements are to determine which pixels in our sprites need to be changed from '0' in their bitmaps, to '.' (to make them transparent)
            if (points1[0, 0] < points2[0, 0])   // if the first sprite(top left, x value) is further left than the 2nd sprite(top left, x value)
            {
                X2Start = 0;                    // the top left, x value of the 2nd sprite already is the beginning of the intersection - no adjustment needed, aka '0'
                X1Start = points2[0, 0] - points1[0, 0]; // example: if points1[0,0] = 30 and points2[0,0] = 38, then 38-30 = 8 pixels, so you'd want to add 8 to the x value of points1[0,0]
            }
            else                                // if the second sprite(top left, x value) is further left than the first sprite(top left, x value)
            {
                X1Start = 0;                             // basically the opposite of above is true, so the first sprite's top left x value is the beginning of the overlap
                X2Start = points1[0, 0] - points2[0, 0]; // and the 2nd sprite's top left x value needs to add the difference between the two sprites' top left 
                                                         // x values to itself to get the 'beginning of the intersection for the 2nd sprite's top left x value'
                                                         // i believe we will be using the sprite array and changing the values at the points of the array = points[0,0] + X1Start
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
            int relativeY = 0; 
            int j = Y1Start;
            int j2 = Y2Start;
            for (; relativeY < YOverlap; relativeY++, j++, j2++) // iterating through both the shield and bullet sprites' y values pixel by pixel 
            {
                int relativeX = 0; 
                int i = X1Start;
                int i2 = X2Start;
                for (; relativeX < XOverlap; relativeX++, i++, i2++)
                {
                    if((this.sprite.GetPixel(i, j).A != Color.Transparent.A) && (explosion.sprite.GetPixel(i2, j2).A != Color.Transparent.A))
                    {
                        this.sprite.SetPixel(i, j, Color.Transparent);
                    }
                }
            }
        }

        public override void Update()
        {
            
        }
    }
}
