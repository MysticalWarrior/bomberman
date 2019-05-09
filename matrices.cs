using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BomberMan_2._0
{
    class Matrices
    {
        public static int[,] walkable = new int[15, 9];

        public static int[,] bomb = new int[15, 9];

        public static int[,] pillars = {  {0, 0, 0, 0, 0, 0, 0, 0, 0},
                                   {0, 1, 0, 1, 0, 1, 0, 1, 0},
                                   {0, 0, 0, 0, 0, 0, 0, 0, 0},
                                   {0, 1, 0, 1, 0, 1, 0, 1, 0},
                                   {0, 0, 0, 0, 0, 0, 0, 0, 0},
                                   {0, 1, 0, 1, 0, 1, 0, 1, 0},
                                   {0, 0, 0, 0, 0, 0, 0, 0, 0},
                                   {0, 1, 0, 1, 0, 1, 0, 1, 0},
                                   {0, 0, 0, 0, 0, 0, 0, 0, 0},
                                   {0, 1, 0, 1, 0, 1, 0, 1, 0},
                                   {0, 0, 0, 0, 0, 0, 0, 0, 0},
                                   {0, 1, 0, 1, 0, 1, 0, 1, 0},
                                   {0, 0, 0, 0, 0, 0, 0, 0, 0},
                                   {0, 1, 0, 1, 0, 1, 0, 1, 0},
                                   {0, 0, 0, 0, 0, 0, 0, 0, 0}   };

        public static int[,] blocks = {   {0, 0, 1, 1, 1, 1, 1, 1, 1},
                                   {0, 0, 1, 0, 1, 0, 1, 0, 1},
                                   {1, 1, 1, 1, 1, 1, 1, 1, 1},
                                   {1, 0, 1, 0, 1, 0, 1, 0, 1},
                                   {1, 1, 1, 1, 1, 1, 1, 1, 1},
                                   {1, 0, 1, 0, 1, 0, 1, 0, 1},
                                   {1, 1, 1, 1, 1, 1, 1, 1, 1},
                                   {1, 0, 1, 0, 1, 0, 1, 0, 1},
                                   {1, 1, 1, 1, 1, 1, 1, 1, 1},
                                   {1, 0, 1, 0, 1, 0, 1, 0, 1},
                                   {1, 1, 1, 1, 1, 1, 1, 1, 1},
                                   {1, 0, 1, 0, 1, 0, 1, 0, 1},
                                   {1, 1, 1, 1, 1, 1, 1, 1, 1},
                                   {1, 0, 1, 0, 1, 0, 1, 0, 0},
                                   {1, 1, 1, 1, 1, 1, 1, 0, 0}   };
        public void updateWalkable()
        {

            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 15; y++)
                {
                    if (pillars[y, x] == 0 && blocks[y, x] == 0)
                    {
                        walkable[y, x] = 1;
                    }

                }
            }
        }
        public bool checkWalkable()
        {
            Point playerPoint = new Point(0, 0);
            bool isMove = false;
            updateWalkable();
            if (walkable[(int)playerPoint.Y / 64, (int)playerPoint.X / 64] == 1)
            {
                isMove = true;
            }
            else
                isMove = false;
            return isMove;


        }
    }
}
