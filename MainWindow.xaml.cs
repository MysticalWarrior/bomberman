/* Sebastian Horton, Ethan Shipston, Logan Ellis, Elliot McArthur
 * Friday May 17th, 2019
 * The video game Bomberman recreated in C#
 **/
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /*Ethan add appropriate music*/

        //public objects:

        Map map;

        Player player1;
        Point player1Point;
       
        Player player2;
        Point player2Point;
        
        List<Point> playerPoints = new list<Point>();
        
        DispatcherTimer gameTimer;
       
        public MainWindow()
        {
            InitializeComponent();

            map = new Map(canvas); //construct map.

            player1Point = new Point(0, 0);
            playerPoints.add(player1Point);
            player1 = new Player(canvas, Brushes.DarkRed, player1Point, 1);  //construct player1 in top left corner

            player2Point = new Point(896, 512); 
            playerPoints.add(player2Point);
            player2 = new Player(canvas, Brushes.DarkBlue, player2Point, 2); //construct player2 in bottom right corner


            gameTimer = new DispatcherTimer();
            gameTimer.Tick += gameTimer_Tick;
            gameTimer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 30); //30 frames(ticks)/second
            gameTimer.Start();

        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //each player uses a set of keys to move in 4 directions and place a bomb. 
            /*Ethan set it so the player can change their controls (a menu with textboxes that contain default values)*/
            foreach(Point p in playerPoints)
            {
                bomb.isPlayerDead(p);
            }
            player1.updatePlayer(Key.W, Key.S, Key.A, Key.D, Key.LeftShift); 
            player2.updatePlayer(Key.Up, Key.Down, Key.Left, Key.Right, Key.RightCtrl);
            
        }
    }
}
