using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seainvaders
{
    class ProjectileExplosion : Entity
    {
        public char[,] Graphic
        {
            get
            {
                char[,] val =
                {
                    {'.','.','0','.','.','.'},
                    {'0','.','.','.','0','.'},
                    {'.','.','0','0','.','0'},
                    {'.','0','0','0','0','.'},
                    {'0','.','0','0','0','.'},
                    {'.','0','0','0','0','0'},
                    {'0','.','0','0','0','.'},
                    {'.','0','.','0','.','0'},
                };
                return val;
            }

        }

        int timer = 0;

        public ProjectileExplosion(int x, int y) : base()
        {
            this.x = x;
            this.y = y;
            SetGraphic(Graphic);
        }

        public override void Update()
        {
            if (timer < 20)
            {
                timer++;
            }
            else
            {
                Delete();
            }
        }
    }
}
