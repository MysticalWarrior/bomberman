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
        //class declerations:
        static Bomb bomb = new Bomb(); 

        //class-wide variables:
        Point playerPoint;
        Rectangle playerRectangle;
        int playerNumber; 
       
        //creates a player rectangle with a hieght, width, colour and position on the canvas.
        public Player(Canvas c, Brush colour, Point p, int player) 
        {
            playerNumber = player;
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

        //Updates the player after they take an action (place a bomb or move).
        public Point updatePlayer(Key up, Key down, Key left, Key right, Key place) 
        {
            placeBomb(place);
            movePlayer(up, down, left, right);
          
            Canvas.SetTop(playerRectangle, playerPoint.Y);
            Canvas.SetLeft(playerRectangle, playerPoint.X);

            return playerPoint;
        }

        //takes the players input based on their controls and makes sure that they're within the map.
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
        
        //takes the players future position and checks what type of square it is (block, pillar or walkable).
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

        //if the player presses the "place" key it will check if this player already has a bomb placed that hasn't exploded.
        //If there is no bomb placed then it runs the Bomb class' function armBomb.
        private void placeBomb(Key place)
        {
            
            if (Keyboard.IsKeyDown(place))
            {
                if (bomb.bombPlaced == false)
                { 
                    bomb.armBomb((int)playerPoint.X / 64, (int)playerPoint.Y / 64);
                }
            }
        }
    }
}
