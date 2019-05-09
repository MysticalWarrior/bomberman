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
        Map map;
        Player player1;
        Player player2;
        DispatcherTimer gameTimer;
        Point player1Point;
        Point player2Point;
        public MainWindow()
        {
            InitializeComponent();
            player1Point = new Point(0, 0);
            player2Point = new Point(896, 512);
            map = new Map(canvas);
            player1 = new Player(canvas, Brushes.DarkRed, player1Point);
            player2 = new Player(canvas, Brushes.DarkBlue, player2Point);
            gameTimer = new DispatcherTimer();
            
            
          
            
          
            gameTimer.Tick += gameTimer_Tick;
            gameTimer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 60);
            gameTimer.Start();

        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            player1.updatePlayer(Key.W, Key.S, Key.A, Key.D);
            player2.updatePlayer(Key.Up, Key.Down, Key.Left, Key.Right);
            
        }
    }
}
