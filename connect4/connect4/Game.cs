﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connect4
{
	public struct PlayerInfo
	{
		public String playerName;
		public char playerID;
	}

	public class Game

    {
		//playerInfo playerOne = new playerInfo();
		//playerInfo playerTwo = new playerInfo();

		public static char[,] Grid = new char[13, 13] 
			{ 
				//Rows/Columns 1, 3, 5, 7, 9, and 11 have the empty slots for player X/O)
				{'-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-'}, //Row 0 [0, x] [row, colum]
				{'|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|'}, //Row 1 [1, x]
				{'-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-'}, //Row 2 [2, x]
				{'|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|'}, //etc
				{'-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
				{'|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|'},
				{'-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
				{'|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|'},
				{'-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
				{'|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|'},
				{'-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
				{'|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|', ' ', '|'},
				{'-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-'}
			};

		public static void Instructions()
		{
			Console.WriteLine("CONNECT FOUR");
			Console.WriteLine("To play Connect 4, you must drop a token (X or O depending on player) into the empty slots.");
			Console.WriteLine("Whoever gets 4 in a row vertically, horizontally, or diagonally wins.");
			Console.WriteLine("Press any key to continue.");
			Console.ReadKey();
		}

		public static void placeXO(char XO,int column)
        {
			//char would be altered in the main program depending on the player
			//so after one plays there would be char variable x=X; and later x=O;
			//we choose the colomn and while the items on that colomn are -1 we keep decsending otherwise
			//we put X or O in the previous cell (carefull with grid[0,0],grid[1,0],grid[2,0]...grid[6,0]) can make
			//out of range exception so should be checked seperately.
			//-1 for empty 1 for X and 0 for O;

			for (int i = 12; i >= 0; i--)
			{
				if (i % 2 != 0)
				{
					if (Game.Grid[i, column] != ' ')
					{
						Game.Grid[i, column] = XO;
					}
				}
			}

        }

		static void PlayerTurn(int playerNum, char XO)
		{
			int choice = 0;
			PrintBoard(Game.Grid);
			Console.WriteLine("Player " + playerNum + "'s turn!");
			Console.WriteLine("Which column would you like to put your token in?");
			while (choice < 7 && choice > 0)
			{
				choice = int.Parse(Console.ReadLine());
			}
			placeXO(XO, choice);
			Console.Clear();
			PrintBoard(Game.Grid);

		}

		static void IsthereWinner(char[,] board, PlayerInfo activePlayer, int dropChoice)
		{
			//need to check on lines colomns and diagonals
			// lines should be (for i=0 to 1)
			//                  for j=0to 5
			//grid[i,j]==grid[i+1,j]==grid[i+2,j]==grid[i+3,j]==grid[i+4,j] and grid[i,j]==X
			//then Winner='X'
			//else  // lines should be (for i=0 to 1)
			int length, turn;
			length = 6;
			turn = 0;

			//                  for j=0to 5
			//grid[i,j]==grid[i+1,j]==grid[i+2,j]==grid[i+3,j]==grid[i+4,j] and grid[i,j]==O
			//then winner='O'
			//else
			//'N';
			//should be the same for colomns just swap i and j!
			//should check the same for diagonals(carefull with the range!)
			do
			{
				if (board[length, dropChoice] != 'X' && board[length, dropChoice] != 'O')
				{
					board[length, dropChoice] = activePlayer.playerID;
					turn = 1;
				}
				else
					--length;
			} while (turn != 1);
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


		public static void PrintBoard(char[,] grid)
		{
			//Prints out the board in this format: 
			//	CONNECT FOUR
			// _____________
			// | | | | | | |
			// -------------
			// | | | | | | |
			// -------------
			// | | | | | | |
			// -------------
			// | | | | | | |
			// -------------
			// | | | | | | |
			// -------------
			// | | | | | | |
			// -------------


			int rows = 13, columns = 13, x, y;
			Console.WriteLine("CONNECT FOUR \n");
			for (y = 0; y < columns; y++)
			{ 
				for (x = 0; x < rows; x++)
				{
					Console.Write(grid[y, x]);
				}
				Console.WriteLine();
			}
		}

		public static void PlayGame()
		{
			while (true)
			{
				PlayerTurn(1, 'O');
				PlayerTurn(2, 'X');
			}
			
		}

		static void Main(string[] args)
		{
			Instructions();
			PlayGame();
			Console.ReadKey();
		}
	}
}
