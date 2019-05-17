/*/* Sebastian Horton, Ethan Shipston
 * Friday May 17th, 2019
 *  The menu interface for bomberman
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

    class Menu
    {
        //each menu gets a canvas
        Canvas c;
        Canvas cControls;
        Canvas cHowToPlay;
        Canvas cMainMenu;
        Canvas cGameOverMenu;
        RoutedEventHandler btnPlay_Click;
        RoutedEventHandler btnHowToPlay_Click;
        RoutedEventHandler btnControls_Click;
        RoutedEventHandler btnQuit_Click;
        RoutedEventHandler btnBack_Click;

        /// <summary>
        /// Authors
        /// Sebastian Horton
        /// creates the initial start menu
        /// </summary>
        public Menu(Canvas canvas, RoutedEventHandler BtnPlay_Click, RoutedEventHandler BtnHowToPlay_Click, RoutedEventHandler BtnControls_Click, RoutedEventHandler BtnQuit_Click, RoutedEventHandler BtnBack_Click)
        {
            c = canvas;
            cControls = new Canvas();
            cHowToPlay = new Canvas();
            cMainMenu = new Canvas();
            cGameOverMenu = new Canvas();
            btnPlay_Click = BtnPlay_Click;
            btnHowToPlay_Click = BtnHowToPlay_Click;
            btnControls_Click = BtnControls_Click;
            btnQuit_Click = BtnQuit_Click;
            btnBack_Click = BtnBack_Click;
            createMainMenu("Bomberman");

        }
        /// <summary>
        /// Authors
        /// Ethan Shipston
        /// creates a TextBlock
        /// </summary>
        private void addTextBlock(dynamic item, int xPos, int yPos, int width, Brush colour, string content, Canvas sp)
        {
            item.Width = width;

            item.Background = colour;
            item.Text = content;
            item.FontSize = 35;

            Canvas.SetTop(item, yPos);
            Canvas.SetLeft(item, xPos);
            sp.Children.Add(item);
        }
        /// <summary>
        /// Authors
        /// Ethan Shipston
        /// creates a WPF button
        /// </summary>
        private void addButton(Button btn, int xPos, int yPos, int width, int Height, int fontSize, Brush colour, string content, RoutedEventHandler btn_Click, Canvas c)
        {
            btn.Click += btn_Click;
            btn.Height = Height;
            btn.Width = width;
            btn.Background = colour;

            btn.Content = content;
            btn.FontSize = fontSize;

            Canvas.SetTop(btn, yPos);
            Canvas.SetLeft(btn, xPos);
            c.Children.Add(btn);
        }
        /// <summary>
        /// Authors
        /// Ethan Shipston, Sebastian Horton
        /// Creates the main menu
        /// </summary>
        public void createMainMenu(string title)
        {
            removeAll();

            TextBlock txtTitle = new TextBlock();
            txtTitle.TextAlignment = TextAlignment.Center;
            addTextBlock(txtTitle, 300, 50, 300, Brushes.DarkGray, title, cMainMenu);
            Button btnPlay = new Button();
            addButton(btnPlay, 300, 150, 300, 145, 50, Brushes.DarkGray, "Play", btnPlay_Click, cMainMenu);
            Button btnControls = new Button();
            addButton(btnControls, 350, 300, 200, 100, 35, Brushes.DarkGray, "Controls", btnControls_Click, cMainMenu);

            Button btnHowToPlay = new Button();
            addButton(btnHowToPlay, 350, 405, 200, 100, 35, Brushes.DarkGray, "How To Play", btnHowToPlay_Click, cMainMenu);

            Button btnQuit = new Button();
            addButton(btnQuit, 350, 510, 200, 100, 35, Brushes.DarkGray, "Quit", btnQuit_Click, cMainMenu);
            c.Children.Add(cMainMenu);
        }

        public void createHowToPlay()
        {
            removeAll();

            TextBlock txtblk = new TextBlock();
            addTextBlock(txtblk, 0, 0, 1000, Brushes.LightGray, "Welcome to Bomberman!" +
                "\nYour goal is to beat the other player\n" +
                "by blowing them up with your bomb!" +
                "\nBe careful not to get caught in your own bomb,\n" +
                "doing that will kill you too.",
                cHowToPlay);

            Button btnBack = new Button();
            addButton(btnBack, 350, 600, 150, 50, 35, Brushes.LightGray, "Back", btnBack_Click, cHowToPlay);

            c.Children.Add(cHowToPlay);
        }
        /// <summary>
        /// Authors
        /// Ethan Shipston, Sebastian Horton
        /// creates the controls menu
        /// </summary>
        public void createControlsMenu()
        {
            removeAll();


            TextBlock txtPlayer1 = new TextBlock();
            addTextBlock(txtPlayer1, 170, 50, 250, Brushes.LightGray, "Player 1", cControls);


            TextBlock txtUpHeader1 = new TextBlock();
            addTextBlock(txtUpHeader1, 170, 150, 90, Brushes.Red, "Up", cControls);
            TextBlock txtUp1 = new TextBlock();
            addTextBlock(txtUp1, 270, 150, 150, Brushes.LightGray, "W", cControls);

            TextBlock txtDownHeader1 = new TextBlock();
            addTextBlock(txtDownHeader1, 170, 250, 90, Brushes.Red, "Down", cControls);
            TextBlock txtDown1 = new TextBlock();
            addTextBlock(txtDown1, 270, 250, 150, Brushes.LightGray, "S", cControls);

            TextBlock txtLeftHeader1 = new TextBlock();
            addTextBlock(txtLeftHeader1, 170, 350, 90, Brushes.Red, "Left", cControls);
            TextBlock txtLeft1 = new TextBlock();
            addTextBlock(txtLeft1, 270, 350, 150, Brushes.LightGray, "A", cControls);

            TextBlock txtRightHeader1 = new TextBlock();
            addTextBlock(txtRightHeader1, 170, 450, 90, Brushes.Red, "Right", cControls);
            TextBlock txtRight1 = new TextBlock();
            addTextBlock(txtRight1, 270, 450, 150, Brushes.LightGray, "D", cControls);

            TextBlock txtPlaceHeader1 = new TextBlock();
            addTextBlock(txtPlaceHeader1, 170, 550, 90, Brushes.Red, "Bomb", cControls);
            TextBlock txtPlace1 = new TextBlock();
            addTextBlock(txtPlace1, 270, 550, 250, Brushes.LightGray, "Left Shift", cControls);

            TextBlock txtPlayer2 = new TextBlock();
            addTextBlock(txtPlayer2, 530, 50, 250, Brushes.LightGray, "Player 2", cControls);

            TextBlock txtUpHeader2 = new TextBlock();
            addTextBlock(txtUpHeader2, 530, 150, 90, Brushes.Blue, "Up", cControls);
            TextBlock txtUp2 = new TextBlock();
            addTextBlock(txtUp2, 630, 150, 250, Brushes.LightGray, "Up Arrow", cControls);

            TextBlock txtDownHeader2 = new TextBlock();
            addTextBlock(txtDownHeader2, 530, 250, 90, Brushes.Blue, "Down", cControls);
            TextBlock txtDown2 = new TextBlock();
            addTextBlock(txtDown2, 630, 250, 250, Brushes.LightGray, "Down Arrow", cControls);

            TextBlock txtLeftHeader2 = new TextBlock();
            addTextBlock(txtLeftHeader2, 530, 350, 90, Brushes.Blue, "Left", cControls);
            TextBlock txtLeft2 = new TextBlock();
            addTextBlock(txtLeft2, 630, 350, 250, Brushes.LightGray, "Left Arrow", cControls);

            TextBlock txtRightHeader2 = new TextBlock();
            addTextBlock(txtRightHeader2, 530, 450, 90, Brushes.Blue, "Right", cControls);
            TextBlock txtRight2 = new TextBlock();
            addTextBlock(txtRight2, 630, 450, 250, Brushes.LightGray, "Right Arrow", cControls);

            TextBlock txtPlaceHeader2 = new TextBlock();
            addTextBlock(txtPlaceHeader2, 530, 550, 90, Brushes.Blue, "Bomb", cControls);
            TextBlock txtPlace2 = new TextBlock();
            addTextBlock(txtPlace2, 630, 550, 250, Brushes.LightGray, "Right Ctrl", cControls);

            Button btnBack = new Button();
            addButton(btnBack, 350, 610, 150, 50, 35, Brushes.LightGray, "Back", btnBack_Click, cControls);

            c.Children.Add(cControls);
        }

        /// <summary>
        /// Authors
        /// Ethan Shipston, Sebastian Horton
        ///creates a version of the start menu with differing headers and backgrounds
        /// </summary>
        public void createGameOverMenu(int i)
        {
            removeAll();
            createMainMenu("Player " + i + " Wins!");
            c.Children.Add(cGameOverMenu);
            if (i == 1)
            {
                c.Background = Brushes.Red;
            }
            else
                c.Background = Brushes.Blue;


        }

        /// <summary>
        /// Authors
        /// Ethan Shipston, Sebastian Horton
        /// stops the game and creates the "game over" screen
        /// </summary>
        public void EndGame(DispatcherTimer timer, Canvas cGame, int i)
        {
            if (MainWindow.gamestate == MainWindow.GameState.gameOver)
            {
                timer.Stop();
                removeAll();
                createGameOverMenu(i);
                c.Children.Remove(cGame);
            }
        }

        /// <summary>
        /// Authors
        /// Ethan Shipston, Sebastian Horton
        /// removes all items from the main canvas
        /// </summary>
        public void removeAll()
        {
            c.Background = Brushes.Purple;
            c.Children.Remove(cControls);
            c.Children.Remove(cMainMenu);
            c.Children.Remove(cGameOverMenu);
            c.Children.Remove(cHowToPlay);
        }
    }
}
