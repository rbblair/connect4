using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connect4
{
    class Program
    {

        void Boolean winLose()
        {
            //win/lose check goes here
        }

        void playerTurn(int playerNum)
        {
            //player's turn goes here
            int[] coordinates = {0, 0};
            
            placeXO(coordinates);
        }

        void placeXO(int[] coordinates)
        {
            //putting an X or O in the board wherever the parameter coordinates say 
        }

        void play()
        {
            //game goes here
            playerTurn();
        }

        static void Main(string[] args)
        {

        }
    }
}
