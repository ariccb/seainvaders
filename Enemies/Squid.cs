using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace seainvaders
{
    class Squid : Enemy
    {
        public override char[,] Graphic0
        {
            get
            {
                char[,] val =
                {
                    {'.','.','.','0','0','.','.','.'},
                    {'.','.','0','0','0','0','.','.'},
                    {'.','0','0','0','0','0','0','.'},
                    {'0','0','.','0','0','.','0','0'},
                    {'0','0','0','0','0','0','0','0'},
                    {'.','.','0','.','.','0','.','.'},
                    {'.','0','.','0','0','.','0','.'},
                    {'0','.','0','.','.','0','.','0'},
                };
                return val;
            }
        }
        public override char[,] Graphic1
        {
            get
            {
                char[,] val =

                {
                    {'.','.','.','0','0','.','.','.'},
                    {'.','.','0','0','0','0','.','.'},
                    {'.','0','0','0','0','0','0','.'},
                    {'0','0','.','0','0','.','0','0'},
                    {'0','0','0','0','0','0','0','0'},
                    {'.','0','.','0','0','.','0','.'},
                    {'0','.','.','.','.','.','.','0'},
                    {'.','0','.','.','.','.','0','.'},
                };
                return val;
            }
        }
        public Squid(int x, int y) : base(x, y)
        {
        }
    }
}
