using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace BomberMan_2._0
{
  
    class Map
    {
        
        Rectangle[,] map = new Rectangle[15,9];
        int[,] walkable = new int[15, 9];

        public int[,] pillars = {  {0, 0, 0, 0, 0, 0, 0, 0, 0},
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

        public int[,] blocks = {   {0, 0, 1, 1, 1, 1, 1, 1, 1},
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
        public Map()
        {
            
        }
        public void initializeMap(Canvas c)
        {
            createMap(c);
            updateWalkable();
            updateMap();
            updateWalkable();
        }
        public void updateWalkable()
        {
            
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 15; y++)
                {
                    if (pillars[y, x] == 0 || blocks[y, x] == 0)
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
            if (walkable[(int)playerPoint.Y/64, (int)playerPoint.X/64] == 1)
            {
                isMove = true;
            }
            else
                isMove = false;
            return isMove;

            
        }
            
        private void updateMap()
        {
            for(int x = 0; x < 9; x++)
            {
                for(int y = 0; y < 15; y++)
                {
                    
                    if (pillars[y, x] == 1)
                    {
                        map[y,x].Fill = Brushes.Red;
                    }
                    else if(blocks[y,x] == 1)
                    {
                        map[y,x].Fill = Brushes.Yellow;
                    }
                    else if(walkable[y,x] == 1)
                    {
                        map[y,x].Fill = Brushes.Blue;
                    }
                   
                }
            }
        }
        public void createMap(Canvas c)
        {
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 15; y++)
                {
                    map[y, x] = new Rectangle();
                    map[y, x].Height = 64;
                    map[y, x].Width = 64;

                    Canvas.SetTop(map[y, x], 64 * x);
                    Canvas.SetLeft(map[y, x], 64 * y);
                    c.Children.Add(map[y, x]);
                }
            }
        }
    }
}
