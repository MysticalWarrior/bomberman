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
        enum GameState { startMenu, optionsMenu, gameOn, gameOver}
        GameState gamestate;
        Game game;
        
        DispatcherTimer gameTimer;
       
        public MainWindow()
        {
            InitializeComponent();



            gameTimer = new DispatcherTimer();
            gameTimer.Tick += gameTimer_Tick;
            gameTimer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 15); //30 frames(ticks)/second
            gameTimer.Start();

        }

        /// <summary>
        /// Authors
        /// Ethan Shipston
        /// each player uses a set of keys to move in 4 directions and place a bomb. 
        /// Ethan set it so the player can change their controls (a menu with textboxes that contain default values
        /// </summary>
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (gamestate == GameState.gameOn)
            {
                game.updateGame();
            }
            else if(gamestate == GameState.optionsMenu)
            {
                btnOptions.Visibility = Visibility.Hidden;
                btnStart.Visibility = Visibility.Hidden;

                TextBlock txtPlayer1 = new TextBlock();
               
                txtPlayer1.Height = 100;
                txtPlayer1.Width = 250;

                txtPlayer1.Text = "Player 1";
                txtPlayer1.Background = Brushes.LightGray;
                txtPlayer1.FontSize = 35;
                TextBlock.SetTextAlignment(txtPlayer1, TextAlignment.Center);

                canvas.Children.Add(txtPlayer1);


                TextBox txtUp = new TextBox();

                txtUp.Height = 50;
                txtUp.Width = 250;

                txtUp.Text = "w".ToUpper();
                txtUp.Background = Brushes.LightGray;
                txtUp.FontSize = 35;
                canvas.Children.Add(txtUp);


                TextBox txtDown = new TextBox();
                txtDown.Text = "w".ToUpper();
                canvas.Children.Add(txtDown);


                TextBox txtLeft = new TextBox();
                txtLeft.Text = "w".ToUpper();
                canvas.Children.Add(txtLeft);


                TextBox txtRight = new TextBox();
                txtRight.Text = "w".ToUpper();
                canvas.Children.Add(txtRight);

            }
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            gamestate = GameState.gameOn;
            game = new Game(canvas);
        }

        private void BtnOptions_Click(object sender, RoutedEventArgs e)
        {
            gamestate = GameState.optionsMenu;
        }
        private void addTextBox(dynamic item, int xPos, int yPos, int hieght, int width, Brush colour)
        {
            item.Height = Height;
            item.Width = width;

            item.Fill = colour;
            item.FontSize = 35;

            item.SetTextAlignment(item, TextAlignment.Center);
            Canvas.SetTop(item, yPos);

        }
    }
}
