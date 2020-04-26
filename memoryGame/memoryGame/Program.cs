


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace memoryGame
{
    class Program
    {
         
        static void Main(string[] args)

        {
            //initialize prameters
            int score1 = 0;
            int score2 = 0;
            //get the size from the use
            int size=getNumberFromUser("enter board size. it sould be even number between 2 to 8",2,8 );
            //create board and fill it with random letters
            int[,] board=creatBoardWithLetters(size);
            //print board
            printBoard(board);

            //play the game untill the playerd find all the pairs
            while (score1 + score2 != size * size / 2)
            {
                
                Console.WriteLine("turn 1");
                turn(board, ref score1,score2);
                Console.WriteLine($" score: {score1}");
                if (score1 + score2 == size * size / 2)
                    break;


                Console.WriteLine("turn 2");
                turn(board, ref score2, score1);
                Console.WriteLine($" score: {score2}");

            }
        }

        private static void turn(int[,] board,    ref int  score,int opponScore)
        {
            int raw1 = 0;
            int col1=0;
            int raw2 = 0;
            int col2 = 0;
            int card1, card2;

            
            do
            {
                //get cards from the user and print the board
                card1 = getCard(board, ref raw1, ref col1);
                printBoard(board, raw1, col1);
                card2 = getCard(board, ref raw2, ref col2);
                printBoard(board, raw1, col1, raw2, col2);


                //if the player find to identical cards we raise his score by one and make cards places equel to zero/ 
                if (card1 == card2)
                { 
                    score += 1;
                    board[raw1, col1] = 0;
                    board[raw2, col2] = 0;

                    Console.WriteLine("you have anther turn");


                }

            } while (score + opponScore < board.GetLength(0) * board.GetLength(1) / 2 && card1 == card2);//if the user find two identical card he get anther turn



        }

        private static int getCard(int[,] board,ref int raw,ref int col)
        {
            //get card from the user
            int size = board.GetLength(0);

            do
            {
                raw = getNumberFromUser("enter number for the raw", 0, size-1);
                col = getNumberFromUser("enter number for the column", 0, size-1);

            } while (board[raw,col] == 0);


            return board[raw, col];

        
    }
        private static void printBoard(int[,] board)
        {
           //print the board- put zero where the players guesed two card, X otherwise
            for (int i = 0; i < board.GetLength(0); i++)
            {

                for (int j = 0; j < board.GetLength(1); j++)
                {
                
                    if (board[i,j]==0)
                        Console.Write($"0");
                    else
                        Console.Write($"X");
                }
                Console.WriteLine();


            }
        }
        
        private static void printBoard(int[,] board,int raw,int col)
        {
            //print the board- put zero where the players guesed two card, X otherwise
            //in the coordinate the player chose print the letter
            for (int i = 0; i < board.GetLength(0); i++)
            {

                for (int j = 0; j < board.GetLength(1); j++)
                {

                    if (raw == i && col == j)
                    {
                        Console.Write((char)board[i,j]);
                    }
                    else if (board[i, j] == 0)
                        Console.Write($"0");
                    else
                        Console.Write($"X");
                }
                Console.WriteLine();


            }
        }

        private static void printBoard(int[,] board, int raw1, int col1, int raw2, int col2)
        {
            //print the board- put zero where the players guesed two card, X otherwise
            //in the coordinates the player chose print the letter

            for (int i = 0; i < board.GetLength(0); i++)
            {

                for (int j = 0; j < board.GetLength(1); j++)
                {

                    if (raw1 == i && col1 == j|| raw2 == i && col2 == j)
                    {
                        Console.Write((char)board[i, j]);
                    }
                    else if (board[i, j] == 0)
                        Console.Write($"0");
                    else
                        Console.Write($"X");
                }
                Console.WriteLine();


            }
        }
        private static int[,] creatBoardWithLetters(int size)
        {
            // creat board with letters
            int[,] board = new int[size, size];
            int numOfPairs = size * size / 2;
            fillWithZeros(board);
            fillWithLetters(board);

            return board;

        }

        private static void fillWithLetters(int[,] board)
        {
            //fill the board with random letters
            Random randomEngine = new Random();
            int size = board.GetLength(1);
            int numOfPairs = size * size / 2;


            for (int card = 1; card <= numOfPairs; card++)
            {
                char randomChar = (char)randomEngine.Next('a', 'z');
                int raw; 
                int col;
                for (int j = 0; j < 2; j++)
                {
                    do
                    {
                        raw = randomEngine.Next(0, size);
                        col = randomEngine.Next(0, size);
                    }
                    while (board[raw,col] != 0);

                    board[raw, col] = randomChar;
                }

            }
        }

        private static void fillWithZeros(int[,] board)
        {
            //fill the board with zeros
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = 0;
                }

            }
        }

        private static int getNumberFromUser(string messege, int low, int high)
        {
            int num;
            do 
            {
                Console.WriteLine(messege);
            }while(!Int32.TryParse(Console.ReadLine(),out num)||num<low||num>high);

            return num;
        }


    }
}
