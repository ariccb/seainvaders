﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace seainvaders
{
    class Squid : Enemy
    {
        public override char[,] graphic0
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
        public override char[,] graphic1
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
                return 8;
            }
        }


        public Squid(int x, int y) : base(x, y)
        {
        }
    }
}
