using CSharp_Game;
using static CSharp_Game.Skill;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CSharp_Game.Pokemon;

namespace CSharp_Game
{
    //메인메뉴씬
    //게임 씬 - 현재 포켓몬, 현재 층
    // 공격 볼(대신 스탯!보기? 교체?) 가방 도망가기     -> 포켓몬 기술 4가지
    //esp 보조 씬
    //게임 승리
    //게임 오버

    //공격(싸운다 - 기술) 포켓몬 도구(상처약 5개..포켓몬 쓰러트리면 아이템 추가?) 도망간다
    //상황?ㅜ 
    //[공격] [포켓몬 능력치] [도망간다]
    //공격
    //스킬1 스킬2 스킬3 스킬4
    //커서 위치에 따라 옆에 스킬 설명

    //스킬 사용 후 스킬을 썼다 채팅 밑에


    //도구 회복약
    public class UIManager //더블버퍼관리 버퍼 지우기 관리
    {
        static string RightNull = "                    ";

        private static int x;
        private static int y;


        //체력많으면 초록 일정이하 떨어지면 빨간색
        public static void Initialize()
        {
            x = 1;
            y = 1;
        }

        public static void MainMenuScene()//정적 매서드
        {
            CusurOff();
            ConsoleColors.ResetColor();
            ConsoleColors.ChangeColor(COLORS.White);

            //OriginColor = Console.ForegroundColor;

            //ChangeColor(ConsoleColor.Red);
            Console.WriteLine("------------------------------------------------------------");
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine();
            }

            Console.WriteLine("모든 포켓몬의 개체값은 1~31사이 랜덤입니다");

            Console.WriteLine("맵 라운드는 전체 10 라운드이며");
            Console.WriteLine("포켓몬이 기절시 게임은 종료 됩니다.");

            //Console.WriteLine("방향키를 움직여서 Enter키로 선택합니다.");
            Console.WriteLine("숫자키로 선택합니다.");

            //Console.WriteLine("escpae키를 누르면 능력치를 확인 할 수 있습니다.");
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine();
            }

            Console.WriteLine("GameStart");
            ConsoleColors.ChangeColor(COLORS.Red);
            Console.WriteLine("Press Enter"); ConsoleColors.ResetColor();
            Console.WriteLine();

            Console.WriteLine("------------------------------------------------------------");

            Input();
        }

        public static void WaitForEnterBar()
        {
            Console.WriteLine("계속하려면 Enter를 누르세요...");
            //  Enter를 누를 때까지 대기
            while (Console.ReadKey(true).Key != ConsoleKey.Enter)
            {

            }
        }

        void ShowInformation()
        {
            //스탯을 보여줌
            ShowState();
        }
        
        //팩토리에서 생성
        static void ChoosePokemon()
        {
            //Console.WriteLine("당신의 포켓몬을 선택해주세요");

            //Console.WriteLine("1. 이상해씨");
            //Console.WriteLine("2. 파이리");
            //Console.WriteLine("3. 꼬부기");
            //Console.WriteLine("4. 피카츄");
            

            //while (true)
            //{
            //    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            //    if (keyInfo.Key == ConsoleKey.Enter)
            //    {
            //        Console.WriteLine("선택");
            //        Pokemon.Pokemon playerPokemon = new Pokemon.Pikachu();
            //        GameManager.Instance.PlayerPokemon(playerPokemon);
            //        ClearConsoleBuffer();
            //        ConsoleColors.ChangeColor(COLORS.Red);

            //        Console.WriteLine(GameManager.Instance.playerPokemon.name + "를 선택하셨습니다.");
                    
            //        break;
            //    }


            //    //ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            //    //if (keyInfo.Key == ConsoleKey.Enter) // + 죄표가 ~라면
            //    //{
            //    //    if (x == 2 && y == 2) //피카츄 선택 시
            //    //    {
            //    //Console.WriteLine("피카츄를 선택하셨습니다.");
            //    //        Pokemon.Pokemon playerPokemon = new Pokemon.Pikachu();
            //    //        GameManager.Instance.PlayerPokemon(playerPokemon);

            //    //        break;
            //    //    }


            //    //}
            //}
            //ConsoleKeyInfo keyInfo2 = Console.ReadKey(true);
            //if (keyInfo2.Key == ConsoleKey.Enter)
            //{
            //    ClearConsoleBuffer();
            //}

            //GameScene();
        }



        public static void Input()
        {
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                Console.WriteLine($"You pressed: {keyInfo.Key}");

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    ClearConsoleBuffer();
                    break;
                }
            }
            GameManager.Instance.ChooseMainPokemon();
            //ChoosePokemon(); //포켓몬 선택

            ConsoleKeyInfo keyInfo2 = Console.ReadKey(true);
            if (keyInfo2.Key == ConsoleKey.Enter)
            {
                ClearConsoleBuffer();
            }

            GameScene();
        }
        public static void GameScene()
        {
            ConsoleColors.ResetColor();
            Console.WriteLine("------------------------------");

            CurrentStage();
            Console.WriteLine(RightNull + GameManager.Instance.enemyPokemon.name + ":  " + GameManager.Instance.enemyPokemon.CurrentHP + " / " + GameManager.Instance.enemyPokemon.MaxHP);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(GameManager.Instance.playerPokemon.name + ":  " + GameManager.Instance.playerPokemon.CurrentHP + " / " + GameManager.Instance.playerPokemon.MaxHP);
            Console.WriteLine("플레이어 포켓몬: " + GameManager.Instance.playerPokemon.name);


            Console.WriteLine("------------------------------");

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Escape) //선택창 //게임계속 스탯활성화 게임종료
                {
                    ClearConsoleBuffer();
                    EscapeUi();
                    break;
                }

                //if (keyInfo.Key == ConsoleKey.UpArrow) //선택창 //게임계속 스탯활성화 게임종료
                //{
                //    break;
                //}
            }

        }
        static void EscapeUi()
        {
            Console.WriteLine(GameManager.Instance.playerPokemon.name + "  " + GameManager.Instance.playerPokemon.Level);
            Console.WriteLine("경험치");
            Console.WriteLine("기술");
            Console.WriteLine("능력치");
            Console.WriteLine("돌아간다 (ESCAPE)");

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.D1) //선택창 //게임계속 스탯활성화 게임종료
                {
                    ClearConsoleBuffer();
                    ShowExperience();
                    
                }

                if (keyInfo.Key == ConsoleKey.D2) //선택창 //게임계속 스탯활성화 게임종료
                {
                    ClearConsoleBuffer();
                    ShowSkill();
                }

                if (keyInfo.Key == ConsoleKey.D3) //선택창 //게임계속 스탯활성화 게임종료
                {
                    ClearConsoleBuffer();
                    ShowState();
                }
                if (keyInfo.Key == ConsoleKey.Escape) //선택창 //게임계속 스탯활성화 게임종료
                {
                    break;
                }
            }
            ClearConsoleBuffer();
            GameScene();
        }


        static void ButtonUi()
        {
            while (true)
            {
                CusurOff();
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                Console.WriteLine($"You pressed: {keyInfo.Key}");
                //대충
                if (keyInfo.Key == ConsoleKey.Enter && x == 2 && y == 2)
                {
                    //Console.WriteLine("Exiting...");
                    //ClearConsoleBuffer();
                    break;
                }
            }
        }
        static void CurrentStage()
        {
            Console.WriteLine(RightNull + "현재 층: " + GameManager.Instance.CurrentMap);

        }

        public static void ClearConsoleBuffer()
        {
            // 콘솔 화면 전체 지우기
            Console.Clear();
        }

        static void CusurOff()
        {
            Console.CursorVisible = false; // 커서 숨기기 //커서 숨기고 이제 플레이어가 움직이는 곳에 체크 두기
        }

        //
        public static bool isRunning = true;
        public static void MoveGrass()
        {
            int width = Console.WindowWidth; // 콘솔 창 너비
            int position = 0;
            int direction = 1; // 1: 오른쪽, -1: 왼쪽

            while (isRunning)
            {
                // 기존 풀 지우기
                Console.SetCursorPosition(position, Console.CursorTop);
                Console.Write(" ");

                // 새로운 위치 계산
                position += direction;

                // 방향 전환
                if (position <= 0 || position >= width - 1)
                {
                    direction *= -1;
                }

                // 새로운 풀 그리기
                Console.SetCursorPosition(position, Console.CursorTop);
                Console.Write("|");

                // 딜레이
                Thread.Sleep(100); // 100ms 간격으로 움직임
            }
        }

        public static void ShowExperience() //경험치 - 현재 경험치, 다음 레벨까지
        {
            Console.WriteLine("현재 경험치: " + GameManager.Instance.playerPokemon.experience);
            Console.WriteLine("다음 경험치: " + GameManager.Instance.playerPokemon.nextExperience);
            Console.WriteLine("다음 경험치까지: " + (GameManager.Instance.playerPokemon.nextExperience - GameManager.Instance.playerPokemon.experience));
        }

        public static void ShowState() //능력치
        {
            Console.WriteLine(GameManager.Instance.playerPokemon.name + ":  " + GameManager.Instance.playerPokemon.CurrentHP + " / " + GameManager.Instance.playerPokemon.MaxHP);
            //Console.WriteLine("상태: " + status);
            Console.WriteLine();
            Console.WriteLine(GameManager.Instance.playerPokemon.name + "능력치");

            Console.WriteLine("Hp: " + GameManager.Instance.playerPokemon.MaxHP);
            Console.WriteLine("Attack: " + GameManager.Instance.playerPokemon.attack);
            Console.WriteLine("Defense: " + GameManager.Instance.playerPokemon.defense);
            Console.WriteLine("SpAttack: " + GameManager.Instance.playerPokemon.spAttack);
            Console.WriteLine("SpDefense: " + GameManager.Instance.playerPokemon.spDefense);
            Console.WriteLine("Speed: " + GameManager.Instance.playerPokemon.speed);
        }

        public static void ShowSkill()//보유 스킬
        {
            Console.WriteLine("스킬");

            foreach (var f in GameManager.Instance.playerPokemon.Skills)
            {
                if (f != null) Console.WriteLine(f);
            }
        }

    }

    //static bool isRunning = true;
    //static char[,] grassField;
    //static int fieldWidth = 50;
    //static int fieldHeight = 10;
    //static bool isLeaningLeft = true; // 풀의 방향 상태
    //static void InitializeGrassField()
    //{
    //    grassField = new char[fieldHeight, fieldWidth];
    //    Random rand = new Random();

    //    for (int y = 0; y < fieldHeight; y++)
    //    {
    //        for (int x = 0; x < fieldWidth; x++)
    //        {
    //            // 일정 확률로 풀 생성 (더 드문 간격)
    //            grassField[y, x] = rand.Next(0, 6) == 0 ? '/' : ' ';
    //        }
    //    }
    //}

    //static void AnimateGrass()
    //{
    //    while (isRunning)
    //    {
    //        UpdateGrassDirection();
    //        DrawGrassField();
    //        Thread.Sleep(500); // 3초 주기로 방향 변경
    //    }
    //}

    //static void UpdateGrassDirection()
    //{
    //    // 현재 방향에 따라 풀의 모양 변경
    //    char newDirection = isLeaningLeft ? '\\' : '/';
    //    isLeaningLeft = !isLeaningLeft; // 방향 토글

    //    for (int y = 0; y < fieldHeight; y++)
    //    {
    //        for (int x = 0; x < fieldWidth; x++)
    //        {
    //            if (grassField[y, x] != ' ')
    //            {
    //                grassField[y, x] = newDirection;
    //            }
    //        }
    //    }
    //}

    //static void DrawGrassField()
    //{
    //    for (int y = 0; y < fieldHeight; y++)
    //    {
    //        Console.SetCursorPosition(0, y);
    //        for (int x = 0; x < fieldWidth; x++)
    //        {
    //            Console.Write(grassField[y, x]);
    //        }
    //    }
    //}

    //static void Test()
    //{

    //    Console.CursorVisible = false; // 커서 숨기기
    //    InitializeGrassField();

    //    Thread grassThread = new Thread(AnimateGrass);
    //    grassThread.Start();

    //    Console.WriteLine("Press 'Q' to quit."); // 종료 메시지
    //    while (isRunning)
    //    {
    //        if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Q)
    //        {
    //            isRunning = false; // Q 키 입력 시 종료
    //        }
    //    }

    //    grassThread.Join(); // 스레드 종료 대기
    //}
}
