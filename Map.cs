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
        Matrices matrices = new Matrices();      
        Rectangle[,] map = new Rectangle[15,9];
        
        public Map(Canvas c)
        {
            updateMap(c);
        }
        
            
        private void updateMap(Canvas c)
        {
            matrices.updateWalkable();

            for (int x = 0; x < 9; x++)
            {
                for(int y = 0; y < 15; y++)
                {
                    map[y, x] = new Rectangle();
                    map[y, x].Height = 64;
                    map[y, x].Width = 64;

                    if (Matrices.pillars[y, x] == 1)
                    {
                        map[y,x].Fill = Brushes.Red;
                    }
                    else if(Matrices.blocks[y,x] == 1)
                    {
                        map[y,x].Fill = Brushes.Yellow;
                    }
                    else if(Matrices.walkable[y,x] == 1)
                    {
                        map[y,x].Fill = Brushes.Blue;
                    }
                   
                            
                    Canvas.SetTop(map[y, x], 64 * x);
                    Canvas.SetLeft(map[y, x], 64 * y);
                    c.Children.Add(map[y, x]);
                        
                    }
                }
            }
    }
}
