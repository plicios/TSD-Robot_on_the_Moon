using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Robot_on_the_Moon
{
    class Program
    {
        private static void RunIsSafeCommandAndPrint(string[] board, string S)
        {
            Console.WriteLine(IsSafeCommand(board, S));
            Console.WriteLine();
        }

        private static void Tests()
        {
            RunIsSafeCommandAndPrint(new[]
            {
                ".....",
                ".###.",
                "..S#.",
                "...#."
            }, "URURURURUR");

            RunIsSafeCommandAndPrint(new[]
            {
                ".....",
                ".###.",
                "..S..",
                "...#."
            }, "URURURURUR");

            RunIsSafeCommandAndPrint(new[]
            {
                ".....",
                ".###.",
                "..S..",
                "...#."
            }, "URURU");

            RunIsSafeCommandAndPrint(new[]
            {
                "#####",
                "#...#",
                "#.S.#",
                "#...#",
                "#####"
            }, "DRULURLDRULRUDLRULDLRULDRLURLUUUURRRRDDLLDD");

            RunIsSafeCommandAndPrint(new[]
            {
                "#####",
                "#...#",
                "#.S.#",
                "#...#",
                "#.###"
            }, "DRULURLDRULRUDLRULDLRULDRLURLUUUURRRRDDLLDD");

            RunIsSafeCommandAndPrint(new[]
            {
                "S"
            }, "R");
        }

        private static void RealData()
        {
            RunIsSafeCommandAndPrint(new[]
            {
                ".....",
                ".###.",
                "..S..",
                "...#."
            }, "DRULRU");
        }

        static void Main(string[] args)
        {
            //Tests();
            RealData();

            Console.ReadKey();
        }

        private static int[] GetStartingLocation(string[] board)
        {
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[i][j].Equals('S'))
                    {
                        return new[] {i, j};
                    }
                }
            }

            return null;
        }

        private static bool WillDie(string[] board, char move, int X, int Y)
        {
            switch (move)
            {
                case 'U':
                    return Y == 0;
                case 'D':
                    return Y == board.Length - 1;
                case 'L':
                    return X == 0;
                case 'R':
                    return X == board[0].Length - 1;
            }

            return false;
        }

        private static bool CanMove(string[] board, char move, int X, int Y)
        {
            switch (move)
            {
                case 'U':
                    return board[Y - 1][X] != '#';
                case 'D':
                    return board[Y + 1][X] != '#';
                case 'L':
                    return board[Y][X - 1] != '#';
                case 'R':
                    return board[Y][X + 1] != '#';
            }

            return true;
        }

        public static string IsSafeCommand(string[] board, string S)
        {
            int[] startingLocation = GetStartingLocation(board);
            int y = startingLocation[0];
            int x = startingLocation[1];

            foreach (char move in S)
            {
                if (WillDie(board, move, x, y))
                {
                    return "Dead";
                }

                if (CanMove(board, move, x, y))
                {
                    switch (move)
                    {
                        case 'U':
                            y--;
                            break;
                        case 'D':
                            y++;
                            break;
                        case 'L':
                            x--;
                            break;
                        case 'R':
                            x++;
                            break;
                    }
                }
            }
            return "Alive";
        }
    }
}
