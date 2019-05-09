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
        DispatcherTimer gameTimer = new DispatcherTimer();
        Player player1 = new Player();
        Point player1Point = new Point(0, 0);
        public MainWindow()
        {
            InitializeComponent();
           
            Map map = new Map();
            map.initializeMap(canvas);
            
            player1.createPlayer(Brushes.DarkRed, canvas, player1Point);
            gameTimer.Tick += gameTimer_Tick;
            gameTimer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 60);
            gameTimer.Start();

        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            player1.updatePlayer(player1Point);
        }
    }
}
