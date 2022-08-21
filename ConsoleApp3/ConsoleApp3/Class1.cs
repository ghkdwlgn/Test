using System;
using System.Threading;

namespace OXGAME
{
    class Class1
    {
        static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1;
        static int choice;
        static int flag = 0;

        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Player1:X         Player2:O");
                Console.WriteLine("\n");
                if (player % 2 == 0)
                {
                    Console.WriteLine("Player 2 차례");
                }
                else
                {
                    Console.WriteLine("Player 1 차례");
                }
                Console.WriteLine("\n");
                Board();
                choice = int.Parse(Console.ReadLine());
                if (arr[choice] != 'X' && arr[choice] != 'O')
                {
                    if (player % 2 == 0)
                    {
                        arr[choice] = 'O';
                        player++;
                    }
                    else
                    {
                        arr[choice] = 'X';
                        player++;
                    }
                }
                else
                {
                    Console.WriteLine("죄송하지만 {0}에는 이미 놓여있어 {1}은 놓을 수 없습니다", choice, arr[choice]);
                    Console.WriteLine("\n");
                    Console.WriteLine("다시 시작되기까지 1초만 기다려 주세요.....");
                    Thread.Sleep(1000);
                }
                flag = CheckWin();
            }
            while (flag != 1 && flag != -1);

            Console.Clear();
            Board();
            if (flag == 1)

            {
                Console.WriteLine("플레이어 {0}님이 승리하셨습니다!", (player % 2) + 1);
            }
            else
            {
                Console.WriteLine("-----무승부------");
            }
            Console.ReadLine();
        }

        private static void Board()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[1], arr[2], arr[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[4], arr[5], arr[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[7], arr[8], arr[9]);
            Console.WriteLine("     |     |      ");
        }

        private static int CheckWin()
        {

            //첫째줄의 우승 조건(가로)
            if (arr[1] == arr[2] && arr[2] == arr[3])
            {
                return 1;
            }
            //둘째줄의 우승 조건(가로)
            else if (arr[4] == arr[5] && arr[5] == arr[6])
            {
                return 1;
            }
            //셋째줄의 우승 조건(가로)
            else if (arr[6] == arr[7] && arr[7] == arr[8])
            {
                return 1;
            }

            //첫째줄의 우승 조건(세로)
            else if (arr[1] == arr[4] && arr[4] == arr[7])
            {
                return 1;
            }
            //둘째줄의 우승 조건(세로)
            else if (arr[2] == arr[5] && arr[5] == arr[8])
            {
                return 1;
            }
            //셋째줄의 우승 조건(세로)
            else if (arr[3] == arr[6] && arr[6] == arr[9])
            {
                return 1;
            }

            else if (arr[1] == arr[5] && arr[5] == arr[9])
            {
                return 1;
            }
            else if (arr[3] == arr[5] && arr[5] == arr[7])
            {
                return 1;
            }

            // 무승부의 조건(모든 칸이 다 채워졌음에도 끝나지 않았을 때)
            else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')
            {
                return -1;
            }

            else
            {
                return 0;
            }
        }
    }
}