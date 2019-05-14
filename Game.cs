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
    class Game
    {
        Map map;

        Player player1;
        Point player1Point;

        Player player2;
        Point player2Point;

        Bomb bomb;
        int bombFuse;
        bool bombPlaced;
        List<Bomb> bombs;

        List<Player> players;
        public Game(Canvas c)
        {
            map = new Map(c); //construct map.

            player1Point = new Point(0, 0);
            player1 = new Player(c, Brushes.DarkRed, player1Point, 1);  //construct player1 in top left corner

            player2Point = new Point(896, 512); //896, 512
            player2 = new Player(c, Brushes.DarkBlue, player2Point, 2); //construct player2 in bottom right corner

            players = new List<Player>() { player1, player2};
            bombs = new List<Bomb>();

            bombPlaced = false;
        }
        public void updateGame()
        {

            player1.updatePlayer(Key.W, Key.S, Key.A, Key.D);
            player2.updatePlayer(Key.Up, Key.Down, Key.Left, Key.Right);

            placeBomb(Key.RightCtrl, player2);
            placeBomb(Key.LeftShift, player1);
           

            
          
            
        }
        private bool placeBomb(Key place, Player player)
        {
            if (bombPlaced == false)
            {
                if (Keyboard.IsKeyDown(place))
                {
                    bombs.Add(new Bomb(player.getPlayerPos()));
                    bombFuse = 15;
                    return bombPlaced = true;
                }
            }
            foreach (Bomb b in bombs)
            {
               
                    if (bombPlaced == true && bombFuse >= -5)
                    {
                        bombFuse--;
                        if (bombFuse == 0)
                        {
                            b.explosion();
                        int i = 1;
                        foreach (Player pl in players)
                        {
                            if (isPlayerDead(pl.getPlayerPos()) == true)
                            {
                                MessageBox.Show("player " + i.ToString() + " ded");
                            }
                            i++;

                        }
                            return bombPlaced = true;
                        }
                        else if (bombFuse == -5)
                        {
                            b.resetBomb();
                            return bombPlaced = false;
                        }
                        return bombPlaced = true;
                    }
                    else
                        return bombPlaced = false;
            }
            return false;
        }
        private bool isPlayerDead(Point p)
        {
            
                if (Matrices.bomb[(int)p.X / 64, (int)p.Y / 64] == 1)
                {
                    return true;
                }
                else
                    return false;
        }
    }
}
