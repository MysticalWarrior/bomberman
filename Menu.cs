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
   
    class Menu
    {
        static Canvas c;
        static Canvas cControls;
        static Canvas cMainMenu;
        static Canvas cGameOverMenu;
        public Menu(Canvas canvas)
        {
            c = canvas;
            cControls = new Canvas();
            cMainMenu = new Canvas();
            cGameOverMenu = new Canvas();
            
        }
            private static void addWPFObject(dynamic item, int xPos, int yPos, int width, Brush colour, string content, Canvas sp)
            {
                item.Width = width;

                item.Background = colour;
                item.Text = content;
                item.FontSize = 35;

                Canvas.SetTop(item, yPos);
                Canvas.SetLeft(item, xPos);
                sp.Children.Add(item);
            }
        private static void addButton(Button btn, int xPos, int yPos, int width, int Height, int fontSize, Brush colour, string content, RoutedEventHandler btn_Click, Canvas c)
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
         
        public static void createMainMenu(RoutedEventHandler btnPlay_Click, RoutedEventHandler btnControls_Click, RoutedEventHandler btnQuit_Click)
        {
            removeAll();
            TextBlock txtTitle = new TextBlock();
            addWPFObject(txtTitle, 350, 50, 200, Brushes.DarkGray, "Bomberman", cMainMenu);
            Button btnPlay = new Button();
            addButton(btnPlay, 350, 150, 200, 125, 35, Brushes.DarkGray, "Play", btnPlay_Click, cMainMenu);
            Button btnControls = new Button();
            addButton(btnControls, 350, 300, 200, 125, 35, Brushes.DarkGray, "Controls", btnControls_Click, cMainMenu);
            Button btnQuit = new Button();
            addButton(btnQuit, 350, 450, 200, 125, 35, Brushes.DarkGray, "Quit", btnQuit_Click, cMainMenu);
            c.Children.Add(cMainMenu);
        }
        public static void createControlsMenu(RoutedEventHandler btnBack_Click)
        {
            removeAll();
           

            TextBlock txtPlayer1 = new TextBlock();
            addWPFObject(txtPlayer1, 170, 50, 250, Brushes.LightGray, "Player 1", cControls);
           

            TextBlock txtUpHeader1 = new TextBlock();
            addWPFObject(txtUpHeader1, 170, 150, 90, Brushes.Red, "Up", cControls);
            TextBox txtUp1 = new TextBox();
            txtUp1.MaxLength = 1;
            addWPFObject(txtUp1, 270, 150, 150, Brushes.LightGray, "W", cControls);

            TextBlock txtDownHeader1 = new TextBlock();
            addWPFObject(txtDownHeader1, 170, 250, 90, Brushes.Red, "Down", cControls);
            TextBox txtDown1 = new TextBox();
            txtDown1.MaxLength = 1;
            addWPFObject(txtDown1, 270, 250, 150, Brushes.LightGray, "S", cControls);

            TextBlock txtLeftHeader1 = new TextBlock();
            addWPFObject(txtLeftHeader1, 170, 350, 90, Brushes.Red, "Left", cControls);
            TextBox txtLeft1 = new TextBox();
            txtLeft1.MaxLength = 1;
            addWPFObject(txtLeft1, 270, 350, 150, Brushes.LightGray, "A", cControls);

            TextBlock txtRightHeader1 = new TextBlock();
            addWPFObject(txtRightHeader1, 170, 450, 90, Brushes.Red, "Right", cControls);
            TextBox txtRight1 = new TextBox();
            txtRight1.MaxLength = 1;
            addWPFObject(txtRight1, 270, 450, 150, Brushes.LightGray, "D", cControls);



            TextBlock txtPlayer2 = new TextBlock();
            addWPFObject(txtPlayer2, 530, 50, 250, Brushes.LightGray, "Player 2", cControls);

            TextBlock txtUpHeader2 = new TextBlock();
            addWPFObject(txtUpHeader2, 530, 150, 90, Brushes.Blue, "Up", cControls);
            TextBox txtUp2 = new TextBox();
            txtUp2.MaxLength = 1;
            addWPFObject(txtUp2, 630, 150, 150, Brushes.LightGray, "W", cControls);

            TextBlock txtDownHeader2 = new TextBlock();
            addWPFObject(txtDownHeader2, 530, 250, 90, Brushes.Blue, "Down", cControls);
            TextBox txtDown2 = new TextBox();
            txtDown2.MaxLength = 1;
            addWPFObject(txtDown2, 630, 250, 150, Brushes.LightGray, "S", cControls);

            TextBlock txtLeftHeader2 = new TextBlock();
            addWPFObject(txtLeftHeader2, 530, 350, 90, Brushes.Blue, "Left", cControls);
            TextBox txtLeft2 = new TextBox();
            txtLeft2.MaxLength = 1;
            addWPFObject(txtLeft2, 630, 350, 150, Brushes.LightGray, "A", cControls);

            TextBlock txtRightHeader2 = new TextBlock();
            addWPFObject(txtRightHeader2, 530, 450, 90, Brushes.Blue, "Right", cControls);
            TextBox txtRight2 = new TextBox();
            txtRight2.MaxLength = 1;
            addWPFObject(txtRight2, 630, 450, 150, Brushes.LightGray, "D", cControls);

            Button btnBack = new Button();
            addButton(btnBack, 350, 550, 150, 50, 35, Brushes.LightGray, "Back", btnBack_Click, cControls);

            c.Children.Add(cControls);
        }
        public static void createGameOverMenu(RoutedEventHandler btnBack_Click)
        {
            removeAll();
            TextBlock txtTitle2 = new TextBlock();
            addWPFObject(txtTitle2, 350, 50, 200, Brushes.DarkGray, "Game Over", cGameOverMenu);

            Button btnBack2 = new Button();
            addButton(btnBack2, 350, 550, 150, 50, 35, Brushes.LightGray, "Back", btnBack_Click, cGameOverMenu);

            c.Children.Add(cGameOverMenu);
        }
        public void quitGame(MainWindow window)
        {
            window.Close();
        }
        public void startGame(Canvas c)
        {
            removeAll();
            Map map = new Map(c);
            Game game = new Game(c);
        }
        public static void removeAll()
        {
            c.Children.Remove(cControls);
            c.Children.Remove(cMainMenu);
            c.Children.Remove(cGameOverMenu);
        }
    }
}

