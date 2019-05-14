/* Sebastian Horton
 * Friday May 17th, 2019
 * A class that creates, arms and detonates bombs.
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace BomberMan_2._0
{
    class Bomb
    {
        Matrices matrices = new Matrices();
        public bool bombPlaced; //true if a bomb is currently placed but hasnt exploded, (else false).
        
        //class-wide variables
        DispatcherTimer bombTimer = new DispatcherTimer();
        public int bombFuse;
        static Point bombPos;

        //creates the bomb.
        public Bomb(Point p)
        {
                bombPlaced = true;
                bombFuse = 2;
                armBomb(p);
        }

        //triggers the fuse count down and updates the matrix.
        public Point armBomb(Point p)
        {
            bombPos = new Point((int)p.X/64, (int)p.Y/64);
            bombFuse = 4;

            Matrices.bomb[(int)bombPos.X, (int)bombPos.Y] = 1;
            Map.colourMap();
            bombTimer.Start();

            return bombPos;
        }
        
        //checks if the explosion is within the map and updates the matrix.
        public int[,] explosion()
        {
            int x = (int)bombPos.X;
            int y = (int)bombPos.Y;


            if (x + 1 < 15)
            {
                Matrices.bomb[x + 1, y] = 1;
            }

            if (x - 1 > -1)
            {
                Matrices.bomb[x - 1, y] = 1;
            }

            if (y + 1 < 9)
            {
                Matrices.bomb[x, y + 1] = 1;
            }

            if (y - 1 > -1)
            {
                Matrices.bomb[x, y - 1] = 1;
            }


            Map.colourBombs();

            return Matrices.bomb;
        }

        //resets the fuse, updates the matrix and redraws the map.
        public bool resetBomb()
        {
                bombFuse = 2;
                Matrices.bomb[(int)bombPos.X, (int)bombPos.Y] = 0;
                Matrices.updateBlocks();
                Matrices.updateWalkable();
                Map.colourMap();
                bombTimer.Stop();
                bombPlaced = false;
                return true;
        }

        //checks for the fuse's length (int value). 
        //If the fuse is at 0 then detonate the bomb (shows blast radius).
        //If the fuse when off 1 tick ago it resets (removes blast radius and redraws map).
        public void update()
        {
            /*Ethan add spritesheet logic here based on bombfuse value*/
          
               
        }

        //checks if the player is in the blast radius. Checks at the main timer tick rate (not the bomb tick rate).


    }
}

    

