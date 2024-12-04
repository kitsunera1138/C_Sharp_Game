using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Game
{
    //메인메뉴씬
    //게임 씬 - 현재 포켓몬, 현재 층
    // 공격 볼(대신 스탯보기?) 가방 도망가기     -> 포켓몬 기술 4가지
    //esp 보조 씬
    //게임 승리
    //게임 오버
    public static class UIManager //더블버퍼관리 버퍼 지우기 관리
    {
        public static void MainMenuScene()//정적 매서드
        {
            Console.WriteLine("--------------------");

            Console.WriteLine("1. GameStart");
            Console.WriteLine();
            Console.WriteLine("2. GameEnd");
            
            Console.WriteLine("--------------------");
            Console.WriteLine("Press Enter");
            Input();
        }
        public static void Input()
        {
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                Console.WriteLine($"You pressed: {keyInfo.Key}");

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine("Exiting...");
                    ClearConsoleBuffer();
                    break;
                }

                if (keyInfo.Key == ConsoleKey.Escape) //선택창 //게임계속 스탯활성화 게임종료
                {
                    Console.WriteLine("Escape Key...");
                    ClearConsoleBuffer();
                    break;
                }
            }

        }
        public static void GameScene()
        {
            Console.WriteLine("--------------------");
            Console.WriteLine();
            Console.WriteLine("현재 층: "+ GameManager.Instance.CurrentMap);
            Console.WriteLine("현재 포켓몬: " + GameManager.Instance.currentPokemon.name);


            Console.WriteLine();
            Console.WriteLine("--------------------");
        }

        public static void ClearConsoleBuffer()
        {
            // 콘솔 화면 전체 지우기
            Console.Clear(); 
        }
    }
}
