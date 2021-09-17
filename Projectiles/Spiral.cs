using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seainvaders
{
    class Spiral : Projectile
    {
        public override char[][,] graphics
        {
            get
            {
                char[][,] val = new char[4][,];
                val[0] = new char[,]
                {
                    {'.','0','.'},
                    {'.','0','.'},
                    {'.','0','.'},
                    {'.','0','.'},
                    {'.','0','.'},
                    {'.','0','.'},
                    {'.','0','.'},
                    {'.','.','.'},
                };
                val[1] = new char[,]
                {
                    {'.','0','.'},
                    {'.','0','.'},
                    {'0','0','.'},
                    {'.','0','0'},
                    {'.','0','.'},
                    {'0','0','.'},
                    {'.','0','0'},
                    {'.','.','.'},
                };
                val[2] = new char[,]
                {
                    {'.','0','.'},
                    {'.','0','.'},
                    {'.','0','.'},
                    {'.','0','.'},
                    {'.','0','.'},
                    {'.','0','.'},
                    {'.','0','.'},
                    {'.','.','.'},
                };
                val[3] = new char[,]
                {
                    {'.','0','0'},
                    {'0','0','.'},
                    {'.','0','.'},
                    {'.','0','0'},
                    {'0','0','.'},
                    {'.','0','.'},
                    {'.','0','.'},
                    {'.','.','.'},
                };
                return val;
            }

        }
        public Spiral(int x, int y) : base(x, y)
        {
            
        }
    }
}
