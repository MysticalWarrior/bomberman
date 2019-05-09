using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace BomberMan_2._0
{
    class Player
    {
        enum Direction { up, down, left, right};
        static Direction direction;
      
        Map m = new Map();
        Rectangle playerRectangle;
        public Point updatePlayer(Point playerPoint)
        {
            
            if(m.checkWalkable() == true)
            {
                if(Keyboard.IsKeyDown(Key.W))
                {
                    if(playerPoint.Y > 0)
                    {
                        playerPoint.Y -= 64;
                    }
                }
                if(Keyboard.IsKeyDown(Key.S))
                {
                    if(playerPoint.Y < 512)
                    {
                        playerPoint.Y += 64;
                    }
                }
            }
            Canvas.SetTop(playerRectangle, playerPoint.Y);
            Canvas.SetLeft(playerRectangle, playerPoint.X);
            return playerPoint;
        }
        public void createPlayer(Brush colour, Canvas c, Point p)
        {
            playerRectangle = new Rectangle();
            playerRectangle.Height = 64;
            playerRectangle.Width = 64;
            playerRectangle.Fill = colour;


            c.Children.Add(playerRectangle);
        }
    }
}
