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
                    Console.WriteLine("Wrong input! :(");
                    return;
                    break;
            }





            while (true)
            {
                Console.Clear();
                addO(table);
                showTable(table);           //Game cycle
                addX(table);
                Console.Clear();
                showTable(table);
            }


        }







        static void addX(int[,] table)          //Lets you add your X. NEEDS CHECK FOR WRONG INPUT
        {
            int x, y;
            Console.Write("What is the position of your next move? (horizontally, left = 0 and right = 2) >> ");
            x = int.Parse(Console.ReadLine());
            Console.Write("What is the position of your next move? (vertically, bottom = 0 and top = 2) >> ");
            y = int.Parse(Console.ReadLine());

            table[x, y] = 1;
        }





        static void addO(int[,] table)   //CPU adds their O. NEEDS CHECKDIAGONAL
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
