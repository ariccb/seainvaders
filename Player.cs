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
        public int lives = 3;

        public Player() : base()
        {
            vx = 0;
            y = 211;
            x = 105;
            SetGraphic(graphic);
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

        public void Hit()
        {
            if (--lives <= 0)
            {
                Delete();
            }
        }
    }
}