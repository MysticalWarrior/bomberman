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

namespace Bomberman
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //public objects:
        Game game;
        Canvas cGame;
        Menu menu;
        public enum GameState { startMenu, optionsMenu, gameOn, gameOver }
        public static GameState gamestate;
        public static int playerNumber;
        DispatcherTimer gameTimer;
        MediaPlayer music = new MediaPlayer();

        public MainWindow()
        {
            InitializeComponent();
            menu = new Menu(canvas, BtnPlay_Click, BtnHowToPlay_Click ,BtnControls_Click, BtnQuit_Click, BtnBack_Click);
            cGame = new Canvas();

            gameTimer = new DispatcherTimer();
            gameTimer.Tick += gameTimer_Tick;
            gameTimer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 15); //15 frames(ticks)/second
        }

        /// <summary>
        /// Authors
        /// Ethan Shipston
        /// each player uses a set of keys to move in 4 directions and place a bomb. 
        /// Ethan set it so the player can change their controls (a menu with textboxes that contain default values
        /// </summary>
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            game.updateGame();
            menu.EndGame(gameTimer, cGame, playerNumber);
        }

        private void BtnPlay_Click(object sender, RoutedEventArgs e)
        {
            menu.removeAll();
            game = new Game(cGame);
            canvas.Children.Add(cGame);
            gameTimer.Start();
        }
        private void BtnControls_Click(object sender, RoutedEventArgs e)
        {
            menu.createControlsMenu();
        }
        private void BtnQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            menu.createMainMenu("Bomberman");
        }
        private void BtnHowToPlay_Click(object sender, RoutedEventArgs e)
        {
            menu.createHowToPlay();
        }
    }
}
