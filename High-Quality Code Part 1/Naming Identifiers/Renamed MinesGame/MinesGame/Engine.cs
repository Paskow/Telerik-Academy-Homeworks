using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesGame
{
    public static class Engine
    {

        public static void Stat()
        {
            string command = string.Empty;
            char[,] field = createGameBoard();
            char[,] bombs = AddBombsToGameBoard();
            int counter = 0;
            bool isBomb = false;
            List<Player> TopPlayers = new List<Player>(6);
            int row = 0;
            int col = 0;
            bool isFirstFlag = true;
            const int max = 35;
            bool isSecondFlag = false;

            do
            {
                if (isFirstFlag)
                {
                    Console.WriteLine("Lets play “Mines”. Try your luck and find all cells without mines inside them." +
                    " Command 'top' shows Score-Board, 'restart' start new game, 'exit' exits game!");
                    EndGame(field);
                    isFirstFlag = false;
                }
                Console.Write("Select row and column : ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                    int.TryParse(command[2].ToString(), out col) &&
                        row <= field.GetLength(0) && col <= field.GetLength(1))
                    {
                        command = "turn";
                    }
                }
                switch (command)
                {
                    case "top":
                        ScoreBoard(TopPlayers);
                        break;
                    case "restart":
                        field = createGameBoard();
                        bombs = AddBombsToGameBoard();
                        EndGame(field);
                        isBomb = false;
                        isFirstFlag = false;
                        break;
                    case "exit":
                        Console.WriteLine("Bye, Bye, Bye!");
                        break;
                    case "turn":
                        if (bombs[row, col] != '*')
                        {
                            if (bombs[row, col] == '-')
                            {
                                NextTurn(field, bombs, row, col);
                                counter++;
                            }
                            if (max == counter)
                            {
                                isSecondFlag = true;
                            }
                            else
                            {
                                EndGame(field);
                            }
                        }
                        else
                        {
                            isBomb = true;
                        }
                        break;
                    default:
                        Console.WriteLine("\nError! Invalid command\n");
                        break;
                }
                if (isBomb)
                {
                    EndGame(bombs);
                    Console.Write("\nBoooom! Boooom! Boooom! Game finished!" +
                        "Choose nickname for Score-Board: ", counter);
                    string nickname = Console.ReadLine();
                    Player t = new Player(nickname, counter);
                    if (TopPlayers.Count < 5)
                    {
                        TopPlayers.Add(t);
                    }
                    else
                    {
                        for (int i = 0; i < TopPlayers.Count; i++)
                        {
                            if (TopPlayers[i].Points < t.Points)
                            {
                                TopPlayers.Insert(i, t);
                                TopPlayers.RemoveAt(TopPlayers.Count - 1);
                                break;
                            }
                        }
                    }
                    TopPlayers.Sort((Player firstPlayer, Player seocndPlayer) => seocndPlayer.Name.CompareTo(firstPlayer.Name));
                    TopPlayers.Sort((Player firstPlayer, Player secondPlayer) => secondPlayer.Points.CompareTo(firstPlayer.Points));
                    ScoreBoard(TopPlayers);

                    field = createGameBoard();
                    bombs = AddBombsToGameBoard();
                    counter = 0;
                    isBomb = false;
                    isFirstFlag = true;
                }
                if (isSecondFlag)
                {
                    Console.WriteLine("\nExcellent! You found all 35 cells with points inside them.");
                    EndGame(bombs);
                    Console.WriteLine("Choose your nickname: ");
                    string imeee = Console.ReadLine();
                    Player to4kii = new Player(imeee, counter);
                    TopPlayers.Add(to4kii);
                    ScoreBoard(TopPlayers);
                    field = createGameBoard();
                    bombs = AddBombsToGameBoard();
                    counter = 0;
                    isSecondFlag = false;
                    isFirstFlag = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("This game is made in Bulgaria!");
            Console.Read();
        }

        private static char[,] createGameBoard()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] AddBombsToGameBoard()
        {
            int rows = 5;
            int cols = 10;
            char[,] gameBoard = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    gameBoard[row, col] = '-';
                }
            }

            List<int> cellsPoints = new List<int>();
            while (cellsPoints.Count < 15)
            {
                Random random = new Random();
                int randomPoints = random.Next(50);
                if (!cellsPoints.Contains(randomPoints))
                {
                    cellsPoints.Add(randomPoints);
                }
            }

            foreach (int point in cellsPoints)
            {
                int row = (point % cols);
                int col = (point / cols);
                if (row == 0 && point != 0)
                {
                    col--;
                    row = cols;
                }
                else
                {
                    row++;
                }
                gameBoard[col, row - 1] = '*';
            }

            return gameBoard;
        }

        private static void CalculateScore(char[,] gameBoard)
        {
            int rows = gameBoard.GetLength(1);
            int cols = gameBoard.GetLength(0);

            for (int row = 0; row < cols; row++)
            {
                for (int col = 0; col < row; col++)
                {
                    if (gameBoard[row, col] != '*')
                    {
                        char cellScore = CheckCellScore(gameBoard, row, col);
                        gameBoard[row, col] = cellScore;
                    }
                }
            }
        }

        private static char CheckCellScore(char[,] gameBoard, int row, int col)
        {
            int sellScore = 0;
            int rowsCount = gameBoard.GetLength(0);
            int colsCount = gameBoard.GetLength(1);

            if (row - 1 >= 0)
            {
                if (gameBoard[row - 1, col] == '*')
                {
                    sellScore++;
                }
            }
            if (row + 1 < rowsCount)
            {
                if (gameBoard[row + 1, col] == '*')
                {
                    sellScore++;
                }
            }
            if (col - 1 >= 0)
            {
                if (gameBoard[row, col - 1] == '*')
                {
                    sellScore++;
                }
            }
            if (col + 1 < colsCount)
            {
                if (gameBoard[row, col + 1] == '*')
                {
                    sellScore++;
                }
            }
            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (gameBoard[row - 1, col - 1] == '*')
                {
                    sellScore++;
                }
            }
            if ((row - 1 >= 0) && (col + 1 < colsCount))
            {
                if (gameBoard[row - 1, col + 1] == '*')
                {
                    sellScore++;
                }
            }
            if ((row + 1 < rowsCount) && (col - 1 >= 0))
            {
                if (gameBoard[row + 1, col - 1] == '*')
                {
                    sellScore++;
                }
            }
            if ((row + 1 < rowsCount) && (col + 1 < colsCount))
            {
                if (gameBoard[row + 1, col + 1] == '*')
                {
                    sellScore++;
                }
            }
            return char.Parse(sellScore.ToString());
        }

        private static void ScoreBoard(List<Player> points)
        {
            Console.WriteLine("\nPoints:");
            if (points.Count > 0)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} boxes",
                        i + 1, points[i].Name, points[i].Points);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty Score-Board!\n");
            }
        }

        private static void NextTurn(char[,] board,
            char[,] bombs, int row, int col)
        {
            char bombsCount = CheckCellScore(bombs, row, col);
            bombs[row, col] = bombsCount;
            board[row, col] = bombsCount;
        }

        private static void EndGame(char[,] gameBoard)
        {
            int rows = gameBoard.GetLength(0);
            int cols = gameBoard.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(string.Format("{0} ", gameBoard[i, j]));
                }
                Console.Write("|");
                Console.WriteLine();
            }
            Console.WriteLine("   ---------------------\n");
        }


    }
}
