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
        Canvas cMainMenu;
        Canvas cGameOverMenu;
       
        /// <summary>
        /// Authors
        /// Sebastian Horton
        /// creates the initial start menu
        /// </summary>
        public Menu(Canvas canvas, RoutedEventHandler btnPlay_Click, RoutedEventHandler btnControls_Click, RoutedEventHandler btnQuit_Click)
        {
            c = canvas;
            cControls = new Canvas();
            cMainMenu = new Canvas();
            cGameOverMenu = new Canvas();
            createMainMenu(btnPlay_Click, btnControls_Click, btnQuit_Click, "Bomberman");

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
        public void createMainMenu(RoutedEventHandler btnPlay_Click, RoutedEventHandler btnControls_Click, RoutedEventHandler btnQuit_Click, string title)
        {
            removeAll();
            TextBlock txtTitle = new TextBlock();
            addTextBlock(txtTitle, 350, 50, 220, Brushes.DarkGray, title, cMainMenu);
            Button btnPlay = new Button();
            addButton(btnPlay, 350, 150, 200, 125, 35, Brushes.DarkGray, "Play", btnPlay_Click, cMainMenu);
            Button btnControls = new Button();
            addButton(btnControls, 350, 300, 200, 125, 35, Brushes.DarkGray, "Controls", btnControls_Click, cMainMenu);
            Button btnQuit = new Button();
            addButton(btnQuit, 350, 450, 200, 125, 35, Brushes.DarkGray, "Quit", btnQuit_Click, cMainMenu);
            c.Children.Add(cMainMenu);
        }

       /// <summary>
       /// Authors
       /// Ethan Shipston, Sebastian Horton
       /// creates the controls menu
       /// </summary>
        public void createControlsMenu(RoutedEventHandler btnBack_Click)
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
        public void createGameOverMenu(RoutedEventHandler btnPlay_Click, RoutedEventHandler btnControls_Click, RoutedEventHandler btnQuit_Click, int i)
        {
            removeAll();
            createMainMenu(btnPlay_Click, btnControls_Click, btnQuit_Click, "Player " + i + " Wins!");
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
        public void EndGame(RoutedEventHandler btnPlay_Click, RoutedEventHandler btnControls_Click, RoutedEventHandler btnQuit_Click, DispatcherTimer timer, Canvas cGame, int i)
        {
            if (MainWindow.gamestate == MainWindow.GameState.gameOver)
            {
                timer.Stop();
                removeAll();
                createGameOverMenu(btnPlay_Click, btnControls_Click, btnQuit_Click, i);
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
        }
    }
}