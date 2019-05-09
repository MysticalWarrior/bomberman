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
        Point playerPoint;
        Rectangle playerRectangle;
        enum Direction { down, up, left, right}
        static Direction direction;
        public Player(Canvas c, Brush colour, Point p)
        {
            playerRectangle = new Rectangle();

            playerPoint.X = p.X;
            playerPoint.Y = p.Y;

            playerRectangle.Height = 64;
            playerRectangle.Width = 64;
            playerRectangle.Fill = colour;

            Canvas.SetTop(playerRectangle, playerPoint.Y);
            Canvas.SetLeft(playerRectangle, playerPoint.X);
            c.Children.Add(playerRectangle);
        }

        public Point updatePlayer(Key up, Key down, Key left, Key right)
        {

            movePlayer(up, down, left, right);
            Canvas.SetTop(playerRectangle, playerPoint.Y);
            Canvas.SetLeft(playerRectangle, playerPoint.X);
            return playerPoint;
        }
        private void movePlayer(Key up, Key down, Key left, Key right)
        {
            if(Keyboard.IsKeyDown(up) && playerPoint.Y > 0)
            {
                if (checkPlayer(-1, 0) == true)
                {
                    playerPoint.Y -= 64;
                }
            }
            else if(Keyboard.IsKeyDown(down) && playerPoint.Y < 512)
            {
                if (checkPlayer(1, 0) == true)
                {
                    playerPoint.Y += 64;
                }
            }
            else if(Keyboard.IsKeyDown(right) && playerPoint.X < 896)
            {
                if (checkPlayer(0, 1) == true)
                {
                    playerPoint.X += 64;
                }
            }
            else if(Keyboard.IsKeyDown(left) && playerPoint.X > 0)
            {
                if (checkPlayer(0, -1) == true)
                {
                    playerPoint.X -= 64;
                }
               
            }
        }
        private bool checkPlayer(int offsetX, int offsetY)
        {
            int playerPosX = ((int)playerPoint.X / 64) + offsetX;
            int playerposY = ((int)playerPoint.Y / 64) + offsetY;

            if(playerPosX <= 0)
            {
                playerPosX = 0;
            }
            else if(playerPosX >= 14)
            {
                playerPosX = 14;
            }
            if(playerposY <= 0)
            {
                playerposY = 0;
            }
            else if(playerposY >= 8)
            {
                playerposY = 8;
            }
            if (Matrices.walkable[playerPosX, playerposY] == 1)
            {
                return true;
            }
            else return false;
        }
    }
}
