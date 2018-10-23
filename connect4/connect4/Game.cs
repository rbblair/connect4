using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connect4
{
	public class Game

    {
		//playerInfo playerOne = new playerInfo();
		//playerInfo playerTwo = new playerInfo();
        public static bool gamePlaying = true;
		public static int winner;

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
            Console.Clear();
		}

		public static void placeXO(char XO,int column)
        {
			bool done = false;
			while (!done) //While the token is not placed
			{
				for (int i = 11; i >= 1; i-=2) //Starting from bottom, check for empty slot
				{
						switch (column) //Checks the correct box depending on the player's choice
						{
							case 1:
                                if (Game.Grid[i, 1] == ' ')
                                {
                                    Game.Grid[i, 1] = XO;
                                    done = true; //If the token is placed, the turn is over
                                    break;
                                }
                                else break;
							case 2:
                                if (Game.Grid[i, 3] == ' ')
                                {
                                    Game.Grid[i, 3] = XO;
                                    done = true;
                                    break;
                                }
                                else break;
							case 3:
                                if (Game.Grid[i, 5] == ' ')
                                {
                                    Game.Grid[i, 5] = XO;
                                    done = true;
                                    break;
                                }
                                else break;
							case 4:
                                if (Game.Grid[i, 7] == ' ')
                                {
                                    Game.Grid[i, 7] = XO;
                                    done = true;
                                    break;
                                }
                                else break;
							case 5:
                                if (Game.Grid[i, 9] == ' ')
                                {
                                    Game.Grid[i, 9] = XO;
                                    done = true;
                                    break;
                                }
                                else break;
							case 6:
                                if (Game.Grid[i, 11] == ' ')
                                {
                                    Game.Grid[i, 11] = XO;
                                    done = true;
                                    break;
                                }
                                else break;
							default:
								break;
						}
						if (done)
						{
							break;
						}
				}
			}

        }

		static void PlayerTurn(string playerNum, char XO)
		{
			int choice = 0;
			IsthereWinner();
			IsTie();
			PrintBoard(Game.Grid);
			Console.WriteLine("Player " + playerNum + "'s turn!");
			Console.WriteLine("Which column would you like to put your token in? (1-6)");
			try
			{
				choice = int.Parse(Console.ReadLine());
			}
			catch
			{
				Console.WriteLine("Invalid Input.");
			}
            while (choice > 6 || choice < 1)
            {
                Console.WriteLine("Please choose a number between 1-6.");
                choice = int.Parse(Console.ReadLine());
            }
			placeXO(XO, choice);
            IsthereWinner();
            IsTie();
            Console.Clear();
		}

		static void IsthereWinner()
		{
			int i = 7, ix = 1;


			for (i = 11; i > 0; i-=2) //Increments through rows
			{

				for (ix = 1; ix < 12; ix += 2) //Increments through columns
				{
					if (i > 6)
					{
						//check for vertical winners in all rows
						if ((Game.Grid[i, ix] == 'X' && Game.Grid[i - 2, ix] == 'X' && Game.Grid[i - 4, ix] == 'X' && Game.Grid[i - 6, ix] == 'X')
									|| (Game.Grid[i, ix] == 'O' && Game.Grid[i - 2, ix] == 'O' && Game.Grid[i - 4, ix] == 'O' && Game.Grid[i - 6, ix] == 'O'))
						{
							if (Game.Grid[i, ix] == 'X')
							{
								gamePlaying = false;
								Console.WriteLine(gamePlaying);
								Game.winner = 2;
								GameOver();
							}
							if (Game.Grid[i, ix] == 'O')
							{
								gamePlaying = false;
								Console.WriteLine(gamePlaying);
								Game.winner = 1;
								GameOver();
							}
						}
					}
					if (ix < 6)
					{
						//Checks for horizontal winner in all columns
						if ((Game.Grid[i, ix] == 'X' && Game.Grid[i, ix + 2] == 'X' && Game.Grid[i, ix + 4] == 'X' && Game.Grid[i, ix + 6] == 'X')
								|| (Game.Grid[i, ix] == 'O' && Game.Grid[i, ix + 2] == 'O' && Game.Grid[i, ix + 4] == 'O' && Game.Grid[i, ix + 6] == 'O'))
						{
							if (Game.Grid[i, ix] == 'X')
							{
								gamePlaying = false;
								Game.winner = 2;
								GameOver();
							}
							if (Game.Grid[i, ix] == 'O')
							{
								gamePlaying = false;
								Game.winner = 1;
								GameOver();
							}
						}
					}
					if (i > 6 && ix < 6)
					{
						//Checks for ascending diagonal winner
						if ((Game.Grid[i, ix] == 'X' && Game.Grid[i - 2, ix + 2] == 'X' && Game.Grid[i - 4, ix + 4] == 'X' && Game.Grid[i - 6, ix + 6] == 'X')
						|| (Game.Grid[i, ix] == 'O' && Game.Grid[i - 2, ix + 2] == 'O' && Game.Grid[i - 4, ix + 4] == 'O' && Game.Grid[i - 6, ix + 6] == 'O'))
						{

							if (Game.Grid[i, ix] == 'X')
							{
								gamePlaying = false;
								Game.winner = 2;
								GameOver();
							}
							else if (Game.Grid[i, ix] == 'O')
							{
								gamePlaying = false;
								Game.winner = 1;
								GameOver();
							}
						}
					}
					if (i > 6 && ix < 6)
					{
						//Checks for ascending diagonal winner
						if ((Game.Grid[i - 6, ix] == 'X' && Game.Grid[i - 4, ix + 2] == 'X' && Game.Grid[i - 2, ix + 4] == 'X' && Game.Grid[i, ix + 6] == 'X')
						|| (Game.Grid[i - 6, ix] == 'O' && Game.Grid[i - 4, ix + 2] == 'O' && Game.Grid[i - 2, ix + 4] == 'O' && Game.Grid[i, ix + 6] == 'O'))
						{

							if (Game.Grid[i-6, ix] == 'X')
							{
								gamePlaying = false;
								Game.winner = 2;
								GameOver();
							}
							else if (Game.Grid[i-6, ix] == 'O')
							{
								gamePlaying = false;
								Game.winner = 1;
								GameOver();
							}
						}
					}
				}
			}
			
		}

		public static void IsTie()
        {
            //Tie is when there is no place for placing X and O
            //means we need to check if the last row has -1 or not
            //in main program check if tie returns true then cw("Tie Game");
            bool test = true;
            for (int i = 1; i < 12; i+=2)
            {
                    for (int ix = 1; ix < 12; ix+=2)
                    {
                            if (Grid[i, ix] == ' ')
                            {
                                test = false;
                            }
                    }
            }
            if (test)
            {
                Game.winner = 0;
                GameOver();
            }
        }
        public static void PlayAgain()
        {
            for (int i = 11; i > 0; i-=2)
            {
                    for (int ix = 1; ix < 12; ix+=2)
                    {
						Game.Grid[i, ix] = ' ';
                    }
            }
			gamePlaying = true;
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
			Console.WriteLine("CONNECT FOUR");
			for (y = 0; y < columns; y++)
			{ 
				for (x = 0; x < rows; x++)
				{
					Console.Write(grid[y, x]);
				}
				Console.WriteLine();
			}
		}

        public static void GameOver()
        {
            string choice = "";
            Console.Clear();
			PrintBoard(Game.Grid);
            if (winner == 0)
            {
                Console.WriteLine("It was a tie! There were no more places to put tokens.");
            }
            else
            {
                Console.WriteLine("Player " + Game.winner + " wins! Congratulations!");
            }
            
            Console.WriteLine("Play Again? y/n");
            choice = Console.ReadLine();
            while (choice != "y" && choice != "n" && choice != "Y" && choice != "N")
            {
                Console.WriteLine("Please enter y or n.");
                choice = Console.ReadLine();
            }
            if (choice == "y" || choice == "Y")
            {
				Console.Clear();
                PlayAgain();
                PlayGame();
            }
            else Console.WriteLine("Press any key to exit."); Console.ReadKey(); Environment.Exit(0);
        }

		public static void PlayGame()
		{
			while (gamePlaying) //Currently runs forever for testing :)
			{
				PlayerTurn("1", 'O');
				PlayerTurn("2", 'X');
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
