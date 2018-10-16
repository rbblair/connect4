using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connect4
{
    public class Game
    {
        private int[,] grid;
        public int[,] Grid { get { return grid; } set { grid = value; } }

        public void placeXO(char XO,int colomn)
        {
            //char would be altered in the main program depending on the player
            //so after one plays there would be char variable x=X; and later x=O;
            //we choose the colomn and while the items on that colomn are -1 we keep decsending otherwise
            //we put X or O in the previous cell (carefull with grid[0,0],grid[1,0],grid[2,0]...grid[6,0]) can make
            //out of range exception so should be checked seperately.
            //-1 for empty 1 for X and 0 for O;
            throw new NotImplementedException();

        }

        public void IsThereWinner(out char winner)
        {
            //need to check on lines colomns and diagonals
            // lines should be (for i=0 to 1)
            //                  for j=0to 5
            //grid[i,j]==grid[i+1,j]==grid[i+2,j]==grid[i+3,j]==grid[i+4,j] and grid[i,j]==X
            //then Winner='X'
            //else  // lines should be (for i=0 to 1)

            //                  for j=0to 5
            //grid[i,j]==grid[i+1,j]==grid[i+2,j]==grid[i+3,j]==grid[i+4,j] and grid[i,j]==O
            //then winner='O'
            //else
            //'N';
            //should be the same for colomns just swap i and j!
            //should check the same for diagonals(carefull with the range!)
            throw new NotImplementedException();
        }
        public bool IsTie()
        {
            //Tie is when there is no place for placing X nd O
            //means we need to check if the last row has -1 or not
            //in main program check if tie returns true then cw("Tie Game");
            for (int i = 0; i < 6; i++)
            {
                if (Grid[i,0]==-1)
                {
                    return false;
                }
            }
            return true;
        }
        public void PlayAgain()
        {
            //here just needs to make grid array -1 again;
        }

        public Game()
        {
            grid = new int[6, 6];
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    grid[i, j] = -1;
                }
            }
        }
    }
}
