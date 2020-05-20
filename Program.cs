using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace Battleship
{
    class Program
    {
        static int x = 10;
        static int y = 10;
        static int myShotX, myShotY;
        static bool myHit = false, hit;
        static int compDeck, compDeckCounter = 20;
        static int counterMine = 20;
        static int counterComp = 20;
        static int shotX, shotY, hitX = 20, hitY = 20, tactics = 0, firstShotX, firstShotY;
        public static int numberOfDecks = 20;
        static string method = "random";
        static int[,] myMatr = new int[10, 10];
        static int[,] myMatrCopy = new int[10, 10];
        static int[,] compMatr = new int[10, 10];
        static int[] lastHitX = new int[5];
        static int[] lastHitY = new int[5];
        static bool destroy, sh, choose = false;
        static StreamReader read = new StreamReader("bestScore.txt");
        static char[] arr = new char[10];
        static string nickname, bestScoreStr = read.ReadLine(), bestScoreNum;
        static int score = 0;
        

        static void Main(string[] args)
        {
            bestScoreNum = bestScoreStr.Substring(0, 2);
            read.Close();


            Before();
            Game();

            Console.ReadLine();
        }

        private static void Before()
        {
            string s;

            do
            {
                Console.Clear();
                Console.SetCursorPosition(10, 10);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("BATTLESHIP");
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(10, 11);
                Console.Write("Input your nickname: ");
                nickname = Console.ReadLine();
                Console.SetCursorPosition(10, 12);
                Console.WriteLine("Do you want to set your ships? y/n");
                s = Console.ReadLine();
            } while (s != "y" && s != "Y" && s != "n" && s != "N");

            if (s == "y" || s == "Y")
            {
                InputShips();
                Random rn = new Random();
                int number1 = rn.Next(10, 20);
                FillCompMatr(ref number1);
            }
            if (s == "n" || s == "N")
            {
                Random r = new Random();
                int number = r.Next(0, 10);
                Random rn = new Random();
                int number1 = rn.Next(10, 20);
                FillmyMatr(ref number, ref number1);
            }



        }

        private static void FillCompMatr(ref int number1)
        {
            switch (number1)
            {
                case 19:
                    int[,] array = new int[10, 10] {
                        { 0,0,0,0,0,0,3,3,3,0}, { 0,0,0,1,0,0,0,0,0,0}, { 2,0,0,0,0,0,0,0,0,4},
                        { 2,0,0,0,0,0,1,0,0,4},
                        { 0,0,0,0,0,0,0,0,0,4}, { 0,0,0,2,2,0,0,1,0,4}, { 0,0,0,0,0,0,0,0,0,0}, { 0,0,0,0,0,0,2,0,0,3},
                        { 0,1,0,0,0,0,2,0,0,3}, { 0,0,0,0,0,0,0,0,0,3}
                    };
                    compMatr = array;
                    break;
                case 18:
                    int[,] array1 = new int[10, 10] {
                        { 0,0,3,3,3,0,0,0,0,0}, { 0,0,0,0,0,0,0,1,0,0}, { 4,0,0,0,0,0,0,0,0,0},
                        { 4,0,0,2,0,0,1,0,0,0},
                        { 4,0,0,2,0,0,0,0,0,0}, { 4,0,0,0,0,0,0,0,3,0}, { 0,0,0,0,0,2,2,0,3,0}, { 0,0,1,0,0,0,0,0,3,0},
                        { 0,0,0,0,0,2,0,0,0,0}, { 1,0,0,0,0,2,0,0,0,0} };
                    compMatr = array1;
                    break;
                case 17:
                    int[,] array2 = new int[10, 10] {
                        { 0,0,0,0,0,0,0,0,0,0}, {0,1,0,0,0,0,2,2,0,0}, {0,0,0,0,0,0,0,0,0,2}, {0,0,0,0,0,0,0,0,0,2},
                        {0,1,0,0,0,0,1,0,0,0 }, {0,0,0,0,0,0,0,0,0,0}, {4,0,0,1,0,0,0,3,0,0}, {4,0,0,0,0,0,0,3,0,2},
                        {4,0,0,0,0,0,0,3,0,2 }, {4,0,3,3,3,0,0,0,0,0} };
                    compMatr = array2;
                    break;
                case 16:
                    int[,] array3 = new int[10, 10] {
                        {3,0,0,0,0,0,0,0,0,1 }, {3,0,0,0,0,0,0,0,0,0}, {3,0,0,0,4,4,4,4,0,0}, {0,0,0,0,0,0,0,0,0,1},
                        {1,0,0,0,0,0,0,0,0,0 }, {0,0,2,2,0,0,0,2,2,0}, {0,0,0,0,0,0,0,0,0,0}, {0,0,0,0,0,0,0,0,0,3},
                        {0,0,0,0,2,2,0,0,0,3 }, {1,0,0,0,0,0,0,0,0,3} };
                    compMatr = array3;
                    break;
                case 15:
                    int[,] array4 = new int[10, 10]
                    {
                        {0,0,0,0,0,0,0,0,0,0 }, {0,0,1,0,0,0,0,0,0,2}, {0,0,0,0,0,0,0,1,0,2}, {3,3,3,0,0,0,0,0,0,0},
                        {0,0,0,0,0,2,2,0,0,0 }, {0,0,0,0,0,0,0,0,0,0}, {0,0,0,1,0,0,0,0,0,1}, {3,0,0,0,0,0,0,0,0,0},
                        {3,0,0,0,0,0,0,0,2,2 }, {3,0,0,4,4,4,4,0,0,0}
                    };
                    compMatr = array4;
                    break;
                case 14:
                    int[,] array5 = new int[10, 10] {
                        {2,0,0,3,3,3,0,0,0,4 }, {2,0,0,0,0,0,0,0,0,4}, {0,0,0,0,0,0,0,0,0,4 }, {0,1,0,0,3,3,3,0,0,4},
                        {0,0,0,0,0,0,0,0,0,0 }, {0,0,0,0,0,0,0,0,0,0}, {0,1,0,0,0,0,2,2,0,0 }, {0,0,0,0,0,0,0,0,0,2},
                        {0,0,0,0,0,0,1,0,0,2 }, {0,0,1,0,0,0,0,0,0,0} };
                    compMatr = array5;
                    break;
                case 13:
                    int[,] array6 = new int[10, 10] {
                        {0,0,0,0,0,0,0,2,2,0 }, {0,1,0,0,2,0,0,0,0,0}, {0,0,0,0,2,0,0,0,1,0}, {0,0,0,0,0,0,0,0,0,0},
                        {0,0,0,0,0,0,3,3,3,0 }, {2,0,4,0,0,0,0,0,0,0}, {2,0,4,0,0,0,0,0,0,0}, {0,0,4,0,0,0,3,0,0,0},
                        {0,0,4,0,0,0,3,0,0,1 }, {1,0,0,0,0,0,3,0,0,0} };
                    compMatr = array6;
                    break;
                case 12:
                    int[,] array7 = new int[10, 10] {
                        {0,4,4,4,4,0,3,3,3,0 }, {0,0,0,0,0,0,0,0,0,0}, {1,0,0,0,0,0,0,0,0,2}, {0,0,0,0,0,0,0,0,0,2},
                        {2,0,0,0,0,0,0,0,0,0 }, {2,0,0,0,0,0,0,0,0,1}, {0,0,0,0,0,0,0,0,0,0}, {1,0,0,0,0,0,0,0,0,0},
                        {0,0,0,0,0,0,0,0,0,0 }, {0,2,2,0,1,0,3,3,3,0} };
                    compMatr = array7;
                    break;
                case 11:
                    int[,] array8 = new int[10, 10] {
                        {0,4,4,4,4,0,0,0,0,0 }, {0,0,0,0,0,0,0,0,0,2}, {3,0,0,0,0,0,1,0,0,2}, {3,0,0,1,0,0,0,0,0,0},
                        {3,0,0,0,0,0,0,0,0,0 }, {0,0,0,0,0,1,0,0,0,0}, {0,0,1,0,0,0,0,0,0,0}, {0,0,0,0,0,0,0,0,0,2},
                        {0,0,0,0,0,0,0,0,0,2 }, {0,3,3,3,0,0,2,2,0,0} };
                    compMatr = array8;
                    break;
                case 10:
                    int[,] array9 = new int[10, 10] {
                        {0,1,0,0,0,0,0,0,0,0 }, {0,0,0,4,4,4,4,0,0,0}, {0,0,0,0,0,0,0,0,0,1}, {3,0,0,0,0,0,0,0,0,0},
                        {3,0,2,2,0,0,0,0,2,2 }, {3,0,0,0,0,0,0,0,0,0}, {0,0,1,0,0,0,0,0,0,0}, {0,0,0,0,0,2,0,0,1,0},
                        {0,0,0,0,0,2,0,0,0,0 }, {0,3,3,3,0,0,0,0,0,0} };
                    compMatr = array9;
                    break;
            }
        }

        private static void FillmyMatr(ref int number, ref int number1)
        {
            //Random r = new Random();

            switch (number)
            {
                case 0:
                    int[,] array = new int[10, 10] {
                        { 0,0,0,0,0,0,3,3,3,0}, { 0,0,0,1,0,0,0,0,0,0}, { 2,0,0,0,0,0,0,0,0,4},
                        { 2,0,0,0,0,0,1,0,0,4},
                        { 0,0,0,0,0,0,0,0,0,4}, { 0,0,0,2,2,0,0,1,0,4}, { 0,0,0,0,0,0,0,0,0,0}, { 0,0,0,0,0,0,2,0,0,3},
                        { 0,1,0,0,0,0,2,0,0,3}, { 0,0,0,0,0,0,0,0,0,3}
                    };
                    myMatr = array;
                    break;
                case 1:
                    int[,] array1 = new int[10, 10] {
                        { 0,0,3,3,3,0,0,0,0,0}, { 0,0,0,0,0,0,0,1,0,0}, { 4,0,0,0,0,0,0,0,0,0},
                        { 4,0,0,2,0,0,1,0,0,0},
                        { 4,0,0,2,0,0,0,0,0,0}, { 4,0,0,0,0,0,0,0,3,0}, { 0,0,0,0,0,2,2,0,3,0}, { 0,0,1,0,0,0,0,0,3,0},
                        { 0,0,0,0,0,2,0,0,0,0}, { 1,0,0,0,0,2,0,0,0,0} };
                    myMatr = array1;
                    break;
                case 2:
                    int[,] array2 = new int[10, 10] {
                        { 0,0,0,0,0,0,0,0,0,0}, {0,1,0,0,0,0,2,2,0,0}, {0,0,0,0,0,0,0,0,0,2}, {0,0,0,0,0,0,0,0,0,2},
                        {0,1,0,0,0,0,1,0,0,0 }, {0,0,0,0,0,0,0,0,0,0}, {4,0,0,1,0,0,0,3,0,0}, {4,0,0,0,0,0,0,3,0,2},
                        {4,0,0,0,0,0,0,3,0,2 }, {4,0,3,3,3,0,0,0,0,0} };
                    myMatr = array2;
                    break;
                case 3:
                    int[,] array3 = new int[10, 10] {
                        {3,0,0,0,0,0,0,0,0,1 }, {3,0,0,0,0,0,0,0,0,0}, {3,0,0,0,4,4,4,4,0,0}, {0,0,0,0,0,0,0,0,0,1},
                        {1,0,0,0,0,0,0,0,0,0 }, {0,0,2,2,0,0,0,2,2,0}, {0,0,0,0,0,0,0,0,0,0}, {0,0,0,0,0,0,0,0,0,3},
                        {0,0,0,0,2,2,0,0,0,3 }, {1,0,0,0,0,0,0,0,0,3} };
                    myMatr = array3;
                    break;
                case 4:
                    int[,] array4 = new int[10, 10]
                    {
                        {0,0,0,0,0,0,0,0,0,0 }, {0,0,1,0,0,0,0,0,0,2}, {0,0,0,0,0,0,0,1,0,2}, {3,3,3,0,0,0,0,0,0,0},
                        {0,0,0,0,0,2,2,0,0,0 }, {0,0,0,0,0,0,0,0,0,0}, {0,0,0,1,0,0,0,0,0,1}, {3,0,0,0,0,0,0,0,0,0},
                        {3,0,0,0,0,0,0,0,2,2 }, {3,0,0,4,4,4,4,0,0,0}
                    };
                    myMatr = array4;
                    break;
                case 5:
                    int[,] array5 = new int[10, 10] {
                        {2,0,0,3,3,3,0,0,0,4 }, {2,0,0,0,0,0,0,0,0,4}, {0,0,0,0,0,0,0,0,0,4 }, {0,1,0,0,3,3,3,0,0,4},
                        {0,0,0,0,0,0,0,0,0,0 }, {0,0,0,0,0,0,0,0,0,0}, {0,1,0,0,0,0,2,2,0,0 }, {0,0,0,0,0,0,0,0,0,2},
                        {0,0,0,0,0,0,1,0,0,2 }, {0,0,1,0,0,0,0,0,0,0} };
                    myMatr = array5;
                    break;
                case 6:
                    int[,] array6 = new int[10, 10] {
                        {0,0,0,0,0,0,0,2,2,0 }, {0,1,0,0,2,0,0,0,0,0}, {0,0,0,0,2,0,0,0,1,0}, {0,0,0,0,0,0,0,0,0,0},
                        {0,0,0,0,0,0,3,3,3,0 }, {2,0,4,0,0,0,0,0,0,0}, {2,0,4,0,0,0,0,0,0,0}, {0,0,4,0,0,0,3,0,0,0},
                        {0,0,4,0,0,0,3,0,0,1 }, {1,0,0,0,0,0,3,0,0,0} };
                    myMatr = array6;
                    break;
                case 7:
                    int[,] array7 = new int[10, 10] {
                        {0,4,4,4,4,0,3,3,3,0 }, {0,0,0,0,0,0,0,0,0,0}, {1,0,0,0,0,0,0,0,0,2}, {0,0,0,0,0,0,0,0,0,2},
                        {2,0,0,0,0,0,0,0,0,0 }, {2,0,0,0,0,0,0,0,0,1}, {0,0,0,0,0,0,0,0,0,0}, {1,0,0,0,0,0,0,0,0,0},
                        {0,0,0,0,0,0,0,0,0,0 }, {0,2,2,0,1,0,3,3,3,0} };
                    myMatr = array7;
                    break;
                case 8:
                    int[,] array8 = new int[10, 10] {
                        {0,4,4,4,4,0,0,0,0,0 }, {0,0,0,0,0,0,0,0,0,2}, {3,0,0,0,0,0,1,0,0,2}, {3,0,0,1,0,0,0,0,0,0},
                        {3,0,0,0,0,0,0,0,0,0 }, {0,0,0,0,0,1,0,0,0,0}, {0,0,1,0,0,0,0,0,0,0}, {0,0,0,0,0,0,0,0,0,2},
                        {0,0,0,0,0,0,0,0,0,2 }, {0,3,3,3,0,0,2,2,0,0} };
                    myMatr = array8;
                    break;
                case 9:
                    int[,] array9 = new int[10, 10] {
                        {0,1,0,0,0,0,0,0,0,0 }, {0,0,0,4,4,4,4,0,0,0}, {0,0,0,0,0,0,0,0,0,1}, {3,0,0,0,0,0,0,0,0,0},
                        {3,0,2,2,0,0,0,0,2,2 }, {3,0,0,0,0,0,0,0,0,0}, {0,0,1,0,0,0,0,0,0,0}, {0,0,0,0,0,2,0,0,1,0},
                        {0,0,0,0,0,2,0,0,0,0 }, {0,3,3,3,0,0,0,0,0,0} };
                    myMatr = array9;
                    break;
            }

            switch (number1)
            {
                case 19:
                    int[,] array = new int[10, 10] {
                        { 0,0,0,0,0,0,3,3,3,0}, { 0,0,0,1,0,0,0,0,0,0}, { 2,0,0,0,0,0,0,0,0,4},
                        { 2,0,0,0,0,0,1,0,0,4},
                        { 0,0,0,0,0,0,0,0,0,4}, { 0,0,0,2,2,0,0,1,0,4}, { 0,0,0,0,0,0,0,0,0,0}, { 0,0,0,0,0,0,2,0,0,3},
                        { 0,1,0,0,0,0,2,0,0,3}, { 0,0,0,0,0,0,0,0,0,3}
                    };
                    compMatr = array;
                    break;
                case 18:
                    int[,] array1 = new int[10, 10] {
                        { 0,0,3,3,3,0,0,0,0,0}, { 0,0,0,0,0,0,0,1,0,0}, { 4,0,0,0,0,0,0,0,0,0},
                        { 4,0,0,2,0,0,1,0,0,0},
                        { 4,0,0,2,0,0,0,0,0,0}, { 4,0,0,0,0,0,0,0,3,0}, { 0,0,0,0,0,2,2,0,3,0}, { 0,0,1,0,0,0,0,0,3,0},
                        { 0,0,0,0,0,2,0,0,0,0}, { 1,0,0,0,0,2,0,0,0,0} };
                    compMatr = array1;
                    break;
                case 17:
                    int[,] array2 = new int[10, 10] {
                        { 0,0,0,0,0,0,0,0,0,0}, {0,1,0,0,0,0,2,2,0,0}, {0,0,0,0,0,0,0,0,0,2}, {0,0,0,0,0,0,0,0,0,2},
                        {0,1,0,0,0,0,1,0,0,0 }, {0,0,0,0,0,0,0,0,0,0}, {4,0,0,1,0,0,0,3,0,0}, {4,0,0,0,0,0,0,3,0,2},
                        {4,0,0,0,0,0,0,3,0,2 }, {4,0,3,3,3,0,0,0,0,0} };
                    compMatr = array2;
                    break;
                case 16:
                    int[,] array3 = new int[10, 10] {
                        {3,0,0,0,0,0,0,0,0,1 }, {3,0,0,0,0,0,0,0,0,0}, {3,0,0,0,4,4,4,4,0,0}, {0,0,0,0,0,0,0,0,0,1},
                        {1,0,0,0,0,0,0,0,0,0 }, {0,0,2,2,0,0,0,2,2,0}, {0,0,0,0,0,0,0,0,0,0}, {0,0,0,0,0,0,0,0,0,3},
                        {0,0,0,0,2,2,0,0,0,3 }, {1,0,0,0,0,0,0,0,0,3} };
                    compMatr = array3;
                    break;
                case 15:
                    int[,] array4 = new int[10, 10]
                    {
                        {0,0,0,0,0,0,0,0,0,0 }, {0,0,1,0,0,0,0,0,0,2}, {0,0,0,0,0,0,0,1,0,2}, {3,3,3,0,0,0,0,0,0,0},
                        {0,0,0,0,0,2,2,0,0,0 }, {0,0,0,0,0,0,0,0,0,0}, {0,0,0,1,0,0,0,0,0,1}, {3,0,0,0,0,0,0,0,0,0},
                        {3,0,0,0,0,0,0,0,2,2 }, {3,0,0,4,4,4,4,0,0,0}
                    };
                    compMatr = array4;
                    break;
                case 14:
                    int[,] array5 = new int[10, 10] {
                        {2,0,0,3,3,3,0,0,0,4 }, {2,0,0,0,0,0,0,0,0,4}, {0,0,0,0,0,0,0,0,0,4 }, {0,1,0,0,3,3,3,0,0,4},
                        {0,0,0,0,0,0,0,0,0,0 }, {0,0,0,0,0,0,0,0,0,0}, {0,1,0,0,0,0,2,2,0,0 }, {0,0,0,0,0,0,0,0,0,2},
                        {0,0,0,0,0,0,1,0,0,2 }, {0,0,1,0,0,0,0,0,0,0} };
                    compMatr = array5;
                    break;
                case 13:
                    int[,] array6 = new int[10, 10] {
                        {0,0,0,0,0,0,0,2,2,0 }, {0,1,0,0,2,0,0,0,0,0}, {0,0,0,0,2,0,0,0,1,0}, {0,0,0,0,0,0,0,0,0,0},
                        {0,0,0,0,0,0,3,3,3,0 }, {2,0,4,0,0,0,0,0,0,0}, {2,0,4,0,0,0,0,0,0,0}, {0,0,4,0,0,0,3,0,0,0},
                        {0,0,4,0,0,0,3,0,0,1 }, {1,0,0,0,0,0,3,0,0,0} };
                    compMatr = array6;
                    break;
                case 12:
                    int[,] array7 = new int[10, 10] {
                        {0,4,4,4,4,0,3,3,3,0 }, {0,0,0,0,0,0,0,0,0,0}, {1,0,0,0,0,0,0,0,0,2}, {0,0,0,0,0,0,0,0,0,2},
                        {2,0,0,0,0,0,0,0,0,0 }, {2,0,0,0,0,0,0,0,0,1}, {0,0,0,0,0,0,0,0,0,0}, {1,0,0,0,0,0,0,0,0,0},
                        {0,0,0,0,0,0,0,0,0,0 }, {0,2,2,0,1,0,3,3,3,0} };
                    compMatr = array7;
                    break;
                case 11:
                    int[,] array8 = new int[10, 10] {
                        {0,4,4,4,4,0,0,0,0,0 }, {0,0,0,0,0,0,0,0,0,2}, {3,0,0,0,0,0,1,0,0,2}, {3,0,0,1,0,0,0,0,0,0},
                        {3,0,0,0,0,0,0,0,0,0 }, {0,0,0,0,0,1,0,0,0,0}, {0,0,1,0,0,0,0,0,0,0}, {0,0,0,0,0,0,0,0,0,2},
                        {0,0,0,0,0,0,0,0,0,2 }, {0,3,3,3,0,0,2,2,0,0} };
                    compMatr = array8;
                    break;
                case 10:
                    int[,] array9 = new int[10, 10] {
                        {0,1,0,0,0,0,0,0,0,0 }, {0,0,0,4,4,4,4,0,0,0}, {0,0,0,0,0,0,0,0,0,1}, {3,0,0,0,0,0,0,0,0,0},
                        {3,0,2,2,0,0,0,0,2,2 }, {3,0,0,0,0,0,0,0,0,0}, {0,0,1,0,0,0,0,0,0,0}, {0,0,0,0,0,2,0,0,1,0},
                        {0,0,0,0,0,2,0,0,0,0 }, {0,3,3,3,0,0,0,0,0,0} };
                    compMatr = array9;
                    break;
            }
        }

        private static void Game()
        {
            Console.Clear();
            bool markerMine = true;
            bool markerComp = false;

            while (counterMine != 0 && counterComp != 0)
            {
                PrintBattlefield();

                if (markerMine == true)
                {
                    if (Fire(compMatr, ref counterComp))
                    {
                        myHit = true;
                        markerMine = true;
                        PrintBattlefield();
                    }
                    else
                    {
                        myHit = false;
                        markerMine = false;
                        markerComp = true;
                        PrintBattlefield();
                    }
                    score++;
                }
                else if (markerComp == true)
                {
                    if (FireComp())
                    {
                        markerComp = true;
                        PrintBattlefield();
                    }
                    else
                    {
                        markerComp = false;
                        markerMine = true;
                        PrintBattlefield();
                    }
                }
            }

            if (score <= Int32.Parse(bestScoreNum))
            {
                StreamWriter write = new StreamWriter("bestScore.txt");
                write.WriteLine(score + "\t" + nickname);
                write.Close();
            }

            if (counterComp == 0)
            {
                Console.Clear();
                Battlefield(compMatr);
                Console.SetCursorPosition(20, 30);
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("YOU WOOOOOOOOON!");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("{0}'s score is {1}", nickname, score);
                Console.WriteLine("Best score is {0}", bestScoreStr);
            }
            else if (counterMine == 0)
            {
                Console.Clear();
                Battlefield(myMatr);
                Console.SetCursorPosition(20, 30);
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("YOU LOSE!");
                Console.BackgroundColor = ConsoleColor.Black;
            }

        }

        private static bool FireComp()
        {
            bool fireComp = false;

            if (numberOfDecks == 0)
            {
                method = "random";
            }

            switch (method)
            {
                case "random":
                    RandomFireComp(ref fireComp);
                    Thread.Sleep(1000);
                    break;
                case "AI":
                    AIFireComp(ref fireComp);
                    Thread.Sleep(1000);
                    break;
            }

            if (numberOfDecks == 0)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Ship destroyed");

            }

            FillArray();

            return fireComp;
        }

        private static void FillArray()
        {
            for (int i = 3; i >= 0; i--)
            {
                lastHitX[i + 1] = lastHitX[i];
                lastHitY[i + 1] = lastHitY[i];
            }

            lastHitX[0] = (shotX + 1);
            lastHitY[0] = (shotY + 1);
        }

        private static void AIFireComp(ref bool fireComp)
        {


            if (tactics != 0 && choose == true)
            {
                switch (tactics)
                {
                    case 1:
                        if ((hitX + 1) <= 9 && myMatr[hitY, (hitX + 1)] != 9 && myMatr[hitY, (hitX + 1)] != 8 && myMatr[hitY, (hitX + 1)] != 5)
                        { tactics = 1; }
                        else 
                        {
                            shotX = firstShotX;
                            shotY = firstShotY;
                            tactics = 3; 
                        }
                        break;
                    case 2:
                        if ((hitY + 1) <= 9 && myMatr[(hitY + 1), hitX] != 9 && myMatr[(hitY + 1), hitX] != 8 && myMatr[(hitY + 1), hitX] != 5)
                        { tactics = 2; }
                        else 
                        {
                            shotX = firstShotX;
                            shotY = firstShotY;
                            tactics = 4; 
                        }
                        break;
                    case 3:
                        if ((hitX - 1) >= 0 && myMatr[hitY, (hitX - 1)] != 9 && myMatr[hitY, (hitX - 1)] != 8 && myMatr[hitY, (hitX - 1)] != 5)
                        { tactics = 3; }
                        else 
                        {
                            shotX = firstShotX;
                            shotY = firstShotY; 
                            tactics = 1; 
                        }
                        break;
                    case 4:
                        if ((hitY - 1) >= 0 && myMatr[(hitY - 1), hitX] != 9 && myMatr[(hitY - 1), hitX] != 8 && myMatr[(hitY - 1), hitX] != 5)
                        { tactics = 4; }
                        else 
                        {
                            shotX = firstShotX;
                            shotY = firstShotY; 
                            tactics = 2; 
                        }
                        break;
                }
            }

            hitX = shotX;
            hitY = shotY;

            switch (tactics)
            {
                case 0:
                case 1:

                    if ((hitX + 1) <= 9 && myMatr[hitY, (hitX + 1)] != 9 && myMatr[hitY, (hitX + 1)] != 8 && myMatr[hitY, (hitX + 1)] != 5)
                    {
                        hitX++;
                        CheckShotAI();
                        if (sh)
                        {
                            if (hit)
                            {
                                tactics = 1;
                                shotX = hitX;
                                counterMine--;
                                numberOfDecks--;
                            }
                            else if (choose == true && hit == false) 
                            {
                                shotX = firstShotX;
                                shotY = firstShotY; 
                                tactics = 3; 
                            }
                            else { tactics = 2; }
                        }
                        else { goto case 2; }
                    }
                    else
                    { goto case 2; }
                    break;


                case 2:
                    if ((hitY + 1) <= 9 && myMatr[(hitY + 1), hitX] != 9 && myMatr[(hitY + 1), hitX] != 8 && myMatr[(hitY + 1), hitX] != 5)
                    {
                        hitY++;
                        CheckShotAI();
                        if (sh)
                        {
                            if (hit)
                            {
                                tactics = 2;
                                shotY = hitY;
                                counterMine--;
                                numberOfDecks--;
                            }
                            else if (choose == true && hit == false) 
                            {
                                shotX = firstShotX;
                                shotY = firstShotY; 
                                tactics = 4; 
                            } 
                            else{ tactics = 3; }
                        }
                        else { goto case 3; }
                    }
                    else { goto case 3; }
                    break;


                case 3:
                    if ((hitX - 1) >= 0 && myMatr[hitY, (hitX - 1)] != 9 && myMatr[hitY, (hitX - 1)] != 8 && myMatr[hitY, (hitX - 1)] != 5)
                    {
                        hitX--;
                        CheckShotAI();
                        if (sh)
                        {
                            if (hit)
                            {
                                tactics = 3;
                                shotX = hitX;
                                counterMine--;
                                numberOfDecks--;
                            }
                            else if (choose == true && hit == false) 
                            {
                                shotX = firstShotX;
                                shotY = firstShotY;
                                tactics = 1; 
                            }
                            else { tactics = 4; }
                        }
                        else { goto case 4; }
                    }
                    else { goto case 4; }
                    break;


                case 4:
                    if ((hitY - 1) >= 0 && myMatr[(hitY - 1), hitX] != 9 && myMatr[(hitY - 1), hitX] != 8 && myMatr[(hitY - 1), hitX] != 5)
                    {
                        hitY--;
                        CheckShotAI();
                        if (sh)
                        {
                            if (hit)
                            {
                                tactics = 4;
                                shotY = hitY;
                                counterMine--;
                                numberOfDecks--;
                            }
                            else if (choose == true && hit == false)
                            {
                                shotX = firstShotX;
                                shotY = firstShotY;
                                tactics = 2;
                            }
                            else { goto default; }
                        }
                        else
                        {
                            shotX = firstShotX;
                            shotY = firstShotY;
                            goto case 1;
                        }
                    }
                    else
                    {
                        shotX = firstShotX;
                        shotY = firstShotY;
                        goto case 1;
                    }
                    break;


                default:
                    shotX = firstShotX;
                    shotY = firstShotY;
                    tactics = 1;
                    break;
            }

            if (choose == false && hit == true) { choose = true; }

            if (numberOfDecks == 0) { method = "random"; }

            DrawAreaAroundTheShip();

            string compAxisShot;

            switch (shotX)
            {
                case 0:
                    compAxisShot = "A";
                    break;
                case 1:
                    compAxisShot = "B";
                    break;
                case 2:
                    compAxisShot = "C";
                    break;
                case 3:
                    compAxisShot = "D";
                    break;
                case 4:
                    compAxisShot = "E";
                    break;
                case 5:
                    compAxisShot = "F";
                    break;
                case 6:
                    compAxisShot = "G";
                    break;
                case 7:
                    compAxisShot = "H";
                    break;
                case 8:
                    compAxisShot = "I";
                    break;
                case 9:
                    compAxisShot = "J";
                    break;
                default:
                    compAxisShot = "NULL";
                    break;
            }

            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Comp shot's X = {0}", compAxisShot);
            Console.WriteLine("Comp shot's Y = {0}", (shotY + 1));
            Thread.Sleep(1000);

            if (hit)
            { fireComp = true; }
            else { fireComp = false; }
        }

        private static void DrawAreaAroundTheShip()
        {
            if (numberOfDecks == 0)
            {
                if ((shotX + 1) <= 9 && (shotY + 1) <= 9 && (myMatr[shotY + 1, shotX + 1] != 8 || myMatr[shotY + 1, shotX + 1] != 9))
                { myMatr[shotY + 1, shotX + 1] = 9; }
                if ((shotX - 1) >= 0 && (shotY + 1) <= 9 && (myMatr[shotY + 1, shotX - 1] != 8 || myMatr[shotY + 1, shotX - 1] != 9))
                { myMatr[shotY + 1, shotX - 1] = 9; }
                if ((shotY + 1) <= 9 && (myMatr[shotY + 1, shotX] != 8 || myMatr[shotY + 1, shotX] != 9))
                    if (myMatr[shotY + 1, shotX] != 5)
                    { myMatr[shotY + 1, shotX] = 9; }
                    else
                    {
                        if ((shotX + 1) <= 9 && (shotY + 2) <= 9 && (myMatr[shotY + 2, shotX + 1] != 8 || myMatr[shotY + 2, shotX + 1] != 9))
                        { myMatr[shotY + 2, shotX + 1] = 9; }
                        if ((shotX - 1) >= 0 && (shotY + 2) <= 9 && (myMatr[shotY + 2, shotX - 1] != 8 || myMatr[shotY + 2, shotX - 1] != 9))
                        { myMatr[shotY + 2, shotX - 1] = 9; }
                        if ((shotY + 2) <= 9 && (myMatr[shotY + 2, shotX] != 8 || myMatr[shotY + 2, shotX] != 9))
                            if (myMatr[shotY + 2, shotX] != 5)
                            { myMatr[shotY + 2, shotX] = 9; }
                            else
                            {
                                if ((shotY + 3) <= 9 && (shotX + 1) <= 9 && (myMatr[shotY + 3, shotX + 1] != 8 || myMatr[shotY + 3, shotX + 1] != 9))
                                { myMatr[shotY + 3, shotX + 1] = 9; }
                                if ((shotY + 3) <= 9 && (shotX - 1) >= 0 && (myMatr[shotY + 3, shotX - 1] != 8 || myMatr[shotY + 3, shotX - 1] != 9))
                                { myMatr[shotY + 3, shotX - 1] = 9; }
                                if ((shotY + 3) <= 9 && (myMatr[shotY + 3, shotX] != 8 || myMatr[shotY + 3, shotX] != 9))
                                    if (myMatr[shotY + 3, shotX] != 5)
                                    { myMatr[shotY + 3, shotX] = 9; }
                                    else
                                    {
                                        if ((shotY + 4) <= 9 && (shotX + 1) <= 9 && (myMatr[shotY + 4, shotX + 1] != 8 || myMatr[shotY + 4, shotX + 1] != 9))
                                        { myMatr[shotY + 4, shotX + 1] = 9; }
                                        if ((shotY + 4) <= 9 && (shotX - 1) >= 0 && (myMatr[shotY + 4, shotX - 1] != 8 || myMatr[shotY + 4, shotX - 1] != 9))
                                        { myMatr[shotY + 4, shotX - 1] = 9; }
                                        if ((shotY + 4) <= 9 && (myMatr[shotY + 4, shotX] != 8 || myMatr[shotY + 4, shotX] != 9))
                                        { myMatr[shotY + 4, shotX] = 9; }
                                    }
                            }

                    }

                if ((shotY + 1) <= 9 && (shotX - 1) >= 0 && (myMatr[shotY + 1, shotX - 1] != 8 || myMatr[shotY + 1, shotX - 1] != 9))
                { myMatr[shotY + 1, shotX - 1] = 9; }
                if ((shotY - 1) >= 0 && (shotX - 1) >= 0 && (myMatr[shotY - 1, shotX - 1] != 8 || myMatr[shotY - 1, shotX - 1] != 9))
                { myMatr[shotY - 1, shotX - 1] = 9; }
                if ((shotX - 1) >= 0 && (myMatr[shotY, shotX - 1] != 8 || myMatr[shotY, shotX - 1] != 9))
                    if (myMatr[shotY, shotX - 1] != 5)
                    { myMatr[shotY, shotX - 1] = 9; }
                    else
                    {
                        if ((shotY + 1) <= 9 && (shotX - 2) >= 0 && (myMatr[shotY + 1, shotX - 2] != 8 || myMatr[shotY + 1, shotX - 2] != 9))
                        { myMatr[shotY + 1, shotX - 2] = 9; }
                        if ((shotY - 1) >= 0 && (shotX - 2) >= 0 && (myMatr[shotY - 1, shotX - 2] != 8 || myMatr[shotY - 1, shotX - 2] != 9))
                        { myMatr[shotY - 1, shotX - 2] = 9; }
                        if ((shotX - 2) >= 0 && (myMatr[shotY, shotX - 2] != 8 || myMatr[shotY, shotX - 2] != 9))
                            if (myMatr[shotY, shotX - 2] != 5)
                            { myMatr[shotY, shotX - 2] = 9; }
                            else
                            {
                                if ((shotY + 1) <= 9 && (shotX - 3) >= 0 && (myMatr[shotY + 1, shotX - 3] != 8 || myMatr[shotY + 1, shotX - 3] != 9))
                                { myMatr[shotY + 1, shotX - 3] = 9; }
                                if ((shotY - 1) >= 0 && (shotX - 3) >= 0 && (myMatr[shotY - 1, shotX - 3] != 8 || myMatr[shotY - 1, shotX - 3] != 9))
                                { myMatr[shotY - 1, shotX - 3] = 9; }
                                if ((shotX - 3) >= 0 && (myMatr[shotY, shotX - 3] != 8 || myMatr[shotY, shotX - 3] != 9))
                                    if (myMatr[shotY, shotX - 3] != 5)
                                    { myMatr[shotY, shotX - 3] = 9; }
                                    else
                                    {
                                        if ((shotY + 1) <= 9 && (shotX - 4) >= 0 && (myMatr[shotY + 1, shotX - 4] != 8 || myMatr[shotY + 1, shotX - 4] != 9))
                                        { myMatr[shotY + 1, shotX - 4] = 9; }
                                        if ((shotY - 1) >= 0 && (shotX - 4) >= 0 && (myMatr[shotY - 1, shotX - 4] != 8 || myMatr[shotY - 1, shotX - 4] != 9))
                                        { myMatr[shotY - 1, shotX - 4] = 9; }
                                        if ((shotX - 4) >= 0 && (myMatr[shotY, shotX - 4] != 8 || myMatr[shotY, shotX - 4] != 9))
                                        { myMatr[shotY, shotX - 4] = 9; }
                                    }

                            }

                    }
                if ((shotY - 1) >= 0 && (shotX - 1) >= 0 && (myMatr[shotY - 1, shotX - 1] != 8 || myMatr[shotY - 1, shotX - 1] != 9))
                { myMatr[shotY - 1, shotX - 1] = 9; }
                if ((shotY - 1) >= 0 && (shotX + 1) <= 9 && (myMatr[shotY - 1, shotX + 1] != 8 || myMatr[shotY - 1, shotX + 1] != 9))
                { myMatr[shotY - 1, shotX + 1] = 9; }
                if ((shotY - 1) >= 0 && (myMatr[shotY - 1, shotX] != 8 || myMatr[shotY - 1, shotX] != 9))
                    if (myMatr[shotY - 1, shotX] != 5)
                    { myMatr[shotY - 1, shotX] = 9; }
                    else
                    {
                        if ((shotY - 2) >= 0 && (shotX - 1) >= 0 && (myMatr[shotY - 2, shotX - 1] != 8 || myMatr[shotY - 2, shotX - 1] != 9))
                        { myMatr[shotY - 2, shotX - 1] = 9; }
                        if ((shotY - 2) >= 0 && (shotX + 1) <= 9 && (myMatr[shotY - 2, shotX + 1] != 8 || myMatr[shotY - 2, shotX + 1] != 9))
                        { myMatr[shotY - 2, shotX + 1] = 9; }
                        if ((shotY - 2) >= 0 && (myMatr[shotY - 2, shotX] != 8 || myMatr[shotY - 2, shotX] != 9))
                            if (myMatr[shotY - 2, shotX] != 5)
                            { myMatr[shotY - 2, shotX] = 9; }
                            else
                            {
                                if ((shotY - 3) >= 0 && (shotX - 1) >= 0 && (myMatr[shotY - 3, shotX - 1] != 8 || myMatr[shotY - 3, shotX - 1] != 9))
                                { myMatr[shotY - 3, shotX - 1] = 9; }
                                if ((shotY - 3) >= 0 && (shotX + 1) <= 9 && (myMatr[shotY - 3, shotX + 1] != 8 || myMatr[shotY - 3, shotX + 1] != 9))
                                { myMatr[shotY - 3, shotX + 1] = 9; }
                                if ((shotY - 3) >= 0 && (myMatr[shotY - 3, shotX] != 8 || myMatr[shotY - 3, shotX] != 9))
                                    if (myMatr[shotY - 3, shotX] != 5)
                                    { myMatr[shotY - 3, shotX] = 9; }
                                    else
                                    {
                                        if ((shotY - 4) >= 0 && (shotX - 1) >= 0 && (myMatr[shotY - 4, shotX - 1] != 8 || myMatr[shotY - 4, shotX - 1] != 9))
                                        { myMatr[shotY - 4, shotX - 1] = 9; }
                                        if ((shotY - 4) >= 0 && (shotX + 1) <= 9 && (myMatr[shotY - 4, shotX + 1] != 8 || myMatr[shotY - 4, shotX + 1] != 9))
                                        { myMatr[shotY - 4, shotX + 1] = 9; }
                                        if ((shotY - 4) >= 0 && (myMatr[shotY - 4, shotX] != 8 || myMatr[shotY - 4, shotX] != 9))
                                        { myMatr[shotY - 4, shotX] = 9; }
                                    }
                            }
                    }
                if ((shotY + 1) <= 9 && (shotX + 1) <= 9 && (myMatr[shotY + 1, shotX + 1] != 8 || myMatr[shotY + 1, shotX + 1] != 9))
                { myMatr[shotY + 1, shotX + 1] = 9; }
                if ((shotY - 1) >= 0 && (shotX + 1) <= 9 && (myMatr[shotY - 1, shotX + 1] != 8 || myMatr[shotY - 1, shotX + 1] != 9))
                { myMatr[shotY - 1, shotX + 1] = 9; }
                if ((shotX + 1) <= 9 && (myMatr[shotY, shotX + 1] != 8 || myMatr[shotY, shotX + 1] != 9))
                    if (myMatr[shotY, shotX + 1] != 5)
                    { myMatr[shotY, shotX + 1] = 9; }
                    else
                    {
                        if ((shotY + 1) <= 9 && (shotX + 2) <= 9 && (myMatr[shotY + 1, shotX + 2] != 8 || myMatr[shotY + 1, shotX + 2] != 9))
                        { myMatr[shotY + 1, shotX + 2] = 9; }
                        if ((shotY - 1) >= 0 && (shotX + 2) <= 9 && (myMatr[shotY - 1, shotX + 2] != 8 || myMatr[shotY - 1, shotX + 2] != 9))
                        { myMatr[shotY - 1, shotX + 2] = 9; }
                        if ((shotX + 2) <= 9 && (myMatr[shotY, shotX + 2] != 8 || myMatr[shotY, shotX + 2] != 9))
                            if (myMatr[shotY, shotX + 2] != 5)
                            { myMatr[shotY, shotX + 2] = 9; }
                            else
                            {
                                if ((shotY + 1) <= 9 && (shotX + 3) <= 9 && (myMatr[shotY + 1, shotX + 3] != 8 || myMatr[shotY + 1, shotX + 3] != 9))
                                { myMatr[shotY + 1, shotX + 3] = 9; }
                                if ((shotY - 1) >= 0 && (shotX + 3) <= 9 && (myMatr[shotY - 1, shotX + 3] != 8 || myMatr[shotY - 1, shotX + 3] != 9))
                                { myMatr[shotY - 1, shotX + 3] = 9; }
                                if ((shotX + 3) <= 9 && (myMatr[shotY, shotX + 3] != 8 || myMatr[shotY, shotX + 3] != 9))
                                    if (myMatr[shotY, shotX + 3] != 5)
                                    { myMatr[shotY, shotX + 3] = 9; }
                                    else
                                    {
                                        if ((shotY + 1) <= 9 && (shotX + 4) <= 9 && (myMatr[shotY + 1, shotX + 4] != 8 || myMatr[shotY + 1, shotX + 4] != 9))
                                        { myMatr[shotY + 1, shotX + 4] = 9; }
                                        if ((shotY - 1) >= 0 && (shotX + 4) <= 9 && (myMatr[shotY - 1, shotX + 4] != 8 || myMatr[shotY - 1, shotX + 4] != 9))
                                        { myMatr[shotY - 1, shotX + 4] = 9; }
                                        if ((shotX + 4) <= 9 && (myMatr[shotY, shotX + 4] != 8 || myMatr[shotY, shotX + 4] != 9))
                                        { myMatr[shotY, shotX + 4] = 9; }
                                    }

                            }

                    }
                numberOfDecks = 20;
            }

        }

        private static void CheckShotAI()
        {
            if (myMatr[hitY, hitX] == 1 || myMatr[hitY, hitX] == 2 || myMatr[hitY, hitX] == 3 ||
                myMatr[hitY, hitX] == 4)
            {
                myMatr[hitY, hitX] = 5;
                shotX = hitX;
                shotY = hitY;
                hit = true;
                sh = true;
            }
            else if (myMatr[hitY, hitX] == 0)
            {
                myMatr[hitY, hitX] = 8;
                hit = false;
                sh = true;
            }
            else if (myMatr[hitY, hitX] == 9 || myMatr[hitY, hitX] == 8 || myMatr[hitY, hitX] == 5) { sh = false; }
        }

        private static void RandomFireComp(ref bool fireComp)
        {
            tactics = 0;
            choose = false;

            string compAxisShot;

            Random r = new Random();
            shotX = r.Next(0, 10);
            shotY = r.Next(0, 10);

            tactics = 0;

            while (myMatr[shotY, shotX] == 5 || myMatr[shotY, shotX] == 8 || myMatr[shotY, shotX] == 9)
            {
                shotX = r.Next(0, 10);
                shotY = r.Next(0, 10);
            }

            switch (shotX)
            {
                case 0:
                    compAxisShot = "A";
                    break;
                case 1:
                    compAxisShot = "B";
                    break;
                case 2:
                    compAxisShot = "C";
                    break;
                case 3:
                    compAxisShot = "D";
                    break;
                case 4:
                    compAxisShot = "E";
                    break;
                case 5:
                    compAxisShot = "F";
                    break;
                case 6:
                    compAxisShot = "G";
                    break;
                case 7:
                    compAxisShot = "H";
                    break;
                case 8:
                    compAxisShot = "I";
                    break;
                case 9:
                    compAxisShot = "J";
                    break;
                default:
                    compAxisShot = "NULL";
                    break;
            }

            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Comp shot's X = {0}", compAxisShot);
            Console.WriteLine("Comp shot's Y = {0}", (shotY + 1));

            if (myMatr[shotY, shotX] == 1 || myMatr[shotY, shotX] == 2 || myMatr[shotY, shotX] == 3 || myMatr[shotY, shotX] == 4)
            {
                numberOfDecks = myMatr[shotY, shotX];
                numberOfDecks--;
                myMatr[shotY, shotX] = 5;
                hit = true;
                if (numberOfDecks != 0) { method = "AI"; }
                else { method = "random"; }
                counterMine--;
                fireComp = true;
                firstShotX = shotX;
                firstShotY = shotY;

            }
            else if (myMatr[shotY, shotX] == 0)
            {
                myMatr[shotY, shotX] = 8;
                method = "random";
                fireComp = false;
            }

            if (destroy)
            {
                firstShotX = 0;
                firstShotY = 0;
            }
            DrawAreaAroundTheShip();

            Thread.Sleep(1000);
        }


        private static bool Fire(int[,] matr, ref int counterComp)
        {
            bool fire = false;
            string axis, y;

            do
            {
                Console.SetCursorPosition(0, 1);
                Console.Write("     ");
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Input X of shot from A to J: ");
                axis = Console.ReadLine();
                axis = axis.ToLower();
            } while (!(axis == "a" || axis == "b" || axis == "c" || axis == "d" || axis == "e" || axis == "f" || axis == "g" || axis == "h"
            || axis == "i" || axis == "j"));

            switch (axis)
            {
                case "a":
                    myShotX = 0;
                    break;
                case "b":
                    myShotX = 1;
                    break;
                case "c":
                    myShotX = 2;
                    break;
                case "d":
                    myShotX = 3;
                    break;
                case "e":
                    myShotX = 4;
                    break;
                case "f":
                    myShotX = 5;
                    break;
                case "g":
                    myShotX = 6;
                    break;
                case "h":
                    myShotX = 7;
                    break;
                case "i":
                    myShotX = 8;
                    break;
                case "j":
                    myShotX = 9;
                    break;
                
            }

            do
            {
                Console.SetCursorPosition(0, 3);
                Console.Write("     ");
                Console.SetCursorPosition(0, 2);
                Console.WriteLine("Input Y of shot from 1 to 10: ");
                y = Console.ReadLine();
            } while (!(y == "1" || y == "2" || y == "3" || y == "4" || y == "5" || y == "6" || y == "7" || y == "8" || y == "9" 
            || y == "10"));

            myShotY = Int32.Parse(y);
            
            myShotY -= 1;

            if (matr[myShotY, myShotX] == 1 || matr[myShotY, myShotX] == 2 || matr[myShotY, myShotX] == 3 || matr[myShotY, myShotX] == 4)
            {
                if ((matr[myShotY, myShotX] == 2 || matr[myShotY, myShotX] == 3 || matr[myShotY, myShotX] == 4) && compDeckCounter == 20)
                {
                    compDeck = matr[myShotY, myShotX];
                    compDeckCounter = (matr[myShotY, myShotX] - 1);
                    destroy = false;
                }
                else if (matr[myShotY, myShotX] == 1 && compDeckCounter == 20)
                {
                    destroy = true;
                }
                else
                {
                    compDeckCounter -= 1;
                    if (compDeckCounter == 0)
                    {
                        destroy = true;
                        compDeckCounter = 20;
                    }
                }
                matr[myShotY, myShotX] = 5;
                DrawAreaCompMatr();
                counterComp -= 1;
                fire = true;
            }
            if (matr[myShotY, myShotX] == 0)
            {
                matr[myShotY, myShotX] = 8;
                fire = false;
            }

            return fire;
        }

        private static void DrawAreaCompMatr()
        {
            if (destroy)
            {
                if ((myShotX + 1) <= 9 && (myShotY + 1) <= 9 && (compMatr[myShotY + 1, myShotX + 1] != 8 || compMatr[myShotY + 1, myShotX + 1] != 9))
                { compMatr[myShotY + 1, myShotX + 1] = 9; }
                if ((myShotX - 1) >= 0 && (myShotY + 1) <= 9 && (compMatr[myShotY + 1, myShotX - 1] != 8 || compMatr[myShotY + 1, myShotX - 1] != 9))
                { compMatr[myShotY + 1, myShotX - 1] = 9; }
                if ((myShotY + 1) <= 9 && (compMatr[myShotY + 1, myShotX] != 8 || compMatr[myShotY + 1, myShotX] != 9))
                    if (compMatr[myShotY + 1, myShotX] != 5)
                    { compMatr[myShotY + 1, myShotX] = 9; }
                    else
                    {
                        if ((myShotX + 1) <= 9 && (myShotY + 2) <= 9 && (compMatr[myShotY + 2, myShotX + 1] != 8 || compMatr[myShotY + 2, myShotX + 1] != 9))
                        { compMatr[myShotY + 2, myShotX + 1] = 9; }
                        if ((myShotX - 1) >= 0 && (myShotY + 2) <= 9 && (compMatr[myShotY + 2, myShotX - 1] != 8 || compMatr[myShotY + 2, myShotX - 1] != 9))
                        { compMatr[myShotY + 2, myShotX - 1] = 9; }
                        if ((myShotY + 2) <= 9 && (compMatr[myShotY + 2, myShotX] != 8 || compMatr[myShotY + 2, myShotX] != 9))
                            if (compMatr[myShotY + 2, myShotX] != 5)
                            { compMatr[myShotY + 2, myShotX] = 9; }
                            else
                            {
                                if ((myShotY + 3) <= 9 && (myShotX + 1) <= 9 && (compMatr[myShotY + 3, myShotX + 1] != 8 || compMatr[myShotY + 3, myShotX + 1] != 9))
                                { compMatr[myShotY + 3, myShotX + 1] = 9; }
                                if ((myShotY + 3) <= 9 && (myShotX - 1) >= 0 && (compMatr[myShotY + 3, myShotX - 1] != 8 || compMatr[myShotY + 3, myShotX - 1] != 9))
                                { compMatr[myShotY + 3, myShotX - 1] = 9; }
                                if ((myShotY + 3) <= 9 && (compMatr[myShotY + 3, myShotX] != 8 || compMatr[myShotY + 3, myShotX] != 9))
                                    if (compMatr[myShotY + 3, myShotX] != 5)
                                    { compMatr[myShotY + 3, myShotX] = 9; }
                                    else
                                    {
                                        if ((myShotY + 4) <= 9 && (myShotX + 1) <= 9 && (compMatr[myShotY + 4, myShotX + 1] != 8 || compMatr[myShotY + 4, myShotX + 1] != 9))
                                        { compMatr[myShotY + 4, myShotX + 1] = 9; }
                                        if ((myShotY + 4) <= 9 && (myShotX - 1) >= 0 && (compMatr[myShotY + 4, myShotX - 1] != 8 || compMatr[myShotY + 4, myShotX - 1] != 9))
                                        { compMatr[myShotY + 4, myShotX - 1] = 9; }
                                        if ((myShotY + 4) <= 9 && (compMatr[myShotY + 4, myShotX] != 8 || compMatr[myShotY + 4, myShotX] != 9))
                                        { compMatr[myShotY + 4, myShotX] = 9; }
                                    }
                            }

                    }

                if ((myShotY + 1) <= 9 && (myShotX - 1) >= 0 && (compMatr[myShotY + 1, myShotX - 1] != 8 || compMatr[myShotY + 1, myShotX - 1] != 9))
                { compMatr[myShotY + 1, myShotX - 1] = 9; }
                if ((myShotY - 1) >= 0 && (myShotX - 1) >= 0 && (compMatr[myShotY - 1, myShotX - 1] != 8 || compMatr[myShotY - 1, myShotX - 1] != 9))
                { compMatr[myShotY - 1, myShotX - 1] = 9; }
                if ((myShotX - 1) >= 0 && (compMatr[myShotY, myShotX - 1] != 8 || compMatr[myShotY, myShotX - 1] != 9))
                    if (compMatr[myShotY, myShotX - 1] != 5)
                    { compMatr[myShotY, myShotX - 1] = 9; }
                    else
                    {
                        if ((myShotY + 1) <= 9 && (myShotX - 2) >= 0 && (compMatr[myShotY + 1, myShotX - 2] != 8 || compMatr[myShotY + 1, myShotX - 2] != 9))
                        { compMatr[myShotY + 1, myShotX - 2] = 9; }
                        if ((myShotY - 1) >= 0 && (myShotX - 2) >= 0 && (compMatr[myShotY - 1, myShotX - 2] != 8 || compMatr[myShotY - 1, myShotX - 2] != 9))
                        { compMatr[myShotY - 1, myShotX - 2] = 9; }
                        if ((myShotX - 2) >= 0 && (compMatr[myShotY, myShotX - 2] != 8 || compMatr[myShotY, myShotX - 2] != 9))
                            if (compMatr[myShotY, myShotX - 2] != 5)
                            { compMatr[myShotY, myShotX - 2] = 9; }
                            else
                            {
                                if ((myShotY + 1) <= 9 && (myShotX - 3) >= 0 && (compMatr[myShotY + 1, myShotX - 3] != 8 || compMatr[myShotY + 1, myShotX - 3] != 9))
                                { compMatr[myShotY + 1, myShotX - 3] = 9; }
                                if ((myShotY - 1) >= 0 && (myShotX - 3) >= 0 && (compMatr[myShotY - 1, myShotX - 3] != 8 || compMatr[myShotY - 1, myShotX - 3] != 9))
                                { compMatr[myShotY - 1, myShotX - 3] = 9; }
                                if ((myShotX - 3) >= 0 && (compMatr[myShotY, myShotX - 3] != 8 || compMatr[myShotY, myShotX - 3] != 9))
                                    if (compMatr[myShotY, myShotX - 3] != 5)
                                    { compMatr[myShotY, myShotX - 3] = 9; }
                                    else
                                    {
                                        if ((myShotY + 1) <= 9 && (myShotX - 4) >= 0 && (compMatr[myShotY + 1, myShotX - 4] != 8 || compMatr[myShotY + 1, myShotX - 4] != 9))
                                        { compMatr[myShotY + 1, myShotX - 4] = 9; }
                                        if ((myShotY - 1) >= 0 && (myShotX - 4) >= 0 && (compMatr[myShotY - 1, myShotX - 4] != 8 || compMatr[myShotY - 1, myShotX - 4] != 9))
                                        { compMatr[myShotY - 1, myShotX - 4] = 9; }
                                        if ((myShotX - 4) >= 0 && (compMatr[myShotY, myShotX - 4] != 8 || compMatr[myShotY, myShotX - 4] != 9))
                                        { compMatr[myShotY, myShotX - 4] = 9; }
                                    }

                            }

                    }
                if ((myShotY - 1) >= 0 && (myShotX - 1) >= 0 && (compMatr[myShotY - 1, myShotX - 1] != 8 || compMatr[myShotY - 1, myShotX - 1] != 9))
                { compMatr[myShotY - 1, myShotX - 1] = 9; }
                if ((myShotY - 1) >= 0 && (myShotX + 1) <= 9 && (compMatr[myShotY - 1, myShotX + 1] != 8 || compMatr[myShotY - 1, myShotX + 1] != 9))
                { compMatr[myShotY - 1, myShotX + 1] = 9; }
                if ((myShotY - 1) >= 0 && (compMatr[myShotY - 1, myShotX] != 8 || compMatr[myShotY - 1, myShotX] != 9))
                    if (compMatr[myShotY - 1, myShotX] != 5)
                    { compMatr[myShotY - 1, myShotX] = 9; }
                    else
                    {
                        if ((myShotY - 2) >= 0 && (myShotX - 1) >= 0 && (compMatr[myShotY - 2, myShotX - 1] != 8 || compMatr[myShotY - 2, myShotX - 1] != 9))
                        { compMatr[myShotY - 2, myShotX - 1] = 9; }
                        if ((myShotY - 2) >= 0 && (myShotX + 1) <= 9 && (compMatr[myShotY - 2, myShotX + 1] != 8 || compMatr[myShotY - 2, myShotX + 1] != 9))
                        { compMatr[myShotY - 2, myShotX + 1] = 9; }
                        if ((myShotY - 2) >= 0 && (compMatr[myShotY - 2, myShotX] != 8 || compMatr[myShotY - 2, myShotX] != 9))
                            if (compMatr[myShotY - 2, myShotX] != 5)
                            { compMatr[myShotY - 2, myShotX] = 9; }
                            else
                            {
                                if ((myShotY - 3) >= 0 && (myShotX - 1) >= 0 && (compMatr[myShotY - 3, myShotX - 1] != 8 || compMatr[myShotY - 3, myShotX - 1] != 9))
                                { compMatr[myShotY - 3, myShotX - 1] = 9; }
                                if ((myShotY - 3) >= 0 && (myShotX + 1) <= 9 && (compMatr[myShotY - 3, myShotX + 1] != 8 || compMatr[myShotY - 3, myShotX + 1] != 9))
                                { compMatr[myShotY - 3, myShotX + 1] = 9; }
                                if ((myShotY - 3) >= 0 && (compMatr[myShotY - 3, myShotX] != 8 || compMatr[myShotY - 3, myShotX] != 9))
                                    if (compMatr[myShotY - 3, myShotX] != 5)
                                    { compMatr[myShotY - 3, myShotX] = 9; }
                                    else
                                    {
                                        if ((myShotY - 4) >= 0 && (myShotX - 1) >= 0 && (compMatr[myShotY - 4, myShotX - 1] != 8 || compMatr[myShotY - 4, myShotX - 1] != 9))
                                        { compMatr[myShotY - 4, myShotX - 1] = 9; }
                                        if ((myShotY - 4) >= 0 && (myShotX + 1) <= 9 && (compMatr[myShotY - 4, myShotX + 1] != 8 || compMatr[myShotY - 4, myShotX + 1] != 9))
                                        { compMatr[myShotY - 4, myShotX + 1] = 9; }
                                        if ((myShotY - 4) >= 0 && (compMatr[myShotY - 4, myShotX] != 8 || compMatr[myShotY - 4, myShotX] != 9))
                                        { compMatr[myShotY - 4, myShotX] = 9; }
                                    }
                            }
                    }
                if ((myShotY + 1) <= 9 && (myShotX + 1) <= 9 && (compMatr[myShotY + 1, myShotX + 1] != 8 || compMatr[myShotY + 1, myShotX + 1] != 9))
                { compMatr[myShotY + 1, myShotX + 1] = 9; }
                if ((myShotY - 1) >= 0 && (myShotX + 1) <= 9 && (compMatr[myShotY - 1, myShotX + 1] != 8 || compMatr[myShotY - 1, myShotX + 1] != 9))
                { compMatr[myShotY - 1, myShotX + 1] = 9; }
                if ((myShotX + 1) <= 9 && (compMatr[myShotY, myShotX + 1] != 8 || compMatr[myShotY, myShotX + 1] != 9))
                    if (compMatr[myShotY, myShotX + 1] != 5)
                    { compMatr[myShotY, myShotX + 1] = 9; }
                    else
                    {
                        if ((myShotY + 1) <= 9 && (myShotX + 2) <= 9 && (compMatr[myShotY + 1, myShotX + 2] != 8 || compMatr[myShotY + 1, myShotX + 2] != 9))
                        { compMatr[myShotY + 1, myShotX + 2] = 9; }
                        if ((myShotY - 1) >= 0 && (myShotX + 2) <= 9 && (compMatr[myShotY - 1, myShotX + 2] != 8 || compMatr[myShotY - 1, myShotX + 2] != 9))
                        { compMatr[myShotY - 1, myShotX + 2] = 9; }
                        if ((myShotX + 2) <= 9 && (compMatr[myShotY, myShotX + 2] != 8 || compMatr[myShotY, myShotX + 2] != 9))
                            if (compMatr[myShotY, myShotX + 2] != 5)
                            { compMatr[myShotY, myShotX + 2] = 9; }
                            else
                            {
                                if ((myShotY + 1) <= 9 && (myShotX + 3) <= 9 && (compMatr[myShotY + 1, myShotX + 3] != 8 || compMatr[myShotY + 1, myShotX + 3] != 9))
                                { compMatr[myShotY + 1, myShotX + 3] = 9; }
                                if ((myShotY - 1) >= 0 && (myShotX + 3) <= 9 && (compMatr[myShotY - 1, myShotX + 3] != 8 || compMatr[myShotY - 1, myShotX + 3] != 9))
                                { compMatr[myShotY - 1, myShotX + 3] = 9; }
                                if ((myShotX + 3) <= 9 && (compMatr[myShotY, myShotX + 3] != 8 || compMatr[myShotY, myShotX + 3] != 9))
                                    if (compMatr[myShotY, myShotX + 3] != 5)
                                    { compMatr[myShotY, myShotX + 3] = 9; }
                                    else
                                    {
                                        if ((myShotY + 1) <= 9 && (myShotX + 4) <= 9 && (compMatr[myShotY + 1, myShotX + 4] != 8 || compMatr[myShotY + 1, myShotX + 4] != 9))
                                        { compMatr[myShotY + 1, myShotX + 4] = 9; }
                                        if ((myShotY - 1) >= 0 && (myShotX + 4) <= 9 && (compMatr[myShotY - 1, myShotX + 4] != 8 || compMatr[myShotY - 1, myShotX + 4] != 9))
                                        { compMatr[myShotY - 1, myShotX + 4] = 9; }
                                        if ((myShotX + 4) <= 9 && (compMatr[myShotY, myShotX + 4] != 8 || compMatr[myShotY, myShotX + 4] != 9))
                                        { compMatr[myShotY, myShotX + 4] = 9; }
                                    }

                            }

                    }

            }
        }

        private static void InputShips()
        {
            int startX, startY, direction;
            bool marker;
            int numberOfDecks = 0;
            for (int i = 0; i < 10; i++)
            {
                Console.Clear();
                do
                {
                    switch (i)
                    {
                        case 0:
                            numberOfDecks = 4;
                            break;
                        case 1:
                        case 2:
                            numberOfDecks = 3;
                            break;
                        case 3:
                        case 4:
                        case 5:
                            numberOfDecks = 2;
                            break;
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                            numberOfDecks = 1;
                            break;
                    }

                    Console.WriteLine("Input location of {0} ship: X = ", numberOfDecks);
                    startX = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Input location of {0} ship: Y = ", numberOfDecks);
                    startY = Int32.Parse(Console.ReadLine());
                    if (numberOfDecks != 1)
                    {
                        do
                        {
                            Console.WriteLine("Input direction of {0} ship: (0 is horizontal, 1 is vertical) ", numberOfDecks);
                            direction = Int32.Parse(Console.ReadLine());
                        } while (!(direction >= 0 && direction <= 1));
                    }
                    else
                    {
                        direction = 0;
                    }

                    if (FillMatr(myMatrCopy, startX, startY, direction, numberOfDecks))
                    {
                        marker = true;
                        FillMatr(myMatr, startX, startY, direction, numberOfDecks);
                    }
                    else
                    {
                        myMatrCopy = myMatr;
                        marker = false;
                    }

                } while (!(marker));
            }


        }

        private static void PrintBattlefield()
        {
            Console.Clear();

            if (myHit)
            {
                Console.SetCursorPosition(0, 4);
                if (destroy == true)
                {
                    Console.Write("Ship destroyed");
                }
                else if (compDeck == 1 && compDeckCounter != 0)
                {
                    Console.Write("HIT! {0} deck", compDeck);
                }
                else if (compDeck != 0 && compDeck != 1)
                {
                    Console.Write("HIT! {0} decks", compDeck);
                }
            }

            if (lastHitX[0] != 0)
            {
                Console.SetCursorPosition(60, 0);
                Console.Write("Last hit X:");
                for (int i = 0; i < 5; i++)
                {
                    Console.SetCursorPosition(60, (1 + i));
                    if (lastHitX[i] != 0) { Console.Write(lastHitX[i]); }
                }

                Console.SetCursorPosition(75, 0);
                Console.Write("Last hit Y:");
                for (int i = 0; i < 5; i++)
                {
                    Console.SetCursorPosition(75, (1 + i));
                    if (lastHitY[i] != 0) { Console.Write(lastHitY[i]); }
                }
            }

            Battlefield(myMatr);
            PrintMyShips();
            x += 40;
            CompBattlefield(compMatr);
            PrintCompShips();
            x = 10;
        }

        private static void PrintCompShips()
        {
            bool four = false, three = false, two = false, one = false;
            int quantityOfThree = 0, quantityOfTwo = 0, quantityOfOne = 0;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (compMatr[i, j] == 4) { four = true; }
                    else if (compMatr[i, j] == 3) { three = true; quantityOfThree++; }
                    else if (compMatr[i, j] == 2) { two = true; quantityOfTwo++; }
                    else if (compMatr[i, j] == 1) { one = true; quantityOfOne++; }
                }
            }

            y = 22;
            Console.SetCursorPosition(x, y);
            Console.Write("Comp's fleet :");

            if (four)
            {
                y++;
                Console.SetCursorPosition(x, y);
                Console.Write("1 ");
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write("        ");
                Console.BackgroundColor = ConsoleColor.Black;
            }
            if (three)
            {
                y++;
                Console.SetCursorPosition(x, y);
                Console.Write("{0} ", (quantityOfThree / 3));
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write("      ");
                Console.BackgroundColor = ConsoleColor.Black;
            }
            if (two)
            {
                y++;
                Console.SetCursorPosition(x, y);
                Console.Write("{0} ", (quantityOfTwo / 2));
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write("    ");
                Console.BackgroundColor = ConsoleColor.Black;
            }
            if (one)
            {
                y++;
                Console.SetCursorPosition(x, y);
                Console.Write("{0} ", (quantityOfOne));
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write("  ");
                Console.BackgroundColor = ConsoleColor.Black;
            }
            y = 10;
        }

        private static void PrintMyShips()
        {
            bool four = false, three = false, two = false, one = false;
            int quantityOfThree = 0, quantityOfTwo = 0, quantityOfOne = 0;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (myMatr[i,j] == 4) { four = true; }
                    else if (myMatr[i,j] == 3) { three = true; quantityOfThree++; }
                    else if (myMatr[i,j] == 2) { two = true; quantityOfTwo++; }
                    else if (myMatr[i,j] == 1) { one = true; quantityOfOne++; }
                }
            }

            y = 22;
            Console.SetCursorPosition(x, y);
            Console.Write("My fleet :");

            if (four)
            {
                y++;
                Console.SetCursorPosition(x, y);
                Console.Write("1 ");
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write("        ");
                Console.BackgroundColor = ConsoleColor.Black;
            }
            if (three)
            {
                y++;
                Console.SetCursorPosition(x, y);
                Console.Write("{0} ", (quantityOfThree / 3));
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write("      ");
                Console.BackgroundColor = ConsoleColor.Black;
            }
            if (two)
            {
                y++;
                Console.SetCursorPosition(x, y);
                Console.Write("{0} ", (quantityOfTwo / 2));
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write("    ");
                Console.BackgroundColor = ConsoleColor.Black;
            }
            if (one)
            {
                y++;
                Console.SetCursorPosition(x, y);
                Console.Write("{0} ", (quantityOfOne));
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write("  ");
                Console.BackgroundColor = ConsoleColor.Black;
            }
            y = 10;
        }

        private static void CompBattlefield(int[,] matr)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("  A B C D E F G H I J");

            for (int i = 0; i < 10; i++)
            {
                if ((i + 1) != 10)
                {
                    Console.SetCursorPosition(x, y + 1 + i);
                }
                else
                {
                    Console.SetCursorPosition(x - 1, y + 1 + i);
                }
                Console.Write((i + 1));
            }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    if (j == 10)
                    {
                        Console.SetCursorPosition(x + 1 + j * 2, y + 1 + i);
                        Console.Write("|");
                    }
                    else
                    {
                        if (matr[i, j] == 5)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                        }
                        else if (matr[i, j] == 8)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                        }
                        else if (matr[i, j] == 9)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        Console.SetCursorPosition(x + 1 + j * 2, y + 1 + i);
                        Console.Write("  ");
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                }
            }
        }

        private static void Battlefield(int[,] matr)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("  A B C D E F G H I J");
            
            for (int i = 0; i < 10; i++)
            {
                if ((i + 1) != 10)
                {
                    Console.SetCursorPosition(x, y + 1 + i);
                }
                else
                {
                    Console.SetCursorPosition(x - 1, y + 1 + i);
                }
                Console.Write((i + 1));
            }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    if (j == 10)
                    {
                        Console.SetCursorPosition(x + 1 + j * 2, y + 1 + i);
                        Console.Write("|");
                    }
                    else
                    {
                        if (matr[i, j] == 1 || matr[i, j] == 2 || matr[i, j] == 3 || matr[i, j] == 4)
                        {
                            Console.BackgroundColor = ConsoleColor.White;

                        }
                        else if (matr[i, j] == 5)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                        }
                        else if (matr[i, j] == 8)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                        }
                        else if (matr[i, j] == 9)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        Console.SetCursorPosition(x + 1 + j * 2, y + 1 + i);
                        Console.Write("  ");
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                }
            }
        }

        private static bool FillMatr(int[,] matr, int startX, int startY, int direction, int size)
        {
            bool ship = false;
            bool fill = true;
            startX -= 1;
            startY -= 1;

            if (direction == 0 && startX + size > 9)
            {
                return false;
            }
            else if (direction == 1 && startY + size > 9)
            {
                return false;
            }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (matr[i, j] == 0)
                    {
                        if (i == startY && j == startX && matr[i, j] == 0)
                        {
                            ship = true;
                            if (direction == 0 && size != 0)
                            {
                                startX += 1;
                                size = size - 1;
                            }
                            else if (direction == 1 && size != 0)
                            {
                                startY += 1;
                                size = size - 1;
                            }
                            else
                            {
                                ship = false;
                            }
                        }
                        if (ship && fill == true)
                        {
                            matr[i, j] = 1;
                            fill = true;
                            ship = false;
                        }
                        else
                        {
                            matr[i, j] = 0;
                        }
                    }
                    else if (matr[i, j] == 1)
                    {
                        if (i == startY && j == startX && matr[i, j] == 1)
                        {
                            if (direction == 0 && size != 0)
                            {
                                startX += 1;
                                size = size - 1;
                            }
                            else if (direction == 1 && size != 0)
                            {
                                startY += 1;
                                size = size - 1;
                            }
                            fill = false;
                            ship = false;
                        }
                        continue;
                    }
                }
            }
            return fill;
        }
    }
}
