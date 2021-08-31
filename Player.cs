using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace seainvaders
{
    class Player : Entity
    {
        public char[,] graphic =
            {
                { '.','.','.','.','.','.','0','.','.','.','.','.','.'},
                { '.','.','.','.','.','0','0','0','.','.','.','.','.'},
                { '.','.','.','.','.','0','0','0','.','.','.','.','.'},
                { '.','0','0','0','0','0','0','0','0','0','0','0','.'},
                { '0','0','0','0','0','0','0','0','0','0','0','0','0'},
                { '0','0','0','0','0','0','0','0','0','0','0','0','0'},
                { '0','0','0','0','0','0','0','0','0','0','0','0','0'},
                { '0','0','0','0','0','0','0','0','0','0','0','0','0'},
            };

        public int vx;
        public Bullet bullet;
        public override int height
        {
            get
            {
                return 8;
            }
        }
        public override int width
        {
            get
            {
                return 13;
            }
        }

        public Player() : base()
        {
            vx = 0;
            y = 211;
            x = 105;
            sprite = new Bitmap(width, height); // homework - try to abstract out this code into all other classes
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (graphic[i, j] == '.')
                    {
                        sprite.SetPixel(j, i, Color.Transparent);
                    }
                    else
                    {
                        sprite.SetPixel(j, i, Color.DarkSeaGreen);
                    }
                }
            }
        }
        public override void Update()
        {
            if (Game.keys.Contains("left") && x > 0)
            {
                vx = -2;
            }
            else if (Game.keys.Contains("right") && x < 223)
            {
                vx = 2;
            }
            else
            {
                vx = 0;
            }
            x += vx;
            // movement logic
            
            if (Game.keys.Contains("space"))
            { 
                if (bullet == null)
                {
                    bullet = new Bullet();
                    bullet.x = x + 6; // to align to centre of player
                    bullet.y = y - 4; // because we want the top of the bullet at the 'start' of the player
                    bullet.Deleted += Bullet_Deleted; //Bullet_Deleted is an event listener
                }
            }
            // shooting logic
        }

        private void Bullet_Deleted(object sender, EventArgs e)
        {
            bullet = null; //this deletes the bullet
        }
    }
}