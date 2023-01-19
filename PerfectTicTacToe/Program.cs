using System;

namespace PerfectTicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] table = new int[3, 3];
            string input;

            showTable(table);   //Showing the empty table at first

            Console.WriteLine();
            Console.Write("Hi! Welcome to PerfectTicTacToe. Would you like to go first? (Y/N) >> ");    //Starting: preference of the player
            input = Console.ReadLine();




            switch (input)
            {
                case "Y":
                    addX(table);                                     //Handling the start
                    break;

                case "N":
                    break;

                default:
                    Console.WriteLine("Wrong input! >:(");
                    return;
                    break;
            }





            while (true)
            {
                Console.Clear();
                addO(table);
                showTable(table);           //Game cycle
                if (checkWin(table) == 2)
                {
                    Console.WriteLine("CPU has won!! ^(-_-)^");
                    return;
                }
                else if (checkFull(table))
                {
                    Console.WriteLine("No one wins for now... :P");
                    return;
                }
                addX(table);
                Console.Clear();
                showTable(table);
                if (checkWin(table) == 1)
                {
                    Console.WriteLine("YOU won!!! *-*");
                    return;
                }
                else if (checkFull(table))
                {
                    Console.WriteLine("No one wins for now... :P");
                    return;
                }
            }


        }


        static bool checkFull(int[,] table)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (table[i, j] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        static int checkWin(int[,] table)  //Checks if Xs or Os have a tris. Returns 1 if X has won and 2 if O has won. Else, it returns 0 if no one has won.
        {
            //CHECKS FOR X WIN
            if (table[0, 0] == 1 && table[1, 0] == 1 && table[2, 0] == 1)
            {
                return 1;
            }
            if (table[0, 1] == 1 && table[1, 1] == 1 && table[2, 1] == 1)
            {
                return 1;
            }
            if (table[0, 2] == 1 && table[1, 2] == 1 && table[2, 2] == 1)
            {
                return 1;
            }
            if (table[0, 0] == 1 && table[0, 1] == 1 && table[0, 2] == 1)
            {
                return 1;
            }
            if (table[1, 0] == 1 && table[1, 1] == 1 && table[1, 2] == 1)
            {
                return 1;
            }
            if (table[2, 0] == 1 && table[2, 1] == 1 && table[2, 2] == 1)
            {
                return 1;
            }
            if (table[0, 0] == 1 && table[1, 1] == 1 && table[2, 2] == 1)
            {
                return 1;
            }
            if (table[0, 2] == 1 && table[1, 1] == 1 && table[2, 0] == 1)
            {
                return 1;
            }




            //CHECKS FOR O WIN
            if (table[0, 0] == 2 && table[1, 0] == 2 && table[2, 0] == 2)
            {
                return 2;
            }
            if (table[0, 1] == 2 && table[1, 1] == 2 && table[2, 1] == 2)
            {
                return 2;
            }
            if (table[0, 2] == 2 && table[1, 2] == 2 && table[2, 2] == 2)
            {
                return 2;
            }
            if (table[0, 0] == 2 && table[0, 1] == 2 && table[0, 2] == 2)
            {
                return 2;
            }
            if (table[1, 0] == 2 && table[1, 1] == 2 && table[1, 2] == 2)
            {
                return 2;
            }
            if (table[2, 0] == 2 && table[2, 1] == 2 && table[2, 2] == 2)
            {
                return 2;
            }
            if (table[0, 0] == 2 && table[1, 1] == 2 && table[2, 2] == 2)
            {
                return 2;
            }
            if (table[0, 2] == 2 && table[1, 1] == 2 && table[2, 0] == 2)
            {
                return 2;
            }


            //NO ONE WINS
            return 0;
        }




        static void addX(int[,] table)          //Lets you add your X. NEEDS CHECK FOR WRONG INPUT
        {
            int x, y;

            do
            {
                do
                {
                    Console.Write("What is the position of your next move? (horizontally, left = 0 and right = 2) >> ");
                    x = int.Parse(Console.ReadLine());
                    if (x != 0 && x != 1 && x != 2)
                    {
                        Console.WriteLine("Wrong input! >:(");
                    }
                } while (x != 0 && x != 1 && x != 2);


                do
                {
                    Console.Write("What is the position of your next move? (vertically, bottom = 0 and top = 2) >> ");
                    y = int.Parse(Console.ReadLine());
                    if (y != 0 && y != 1 && y != 2)
                    {
                        Console.WriteLine("Wrong input! >:(");
                    }
                } while (y != 0 && y != 1 && y != 2);

                if (table[x, y] != 0)
                {
                    Console.WriteLine("Position is already occupied!! Choose another one.");
                }

            } while (table[x, y] != 0);
            table[x, y] = 1;
        }





        static void addO(int[,] table)   //CPU adds their O. 
        {

            int flagAdded = 0;

            for (int i = 0; i < 3; i++)
            {
                if (checkHorizontal(table, i))
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (table[j, i] == 0)
                        {
                            table[j, i] = 2;
                            flagAdded++;
                            break;
                        }
                    }
                }
            }

            if (flagAdded == 1)
            {
                return;
            }

            for (int i = 0; i < 3; i++)
            {
                if (checkVertical(table, i))
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (table[i, j] == 0)
                        {
                            table[i, j] = 2;
                            flagAdded++;
                            break;
                        }
                    }
                }
            }

            if (flagAdded == 1)
            {
                return;
            }



            if (checkLeftDiagonal(table))
            {
                for (int j = 0; j < 3; j++)
                {
                    if (table[j, 2 - j] == 0)
                    {
                        table[j, 2 - j] = 2;
                        flagAdded++;
                        break;

                    }
                }
            }

            if (flagAdded == 1)
            {
                return;
            }

            if (checkRightDiagonal(table))
            {
                for (int j = 0; j < 3; j++)
                {
                    if (table[j, j] == 0)
                    {
                        table[j, j] = 2;
                        flagAdded++;
                        break;

                    }
                }
            }

            if (flagAdded == 1)
            {
                return;
            }

            randPos(table);

        }




        static bool checkHorizontal(int[,] table, int row)   //Checks if in row there are two Xs that could complete the game next turn.
        {
            int xnum = 0;
            int onum = 0;

            for (int i = 0; i < 3; i++)
            {
                if (table[i, row] == 1)
                {
                    xnum++;
                }
                if (table[i, row] == 2)
                {
                    onum++;
                }
            }

            if (xnum == 2 && onum == 0)
            {
                return true;
            }
            return false;
        }




        static bool checkVertical(int[,] table, int column) //Checks if in column there are two Xs that could complete the game next turn.
        {
            int xnum = 0;
            int onum = 0;

            for (int i = 0; i < 3; i++)
            {
                if (table[column, i] == 1)
                {
                    xnum++;
                }
                if (table[column, i] == 2)
                {
                    onum++;
                }
            }

            if (xnum == 2 && onum == 0)
            {
                return true;
            }
            return false;
        }

        static bool checkLeftDiagonal(int[,] table) //Checks if in left diagonal there are two Xs that could complete the game next turn.
        {
            int xnum = 0;
            int onum = 0;

            for (int i = 0; i < 3; i++)
            {
                if (table[i, 2 - i] == 1)
                {
                    xnum++;
                }
                if (table[i, 2 - i] == 2)
                {
                    onum++;
                }
            }

            if (xnum == 2 && onum == 0)
            {
                return true;
            }
            return false;
        }


        static bool checkRightDiagonal(int[,] table) //Checks if in right diagonal there are two Xs that could complete the game next turn.
        {
            int xnum = 0;
            int onum = 0;

            for (int i = 0; i < 3; i++)
            {
                if (table[i, i] == 1)
                {
                    xnum++;
                }
                if (table[i, i] == 2)
                {
                    onum++;
                }
            }

            if (xnum == 2 && onum == 0)
            {
                return true;
            }
            return false;
        }



        static void randPos(int[,] table)
        {
            int[] coord = new int[2];
            Random random = new Random();

            coord[0] = random.Next(3);
            coord[1] = random.Next(3);
            while (table[coord[0], coord[1]] != 0)
            {
                coord[0] = random.Next(3);
                coord[1] = random.Next(3);

            }

            table[coord[0], coord[1]] = 2;
        }






        static void showTable(int[,] table)   //Shows the TicTacToe table graphically
        {
            switch (table[0, 2])
            {
                case 1:
                    Console.Write("X |");
                    break;
                case 2:
                    Console.Write("O |");
                    break;
                default:
                    Console.Write("  |");
                    break;
            }
            switch (table[1, 2])
            {
                case 1:
                    Console.Write("  X |");
                    break;
                case 2:
                    Console.Write("  O |");
                    break;
                default:
                    Console.Write("    |");
                    break;
            }
            switch (table[2, 2])
            {
                case 1:
                    Console.WriteLine("  X  ");
                    break;
                case 2:
                    Console.WriteLine("  O  ");
                    break;
                default:
                    Console.WriteLine("     ");
                    break;
            }
            Console.WriteLine("------------");

            switch (table[0, 1])
            {
                case 1:
                    Console.Write("X |");
                    break;
                case 2:
                    Console.Write("O |");
                    break;
                default:
                    Console.Write("  |");
                    break;
            }
            switch (table[1, 1])
            {
                case 1:
                    Console.Write("  X |");
                    break;
                case 2:
                    Console.Write("  O |");
                    break;
                default:
                    Console.Write("    |");
                    break;
            }
            switch (table[2, 1])
            {
                case 1:
                    Console.WriteLine("  X  ");
                    break;
                case 2:
                    Console.WriteLine("  O  ");
                    break;
                default:
                    Console.WriteLine("     ");
                    break;
            }

            Console.WriteLine("------------");
            switch (table[0, 0])
            {
                case 1:
                    Console.Write("X |");
                    break;
                case 2:
                    Console.Write("O |");
                    break;
                default:
                    Console.Write("  |");
                    break;
            }
            switch (table[1, 0])
            {
                case 1:
                    Console.Write("  X |");
                    break;
                case 2:
                    Console.Write("  O |");
                    break;
                default:
                    Console.Write("    |");
                    break;
            }
            switch (table[2, 0])
            {
                case 1:
                    Console.WriteLine("  X  ");
                    break;
                case 2:
                    Console.WriteLine("  O  ");
                    break;
                default:
                    Console.WriteLine("     ");
                    break;
            }
        }


    }
}
