/* Sebastion Horton
 * Tuesday, May 14, 2019
 * Class that creates and updates the game
 */
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

namespace Bomberman
{
    class Game
    {
        Matrices matrix;
        Map map;
        public int playerDead = 0;

        Player player1;
        Point player1Point;

        Player player2;
        Point player2Point;

        public Game(Canvas c)
        {
            //creates/resets the matrices and map
            MainWindow.gamestate = MainWindow.GameState.gameOn;
            matrix = new Matrices();
            map = new Map(c);
            Matrices.removeBombs();
           
            //construct player1 in top left corner
            player1Point = new Point(0, 0);
            player1 = new Player(c, new ImageBrush(new BitmapImage(new Uri("Sprites/Player2forward.png", UriKind.Relative))), player1Point, Key.W, Key.S, Key.A, Key.D, Key.LeftShift);

            //construct player2 in bottom right corner
            player2Point = new Point(896, 512);
            player2 = new Player(c, new ImageBrush(new BitmapImage(new Uri("Sprites/Player1forward.png", UriKind.Relative))), player2Point, Key.Up, Key.Down, Key.Left, Key.Right, Key.RightCtrl);
        }
        public void updateGame()
        {
            //passes an int to determine the winner
            player1.updatePlayer(2); 
            player2.updatePlayer(1);
        }
    }
}