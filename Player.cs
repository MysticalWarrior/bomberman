/*
 * Sebastian Horton, Logan Ellis
 * Friday May 17th, 2019
 * A class that controls the players movements and interacts with the bomb class to place bombs.
 * */
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

        //class-wide variables:
        Point playerPoint;
        Rectangle playerRectangle;

        /// <summary>
        /// Authors
        /// Sebastian Horton, Logan Ellis
        /// creates a player rectangle with a hieght, width, colour and position on the canvas.
        /// </summary>
        public Player(Canvas c, Brush colour, Point p) 
        {
            playerPoint.X = p.X;
            playerPoint.Y = p.Y;
            playerRectangle = new Rectangle();

            playerRectangle.Height = 64;
            playerRectangle.Width = 64;
            playerRectangle.Fill = colour;

            Canvas.SetTop(playerRectangle, playerPoint.Y);
            Canvas.SetLeft(playerRectangle, playerPoint.X);
            c.Children.Add(playerRectangle);
        }

        /// <summary>
        /// Authors
        /// Sebastian Horton, Logan Ellis
        /// Updates the player after they take an action (place a bomb or move).
        /// </summary>
        public Point updatePlayer(Key up, Key down, Key left, Key right) 
        {
            movePlayer(up, down, left, right);
          
            Canvas.SetTop(playerRectangle, playerPoint.Y);
            Canvas.SetLeft(playerRectangle, playerPoint.X);

            return playerPoint;
        }

        /// <summary>
        /// Authors
        /// Sebastian Horton, Logan Ellis
        /// takes the players input based on their controls and makes sure that they're within the map.
        /// </summary>
        private void movePlayer(Key up, Key down, Key left, Key right)
        {
            if(Keyboard.IsKeyDown(up) && playerPoint.Y > 0) 
            {
                if (checkPlayer( 0, -1) == true) //the player would move up one square in the y direction (y -1).
                {
                    playerPoint.Y -= 64;
                    return;
                }
            }
            else if(Keyboard.IsKeyDown(down) && playerPoint.Y < 512)
            {
                if (checkPlayer(0,1) == true) //the player would move down one square in the y direction (y + 1).
                {
                    playerPoint.Y += 64;
                    return;
                }
            }
            else if(Keyboard.IsKeyDown(right) && playerPoint.X < 896)
            {
                if (checkPlayer(1,0) == true) //the player would increase their x position by one (x + 1).
                {
                    playerPoint.X += 64;
                    return;
                }
            }
            else if(Keyboard.IsKeyDown(left) && playerPoint.X > 0)
            {
                if (checkPlayer(-1, 0) == true) //the player would decrease their x position by one (x - 1).
                {
                    playerPoint.X -= 64;
                    return;
                }
               
            }
        }


        /// <summary>
        /// Authors
        /// Sebastian Horton, Logan Ellis
        /// takes the players future position and checks what type of square it is (block, pillar or walkable).
        /// </summary>
        private bool checkPlayer(int offsetX, int offsetY)
        {
            int playerPosX = ((int)playerPoint.X / 64);
            int playerPosY = ((int)playerPoint.Y / 64);
            int futureValueX = playerPosX + offsetX;
            int futureValueY = playerPosY + offsetY;
           
            //the player's cordinates on the grid must be within (0-14, 0-9).
            if(futureValueX <= 0)
            {
                futureValueX = 0;
            }
            else if(futureValueX > 14)
            {
                futureValueX = 14;
            }
            if(futureValueY <= 0)
            {
                futureValueY = 0;
            }
            else if(futureValueY > 9)
            {
                futureValueY = 9;
            }

            if (Matrices.walkable[futureValueX, futureValueY] == 1)
            {
                return true;
            }
            else
                return false;
            
        }

      //returns the player's position
        public Point getPlayerPos()
        {
            return playerPoint;
        }
    }
}
