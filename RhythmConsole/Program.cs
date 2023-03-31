using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Media;

namespace test
{
    public class Program 
    {
        struct inform
        {
            public string song;
            public string singer;
            public int level;
            public int highscore;
        }
        static int Width = 60;
        static int Height = 50;
        static ConsoleKeyInfo input;
        static void Main(string[] args)
        {
            //Press Any Key 라는 타이틀
            Console.Title = "Rhythm Console";
            Console.SetWindowSize(Width, Height);
            Console.SetBufferSize(Width, Height);
            Console.CursorVisible = false;
            //Console.BackgroundColor = ConsoleColor.DarkMagenta;
            title();
            input = Console.ReadKey();
            Thread inputThread = new Thread(Input);
            inputThread.Start();
            //tutorial : asdf, hjkl로 play 가능
            inform[] informs = new inform[25];
            for (int i = 0; i < 25; i++)
            {
                informs[i].song = "             ";
                informs[i].singer = "           ";
                informs[i].level = 00;
                informs[i].highscore = 00000;
            }
            informs[5].song = " Ditto       ";
            informs[5].singer = "New Jeans  ";
            informs[5].level = 04;
            informs[5].highscore = 00000;
            informs[10].song = "To You       "   ;
            informs[10].singer = "TeenTop    ";
            informs[10].level = 02;
            informs[10].highscore = 00000;
            informs[15].song = "파이팅해야지 ";
            informs[15].singer = "부석순     ";
            informs[15].level = 06;
            informs[15].highscore = 00000;
            int[,] song = new int[3, 400];
            int[,] song8 = new int[3, 400];
            //song[choose]번째를 전달

            //배열로 저장된 리듬게임
            //첫번째 노래
            int[] ditto4 = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 4, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 4, 0, 0, 0, 3, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 2, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 4, 0, 0, 1, 0, 0, 0, 2, 0, 0, 0, 3, 0, 0, 0, 2, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 3, 0, 0, 0, 1, 0, 4, 0, 0, 0, 0, 0, 0};
            int[] ditto8 = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 8, 0, 0, 0, 7, 0, 0, 0, 0, 0, 0, 0, 6, 0, 0, 5, 0, 0, 0, 8, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 0, 0, 0, 8, 0, 0, 0, 5, 0, 0, 4, 0, 0, 0, 5, 0, 0, 0, 2, 0, 0, 0, 1, 0, 0, 0, 7, 0, 0, 0, 0, 0, 6, 0, 0, 0, 8, 0, 0, 0, 3, 0, 5, 0, 0, 0, 0, 0, 0};

            int[] toyou4 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0,  0,2, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 1};            
            int[] toyou8 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 7, 0, 0, 2, 0, 0, 0, 7, 0, 0, 3, 0, 0, 8, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 7, 0, 0, 0, 0, 0, 0, 8, 0, 0, 0, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 8, 0, 0, 3, 0, 0, 0, 2, 0, 0, 7, 0, 0, 0, 3, 0, 0, 0, 6, 0, 0, 5, 0, 0, 0, 1, 0, 0, 7, 0, 0, 0, 1, 0, 0, 4, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 4, 0, 0, 1, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0,  0,2, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 7, 0, 0, 0, 0, 0, 0, 8, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 4, 0, 0, 4, 0, 0, 0, 6, 0, 0, 1, 0, 0, 0, 2, 0, 0, 0, 8, 0, 0, 4, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 2, 0, 3, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 8, 0, 0, 0, 7, 0, 6, 0, 0, 0, 5, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 1, 0, 8, 0, 0, 0, 0, 0, 2, 0, 4, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 1};            
            
            int[] fighting4 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 3, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 2, 0, 0, 0, 0, 3, 0, 0, 0, 3, 0, 0, 0, 0, 1, 0, 0, 0, 0, 2, 0, 0, 0, 0, 3, 0, 0, 0, 3, 0, 0, 0 ,0, 1, 0, 0, 0, 0, 2, 0, 0, 0, 0, 3, 0, 0, 0, 0, 3, 0, 3, 0, 0, 4, 0, 0, 0, 3, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 2, 0, 2, 0, 2, 0, 3, 0, 0, 0, 0, 0,  4, 0, 4, 0, 1, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 4, 0, 4, 0, 3, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 2, 0, 3, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 4, 0, 0, 0, 0, 0, 0, 0, 2, 0, 2, 0, 0, 0, 0, 0, 0, 3, 0, 3, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 4, 0, 3, 0, 2, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 2, 0, 0, 0, 0, 4, 0, 3, 0, 2, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 3, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 2, 0, 0, 0, 0, 0, 0, 4, 0, 4, 0, 0, 0, 0, 0, 0,0 ,0 ,0, 0, 0, 0, 0, 0, 0,1, 3, 0, 0, 0, 0, 0, 0, 0, 4, 0, 2, 0, 0, 1};
            int[] fighting8 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 5, 0, 0, 0, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 0, 0, 0, 0, 7, 0, 0, 0, 0, 8, 0, 0, 0, 2, 0, 0, 0, 0, 6, 0, 0, 0, 0, 3, 0, 0, 0, 0, 1, 0, 0, 0, 6, 0, 0, 0 ,0, 7, 0, 0, 0, 0, 2, 0, 0, 0, 0, 7, 0, 0, 0, 0, 5, 0, 3, 0, 0, 8, 0, 0, 0, 3, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 0, 2, 0, 5, 0, 1, 0, 7, 0, 0, 0, 0, 0,  8, 0, 3, 0, 7, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 0, 4, 0, 2, 0, 8, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 2, 0, 3, 0, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 8, 0, 0, 0, 0, 0, 0, 0, 6, 0, 1, 0, 0, 0, 0, 0, 0, 3, 0, 5, 0, 0, 0, 0, 0, 0, 1, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 1, 0, 8, 0, 2, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 7, 0, 0, 0, 0, 1, 0, 8, 0, 2, 0, 0, 0, 4, 0, 0, 0, 0, 1, 0, 7, 0, 0, 0, 0, 0, 0, 3, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 7, 0, 0, 0, 0, 0, 0, 4, 0, 2, 0, 0, 0, 0, 0, 0,0 ,0 ,0, 0, 0, 0, 0, 0, 0,5, 3, 0, 0, 0, 0, 0, 0, 0, 4, 0, 1, 0, 0, 1};


            //노래 이차원 배열에 옮기기
            for (int i = 0; i < ditto4.Length; i++)
            {
                song[0, i] = ditto4[i];
            }
            for (int i = 0; i < toyou4.Length; i++)
            {
                song[1, i] = toyou4[i];
            }
            for (int i = 0; i < fighting4.Length; i++)
            {
                song[2, i] = fighting4[i];
            }

            for (int i = 0; i < ditto8.Length; i++)
            {
                song8[0, i] = ditto8[i];
            }
            for (int i = 0; i < toyou8.Length; i++)
            {
                song8[1, i] = toyou8[i];
            }
            for (int i = 0; i < fighting8.Length; i++)
            {
                song8[2, i] = fighting8[i];
            }
            int keyindex = 0;
            while (true)
            {
                int choose = list(informs, ref keyindex); //노래 배열에서 choose번째꺼 고름
                int combo = 0;
                int score = 0;
                int hp = 100;
                if (keyindex == 0) //4key를 선택했을 때
                {
                    hp = print_game(song, choose, ref combo, ref score);
                    loading();
                }
                else if (keyindex == 1)//8key를 선택했을 때
                {
                    hp = print_game8key(song8, choose, ref combo, ref score);
                    loading();
                }
                else if (keyindex == 2) //esc고르면{
                {
                    continue;
                }
                if (score > informs[(choose + 1) * 5].highscore)
                {
                    informs[(choose + 1) * 5].highscore = score;
                }
            }
        }
        static int print_game(int[,] test, int choose, ref int combo, ref int score)
        {
            int hp = 100;
            bool IsAlive = true;
            // 정지 여부
            WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();
            // 스레드 시작
            ThreadPool.QueueUserWorkItem(_ =>
            {
                // mp3 파일
                if (choose == 0)
                {
                    player.URL = "Ditto.mp3";
                    player.controls.stop();
                }
                else if (choose == 1)
                {
                    player.URL = "ToYou.mp3";
                    player.controls.stop();
                }
                else if (choose == 2)
                {
                    player.URL = "파이팅해야지.mp3";
                    player.controls.stop();
                }
                // 무한 루프 시작
                player.controls.play();
                while (true)
                {
                    // 스레드 종료 여부
                    if (IsAlive)
                    {
                    }
                    else
                    {
                        // 정지한다.
                        player.controls.stop();
                        break;
                    }
                }
            });
            #region
            //// 커맨더 무한 루프
            //while (true)
            //{
            //    // 사용자로 부터 입력 받는다.
            //    var cmd = Console.ReadKey();
            //    switch (cmd.Key)
            //    {
            //        // P키를 누르면
            //        case ConsoleKey.P:
            //            // 정지 플래그 해제
            //            IsPause = false;
            //            // 음악 플레이!
            //            player.controls.play();
            //            continue;
            //        // S키를 누르면
            //        case ConsoleKey.S:
            //            // 스레드 종료
            //            IsAlive = false;
            //            // 음악 종료
            //            player.controls.stop();
            //            break;
            //        // A키를 누르면
            //        case ConsoleKey.A:
            //            // 정지 플래그 설정
            //            IsPause = true;
            //            // 일시 정지
            //            player.controls.pause();
            //            // 명령어 삭제
            //            Console.WriteLine("\r  ");
            //            continue;
            //        // 기타키?
            //        default:
            //            continue;
            //    }
            //    break;
            //}
            //// 콘솔 출력
            //Console.WriteLine("\rPress any key...");
            //Console.ReadKey();
            //press any key to start
            #endregion
            for (int i = 0; i < test.GetLength(1) - 30; i++)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("\n ┌───────────────────────────────────────────────────────┐");
                Console.WriteLine(" │                                                       │");

                int j;
                for (j = 29 + i; j > 0 + i; j--)
                {
                    switch (test[choose, j])
                    {
                        case 0:
                            Console.WriteLine(" │                                                       │");
                            break;
                        case 1:
                            Console.Write(" │  ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(" ━━━━━━━   ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("                                          │");
                            break;
                        case 2:
                            Console.Write(" │             ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("   ━━━━━━━     ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("                           │");
                            break;
                        case 3:
                            Console.Write(" │                            ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("    ━━━━━━━  ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("              │");
                            break;
                        case 4:
                            Console.Write(" │                                          ");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("   ━━━━━━━ ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("  │");
                            break;
                    }
                }
                if (test[choose, j] == 1)
                {
                    Console.Write(" │ ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("--━━━━━━━--------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" │");
                }
                else if (test[choose, j] == 2)
                {
                    Console.Write(" │ ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("---------------━━━━━━━-------------------------------");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" │");
                }
                else if (test[choose, j] == 3)
                {
                    Console.Write(" │ ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("-------------------------------━━━━━━━---------------");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" │");
                }
                else if (test[choose, j] == 4)
                {
                    Console.Write(" │ ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("--------------------------------------------━━━━━━━--");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" │");
                }
                else if (test[choose, j] == 0)
                {
                    Console.Write(" │ ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("-----------------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" │");
                }
                int firstCombo = combo;
                InputHandler(i, test, choose, ref combo, ref hp, ref score);
                int lastCombo = combo;
                Console.Write(" │       ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("A  ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("         S  ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("              D");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("           F   ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("   │");
                if (firstCombo == lastCombo && test[choose, i] != 0) //노트가있는데 안친경우 
                {
                    combo = 0;
                    hp -= 5;
                    if (hp < 0)
                    {
                        hp = 0;
                    }
                }
                
                Console.WriteLine(" ├───────────────────────────────────────────────────────┤");
                Console.WriteLine(" │                                                       │");
                if (hp == 100)
                {
                    Console.WriteLine(" │      HP :   ■■■■■■■■■■  {0, 3}                 │", hp);
                }
                else if (hp >= 90)
                {
                    Console.WriteLine(" │      HP :   ■■■■■■■■■□  {0, 3}                 │", hp);
                }
                else if (hp >= 80)
                {
                    Console.WriteLine(" │      HP :   ■■■■■■■■□□  {0, 3}                 │", hp);
                }
                else if (hp >= 70)
                {
                    Console.WriteLine(" │      HP :   ■■■■■■■□□□  {0, 3}                 │", hp);
                }
                else if (hp >= 60)
                {
                    Console.WriteLine(" │      HP :   ■■■■■■□□□□  {0, 3}                 │", hp);
                }
                else if (hp >= 50)
                {
                    Console.WriteLine(" │      HP :   ■■■■■□□□□□  {0, 3}                 │", hp);
                }
                else if (hp >= 40)
                {
                    Console.Write(" │      HP :   ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("■■■■□□□□□□  {0, 3}", hp);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("                 │");
                }
                else if (hp >= 30)
                {
                    Console.Write(" │      HP :   ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("■■■□□□□□□□  {0, 3}", hp);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("                 │");
                }
                else if (hp >= 20)
                {
                    Console.Write(" │      HP :   ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("■■□□□□□□□□  {0, 3}", hp);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("                 │");
                }
                else if (hp >= 10)
                {
                    Console.Write(" │      HP :   ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("■□□□□□□□□□  {0, 3}", hp);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("                 │");
                }
                else
                {
                    Console.Write(" │      HP :   ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("□□□□□□□□□□  {0, 3}", hp);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("                 │");
                }
                Console.WriteLine(" │                                                       │");
                Console.WriteLine(" │                                                       │");
                Console.WriteLine(" │      COMBO:       {0, 5}                               │", combo);
                Console.WriteLine(" │                                                       │");
                Console.WriteLine(" │      SCORE:       {0, 5}                               │", score);
                Console.WriteLine(" │                                                       │");
                Console.WriteLine($" │      CURRENT:      {player.controls.currentPositionString} / {player.currentMedia.durationString}                      │");
                //Console.WriteLine(" │                                                       │");
                Console.WriteLine(" │                                                       │");
                Console.WriteLine(" │                                                       │");
                Console.WriteLine(" └───────────────────────────────────────────────────────┘");
                if (hp <= 0)
                {
                    hp = 0;
                    break;
                }
                input = new ConsoleKeyInfo(); //reset
                Thread.Sleep(69);
            }
            IsAlive = false; //노래 끄기
            return hp;
        }
        static void gameover(int hp, int score)
        {
            Console.Clear();
            if (hp <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                for (int i =0; i < 2; i++)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine();
                    Console.WriteLine();                      
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("    /$$           /$$$$$$$$$$     $$$$$$$     /$$$$$$$$$$");
                    Console.WriteLine("   / $$          / $$     /$$   /$$$   $$    / $$       /");
                    Console.WriteLine("  │  $$         │  $$ ￣￣ $$  │$$$   /     │  $$ ￣￣￣ ");
                    Console.WriteLine("  │  $$         │  $$      $$  │  $$$$      │  $$");
                    Console.WriteLine("  │  $$         │  $$      $$   ＼   $$$$   │  $$$$$$$$$$");
                    Console.WriteLine("  │  $$         │  $$      $$     ＼   $$$$ │  $$       / ");
                    Console.WriteLine("  │  $$         │  $$      $$       ＼   $$ │  $$ ￣￣￣");
                    Console.WriteLine("  │  $$         │  $$      $$    $   │   $$ │  $$");
                    Console.WriteLine("  │  $$         │  $$      $$   /$$$ /  $$$ │  $$");
                    Console.WriteLine("  │  $$$$$$$$$$ │  $$$$$$$$$$  │  $$$$$$$│  │  $$$$$$$$$$");
                    Console.WriteLine("  │ /        /  │ /        /   │ /       /  │ /         /  ");
                    Console.WriteLine("   ￣￣￣￣￣    ￣￣￣￣￣      ￣￣￣￣     ￣￣￣￣￣   ");
                    Console.WriteLine();
                    Console.WriteLine();
                    Thread.Sleep(500);

                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();//♪♩
                    Console.WriteLine("    /♬           /♬♬♬♬♬      ♬♬♬     /♬♬♬♬♬");
                    Console.WriteLine("   / ♬          / ♬     /♬   /♬    ♬    / ♬       /");
                    Console.WriteLine("  │  ♬         │  ♬ ￣￣ ♬  │♬    /     │  ♬ ￣￣￣    ");
                    Console.WriteLine("  │  ♬         │  ♬      ♬  │ ♬♬       │  ♬");
                    Console.WriteLine("  │  ♬         │  ♬      ♬   ＼   ♬♬   │  ♬♬♬♬♬");
                    Console.WriteLine("  │  ♬         │  ♬      ♬     ＼   ♬♬ │  ♬       / ");
                    Console.WriteLine("  │  ♬         │  ♬      ♬       ＼   ♬ │  ♬ ￣￣￣");
                    Console.WriteLine("  │  ♬         │  ♬      ♬        │   ♬ │  ♬");
                    Console.WriteLine("  │  ♬         │  ♬      ♬   /♬  /  ♬  │  ♬");
                    Console.WriteLine("  │  ♬♬♬♬♬ │  ♬♬♬♬♬  │  ♬♬♬ │  │  ♬♬♬♬♬");
                    Console.WriteLine("  │ /        /  │ /        /   │ /       /  │ /         /  ");
                    Console.WriteLine("   ￣￣￣￣￣    ￣￣￣￣￣      ￣￣￣￣     ￣￣￣￣￣       ");
                    Console.WriteLine();
                    Console.WriteLine();
                    Thread.Sleep(500);
                }
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("     ┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
                Console.WriteLine("     ┃                                               ┃");
                Console.WriteLine("     ┃                GAME       CLEAR               ┃");
                Console.WriteLine("     ┃                                               ┃");
                Console.WriteLine("     ┃               Score:       {0:D3}                ┃", score);
                Console.WriteLine("     ┃                                               ┃");
                Console.WriteLine("     ┃                                               ┃");
                Console.WriteLine("     ┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
                Thread.Sleep(2000);
                switch (input.Key)
                {
                    case ConsoleKey.Enter:
                        Console.ReadLine();
                        break;
                }
            }
            loading();
        }
        static void loading()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < 50; i++)
            {
                Thread.Sleep(30);
                Console.WriteLine("                                                           ");
            }
        }
        static void title()
        {
            WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();
            // 스레드 시작
            ThreadPool.QueueUserWorkItem(_ =>
            {
                    player.URL = "bgm.mp3";
                    player.controls.stop();
                bool notstop = true;
                // 무한 루프 시작
                player.controls.play();
                while (true)
                {
                    // 스레드 종료 여부
                    if (notstop)
                    {
                    }
                    else
                    {
                        // 정지한다.
                        player.controls.stop();
                        break;
                    }
                }
            });
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    break;
                }
                #region
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("                                                           ");
                Console.WriteLine("                                                           ");
                Console.WriteLine("                                                           ");
                Console.WriteLine("                                       ♪                  ");
                Console.WriteLine("                                                           "); //5
                Console.WriteLine("                         ··········              ");
                Console.WriteLine("        ♩               ·●··●●●●●·              ");
                Console.WriteLine("         ·········●··●·····              ");
                Console.WriteLine("         ·●●●●●●··●··●······            ");
                Console.WriteLine("         ······●··●··●●●●●●·            "); //10
                Console.WriteLine("           ·····●··●···········      ♩");
                Console.WriteLine("           ·●●●●●··●·●●●●●●●●●·        ");
                Console.WriteLine("           ·●······●···········        ");
                Console.WriteLine("           ·●·        ·●··●●●●●·              ");
                Console.WriteLine("    ♬     ·●······●··●···●·              ");//15
                Console.WriteLine("           ·●●●●●··●··●···●·    ♪        ");
                Console.WriteLine("           ········●··●●●●●·              ");
                Console.WriteLine("                         ··········              ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("           ·········        ·   ♪               ");
                Console.WriteLine("           ·●●●●●●●·      ·●·                  ");//20
                Console.WriteLine("    ♩     ·······●·    ·●·●·                ");
                Console.WriteLine("             ·●●●●●●·  ·●···●·              ");
                Console.WriteLine("             ···●··●··●··●··●·       ♩   ");
                Console.WriteLine("       ······●········●·····          ");
                Console.WriteLine("       ·●●●●●●●●●··●●●●●●●●·          ");//25
                Console.WriteLine("       ·····················          ");
                Console.WriteLine("             ·●·              ·●●●●●·            ");
                Console.WriteLine(" ♪          ·●·······  ·····●·            ");
                Console.WriteLine("             ·●●●●●●●·  ·●●●●●·            ");
                Console.WriteLine("             ·········  ·●·······        ");//30
                Console.WriteLine("                                 ·●●●●●●●·        ");
                Console.WriteLine("           ♩                    ·········        ");
                Console.WriteLine("                                                           ");
                Console.WriteLine("                                             ♬            ");
                Console.WriteLine("                                                           ");//35
                Console.WriteLine("                                                           ");
                Console.WriteLine("                                                           ");
                Console.WriteLine("                                                           ");
                Console.WriteLine("                                                           ");
                Console.WriteLine("                                                           ");//40
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(@"
       ┏━━━┓                                   ┏━━━┓
       ┃ ┏━┛  ┏━━━━━┳━━━━━┳━━━━━┳━━━━━┳━━━━━┓  ┗━┓ ┃
       ┃ ┃    ┃   __┣━┓ ┏━┫  _  ┃ __  ┣━┓ ┏━┛    ┃ ┃
       ┃ ┃    ┃__   ┃ ┃ ┃ ┃     ┃    -┃ ┃ ┃      ┃ ┃
       ┃ ┗━┓  ┗━━━━━┛ ┗━┛ ┗━━┻━━┻━━┻━━┛ ┗━┛    ┏━┛ ┃
       ┗━━━┛                                   ┗━━━┛");
                Console.WriteLine("                                                         ");//50
                Console.WriteLine("                                                         ");
                Thread.Sleep(500);

                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("                                                           ");
                Console.WriteLine("                                                           ");
                Console.WriteLine("                                                           ");
                Console.WriteLine("     ♬                                                    ");
                Console.WriteLine("                         ···                            "); //5
                Console.WriteLine("                         ·●·  ·······            ");
                Console.WriteLine("         ·········●·  ·●●●●●·            ");
                Console.WriteLine("         ·●●●●●●··●·  ·●·····            ");
                Console.WriteLine("         ······●··●·  ·●······      ♩  ");
                Console.WriteLine("  ♪       ·····●··●·  ·●●●●●●·          "); //10
                Console.WriteLine("           ·●●●●●··●············      ");
                Console.WriteLine("           ·●······●··●●●●●●●●●·      ");
                Console.WriteLine("           ·●·        ·●············      ");
                Console.WriteLine("     ♬    ·●······●·  ·●●●●●·            ");
                Console.WriteLine("           ·●●●●●··●·  ·●···●·            ");//15
                Console.WriteLine("           ········●·  ·●···●·            ");
                Console.WriteLine("                         ···  ·●●●●●·            ");
                Console.WriteLine("                                 ·······          ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("                                       ·         ♪       ");
                Console.WriteLine("           ·········        ·●·                ");//20
                Console.WriteLine("           ·●●●●●●●·      ·●·●·              ");
                Console.WriteLine("           ·······●·    ·●···●·     ♬     ");
                Console.WriteLine("     ♩      ·●●●●●●·  ·●··●··●·          ");
                Console.WriteLine("             ···●··●·  ····●·····        ");
                Console.WriteLine("       ······●····  ·●●●●●●●●·        ");//25
                Console.WriteLine("       ·●●●●●●●●●·  ··········   ♩   ");
                Console.WriteLine("       ···········      ·●●●●●·        ");
                Console.WriteLine("             ·●·                ·····●·        ");
                Console.WriteLine("             ·●·······    ·●●●●●·        ");
                Console.WriteLine("             ·●●●●●●●·    ·●·······    ");//30
                Console.WriteLine("             ·········    ·●●●●●●●·    ");
                Console.WriteLine("        ♬                         ·········    ");
                Console.WriteLine("                                              ");
                Console.WriteLine("                            ♩                  ");
                Console.WriteLine("                                                ");//35
                Console.WriteLine("                                              ");
                Console.WriteLine("                                              ");
                Console.WriteLine("                                              ");
                Console.WriteLine("                                              ");
                Console.WriteLine("                                              ");//40
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(@"
       ┏━━━┓                                   ┏━━━┓
       ┃ ┏━┛  ┏━━━━━┳━━━━━┳━━━━━┳━━━━━┳━━━━━┓  ┗━┓ ┃
       ┃ ┃    ┃   __┣━┓ ┏━┫  _  ┃ __  ┣━┓ ┏━┛    ┃ ┃
       ┃ ┃    ┃__   ┃ ┃ ┃ ┃     ┃    -┃ ┃ ┃      ┃ ┃
       ┃ ┗━┓  ┗━━━━━┛ ┗━┛ ┗━━┻━━┻━━┻━━┛ ┗━┛    ┏━┛ ┃
       ┗━━━┛                                   ┗━━━┛");
                Console.WriteLine("                                                           ");//50
                Console.WriteLine("                                                           ");
                Thread.Sleep(500);
                #endregion
            }
            loading();
            player.controls.stop();
        }
        static int list(inform[] informs, ref int keyindex)
        {
            WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();
            bool stop = false;
            ThreadPool.QueueUserWorkItem(_ =>
            {
                player.URL = "Ditto.mp3"; 
                // 무한 루프 시작
                while (true)
                {
                    // 스레드 종료 여부
                    if (!stop)
                    {
                        //Console.WriteLine("노래나오는중");
                    }
                    else
                    {
                        // 정지한다.
                        player.controls.stop();
                        break;
                    }
                }
            });
            bool isStart = false;
            int index = 0;
            int result = 0;
            //while (Console.KeyAvailable) { Console.ReadKey(true); }
            string[] music = { "                              ", "                              ", "                              ", "                              ", "                              ", "겨울풍 노래", "                              ", "                              ", "                              ", "                              ", "신나는 잔잔", "                              ", "                              ", "                              ", "                              ", "파이팅 노래", "                              ", "                              ", "                              ", "                              ", "                              " };
            while (!isStart)
            {
                list_print(music, index, informs);
                isStart = list_InputHandler(music, ref index, informs, ref player);
                input = new ConsoleKeyInfo();
                result = list_print(music, index, informs);
            }
            //4key 8key exit 고르는 창
            keyindex = choose_key(); //0이나 1로 결정 -> 4key나 8key
            player.controls.stop();
            loading();
            return result;
        }
        static int list_print(string[] music, int i, inform[] informs)
        {
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n              {0, 25}   (((((", music[i]);
            Console.WriteLine("            {0, 25}   (((::((", music[0]);
            Console.WriteLine("         {0, 25}   (((:::::((", music[i + 1]);
            Console.WriteLine("       {0, 25}   (((:::::::((", music[0]);
            Console.WriteLine("      {0, 25}   (((::::::::((", music[i + 2]);
            Console.WriteLine("    {0, 25}   (((::::::::::((", music[0]);
            Console.WriteLine("   {0, 25}   ((::::::::::::((", music[i + 3]);
            Console.WriteLine("  {0, 25}   ((:::::::::::::((", music[0]);
            Console.WriteLine(" {0, 25}   ((::::::::::::::((", music[i + 4]);
            Console.WriteLine("{0, 25}   ((:::::::::::::::((", music[0]);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0, 25}", music[i + 5]);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("   (( ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("◀────────────((");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("{0, 25}   ((:::::::::::::::((", music[0]);
            Console.WriteLine(" {0, 25}   ((::::::::::::::((", music[i + 6]);
            Console.WriteLine("  {0, 25}   ((:::::::::::::((", music[0]);
            Console.WriteLine("   {0, 25}   ((::::::::::::((", music[i + 7]);
            Console.WriteLine("    {0, 25}   (((::::::::::((", music[0]);
            Console.WriteLine("      {0, 25}   (((::::::::((", music[i + 8]);
            Console.WriteLine("       {0, 25}   (((:::::::((", music[0]);
            Console.WriteLine("         {0, 25}   (((:::::((", music[i + 9]);
            Console.WriteLine("            {0, 25}   (((::((", music[0]);
            Console.WriteLine("              {0, 25}   (((((\n", music[i + 10]);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("           _______ _______ _______ __   __ _______");
            Console.WriteLine("          |   _   |  _    |       |  | |  |       |");
            Console.WriteLine("          |  |_|  | |_|   |   _   |  | |  |_     _|");
            Console.WriteLine("          |       |       |  | |  |  |_|  | |   |  ");
            Console.WriteLine("          |       |  _   ||  |_|  |       | |   | ");
            Console.WriteLine("          |   _   | |_|   |       |       | |   |");
            Console.WriteLine("          |__| |__|_______|_______|_______| |___| ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("");
            Console.WriteLine("             ┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
            Console.WriteLine("             ┃                              ┃");
            Console.WriteLine("             ┃     SONG      : {0, 3}┃", informs[i + 5].song);
            Console.WriteLine("             ┃                              ┃");
            Console.WriteLine("             ┃     SINGER    : {0, 3}  ┃", informs[i + 5].singer);
            Console.WriteLine("             ┃                              ┃");
            Console.WriteLine("             ┃     Level     : {0:D3}          ┃", informs[i + 5].level);
            Console.WriteLine("             ┃                              ┃");
            Console.WriteLine("             ┃     High Score: {0:D4}         ┃", informs[i + 5].highscore);
            Console.WriteLine("             ┃                              ┃");
            Console.WriteLine("             ┃       W / S     ↑ / ↓      ┃");
            Console.WriteLine("             ┃                              ┃");
            Console.WriteLine("             ┃     PRESS D / → TO START    ┃");
            Console.WriteLine("             ┃                              ┃");
            Console.WriteLine("             ┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
            Console.ForegroundColor = ConsoleColor.White;
            return i / 5; //i번째꺼 선택함
        }
        static bool list_InputHandler(string[] music, ref int index, inform[] informs,ref WMPLib.WindowsMediaPlayer player)
        {
            switch (input.Key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    if (index != 0)
                    {
                        player.controls.stop();
                        Thread.Sleep(100);
                        list_print(music, index - 1, informs);
                        Thread.Sleep(160);
                        list_print(music, index - 2, informs);
                        Thread.Sleep(250);
                        list_print(music, index - 3, informs);
                        Thread.Sleep(380);
                        list_print(music, index - 4, informs);
                        index -= 5;
                        Thread.Sleep(500);
                        if (index / 5 == 0)
                        {
                            player.URL = "Ditto.mp3";
                        }
                        else if (index / 5 == 1)
                        {
                            player.URL = "ToYou.mp3";
                        }
                        player.controls.play();
                    }
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    if (index < music.Length - 11)
                    {
                        player.controls.stop();
                        Thread.Sleep(100);
                        list_print(music, index + 1, informs);
                        Thread.Sleep(160);
                        list_print(music, index + 2, informs);
                        Thread.Sleep(250);
                        list_print(music, index + 3, informs);
                        Thread.Sleep(380);
                        list_print(music, index + 4, informs);
                        index += 5;
                        Thread.Sleep(500);
                        if (index / 5 == 1)
                        {
                            player.URL = "ToYou.mp3";
                        }
                        else if (index / 5 == 2)
                        {
                            player.URL = "파이팅해야지.mp3";
                        }
                        player.controls.play();
                    }
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    {
                        return true;
                    }
            }
            return false;
        }
        static void Input()
        {
            while (true)
            {
                input = Console.ReadKey(true);
            }
        }
        static void InputHandler(int i, int[,] test, int choose, ref int combo, ref int hp, ref int score)
        {
            switch (input.Key)
            {
                case ConsoleKey.A:
                    //Console.WriteLine("■□□□");
                    Console.Write(" │  ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" ━━━━━━━━");
                    Console.ResetColor();
                    Console.WriteLine("     ───────         ───────      ───────  │");
                    if (test[choose, i] == 1)
                    {
                        combo++;
                        hp += 3;
                        score += 100;
                        if (hp >= 100)
                        {
                            hp = 100;
                        }
                    }
                    else if (test[choose, i] == 0)
                    {
                        //Console.WriteLine("없는데 그냥 한번 쳐봄");
                    }
                    else if (test[choose, i] == 2 || test[choose, i] == 3 || test[choose, i] == 4)
                    {
                        combo = 0;
                        hp -= 3;
                        score += 100;
                        if (hp < 0)
                        {
                            hp = 0;
                        }
                        //Console.WriteLine("있는데 다른 노트 침  ");
                    }
                    break;
                case ConsoleKey.S:
                    //Console.WriteLine("□■□□");
                    Console.Write(" │   ───────     ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(" ━━━━━━━━");
                    Console.ResetColor();
                    Console.WriteLine("        ───────      ───────  │");
                    if (test[choose, i] == 2)
                    {
                        combo++;
                        hp += 3;
                        score += 100;
                        if (hp >= 100)
                        {
                            hp = 100;
                        }
                    }
                    else if (test[choose, i] == 0)
                    {
                        //Console.WriteLine("없는데 그냥 한번 쳐봄");
                    }
                    else if (test[choose, i] == 1 || test[choose, i] == 3 || test[choose, i] == 4)
                    {
                        hp -= 3;
                        combo = 0;
                        if (hp < 0)
                        {
                            hp = 0;
                        }
                        //Console.WriteLine("있는데 다른 노트 침  ");
                    }
                    break;
                case ConsoleKey.D:
                    //Console.WriteLine("□□■□");
                    Console.Write(" │   ───────      ───────        ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(" ━━━━━━━━");
                    Console.ResetColor();
                    Console.WriteLine("     ───────  │");
                    if (test[choose, i] == 3)
                    {
                        combo++;
                        hp += 3;
                        score += 100;
                        if (hp >= 100)
                        {
                            hp = 100;
                        }
                    }
                    else if (test[choose, i] == 0)
                    {
                        //Console.WriteLine("없는데 그냥 한번 쳐봄");
                    }
                    else if (test[choose, i] == 1 || test[choose, i] == 2 || test[choose, i] == 4)
                    {
                        hp -= 3;
                        combo = 0;
                        if (hp < 0)
                        {
                            hp = 0;
                        }
                        //Console.WriteLine("있는데 다른 노트 침  ");
                    }
                    break;
                case ConsoleKey.F:
                    //Console.WriteLine("□□□■");
                    Console.Write(" │   ───────      ───────         ───────     ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(" ━━━━━━━━");
                    Console.ResetColor();
                    Console.WriteLine(" │");
                    if (test[choose, i] == 4)
                    {
                        combo++;
                        hp += 3;
                        score += 100;
                        if (hp >= 100)
                        {
                            hp = 100;
                        }
                    }
                    else if (test[choose, i] == 0)
                    {
                        //Console.WriteLine("없는데 그냥 한번 쳐봄");
                    }
                    else if (test[choose, i] == 1 || test[choose, i] == 2 || test[choose, i] == 3)
                    {
                        hp -= 3;
                        combo = 0;
                        if (hp < 0)
                        {
                            hp = 0;
                        }
                        //Console.WriteLine("있는데 다른 노트 침  ");
                    }
                    break;
                default:
                    Console.WriteLine(" │   ───────      ───────         ───────      ───────   │");
                    break;
            }
        }
        static int print_game8key(int[,] test, int choose, ref int combo, ref int score)
        {
            int hp = 100;
            bool IsAlive = true;
            // 정지 여부
            WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();
            // 스레드 시작
            ThreadPool.QueueUserWorkItem(_ =>
            {
                // mp3 파일
                if (choose == 0)
                {
                    player.URL = "Ditto.mp3";
                    player.controls.stop();
                }
                else if (choose == 1)
                {
                    player.URL = "ToYou.mp3";
                    player.controls.stop();
                }
                else if (choose == 2)
                {
                    player.URL = "파이팅해야지.mp3";
                    player.controls.stop();
                }
                // 무한 루프 시작
                player.controls.play();
                while (true)
                {
                    // 스레드 종료 여부
                    if (!IsAlive)
                    {
                        player.controls.stop();
                        break;
                    }
                }
            });
            for (int i = 0; i < test.GetLength(1) - 30; i++)
            {
                Console.SetCursorPosition(0, 0);
                Console.CursorVisible = false;
                Console.WriteLine("\n ┌───────────────────────────────────────────────────────┐");
                Console.WriteLine(" │                                                       │");

                Thread.Sleep(70);
                int j;
                for (j = 29 + i; j > 0 + i; j--)
                {
                    switch (test[choose, j])
                    {
                        case 0:
                            Console.WriteLine(" │                                                       │");
                            break;
                        case 1:
                            Console.Write(" │ ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("━━━━");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("                                                  │");
                            break;
                        case 2:
                            Console.Write(" │        ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("━━━━");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("                                           │");
                            break;
                        case 3:
                            Console.Write(" │               ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("━━━━");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("                                    │");
                            break;
                        case 4:
                            Console.Write(" │                      ");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("━━━━");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("                             │");
                            break;
                        case 5:
                            Console.Write(" │                             ");
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write("━━━━");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("                      │");
                            break;
                        case 6:
                            Console.Write(" │                                    ");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("━━━━");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("               │");
                            break;
                        case 7:
                            Console.Write(" │                                           ");
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write("━━━━");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("        │");
                            break;
                        case 8:
                            Console.Write(" │                                                  ");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("━━━━");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(" │");
                            break;
                    }
                }
                if (test[choose, j] == 1)
                {
                    Console.Write(" │ ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("━━━━--------------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("│");
                }
                else if (test[choose, j] == 2)
                {
                    Console.Write(" │ ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("-------━━━━-------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("│");
                }
                else if (test[choose, j] == 3)
                {
                    Console.Write(" │ ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("--------------━━━━------------------------------------");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("│");
                }
                else if (test[choose, j] == 4)
                {
                    Console.Write(" │ ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("---------------------━━━━-----------------------------");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("│");
                }
                else if (test[choose, j] == 5)
                {
                    Console.Write(" │ ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("----------------------------━━━━----------------------");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("│");
                }
                else if (test[choose, j] == 6)
                {
                    Console.Write(" │ ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("-----------------------------------━━━━---------------");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("│");
                }
                else if (test[choose, j] == 7)
                {
                    Console.Write(" │ ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("------------------------------------------━━━━--------");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("│");
                }
                else if (test[choose, j] == 8)
                {
                    Console.Write(" │ ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("-------------------------------------------------━━━━-");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("│");
                }
                else if (test[choose, j] == 0)
                {
                    Console.Write(" │ ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("------------------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("│");
                }
                Console.ForegroundColor = ConsoleColor.White;
                int firstCombo = combo;
                InputHandler_8key(i, test, choose, ref combo, ref hp, ref score);
                Console.Write(" │  ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" A");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("     S ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("     D   ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("   F    ");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("   H   ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("   J  ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("    K ");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("     L ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" │");
                int lastCombo = combo;
                if (firstCombo == lastCombo && test[choose, i] != 0) //노트가있는데 안친경우 
                {
                    combo = 0;
                    hp -= 5;
                    if (hp < 0)
                    {
                        hp = 0;
                    }
                }

                Console.WriteLine(" ├───────────────────────────────────────────────────────┤");
                Console.WriteLine(" │                                                       │");
                if (hp == 100)
                {
                    Console.WriteLine(" │      HP :   ■■■■■■■■■■  {0, 3}                 │", hp);
                }
                else if (hp >= 90)
                {
                    Console.WriteLine(" │      HP :   ■■■■■■■■■□  {0, 3}                 │", hp);
                }
                else if (hp >= 80)
                {
                    Console.WriteLine(" │      HP :   ■■■■■■■■□□  {0, 3}                 │", hp);
                }
                else if (hp >= 70)
                {
                    Console.WriteLine(" │      HP :   ■■■■■■■□□□  {0, 3}                 │", hp);
                }
                else if (hp >= 60)
                {
                    Console.WriteLine(" │      HP :   ■■■■■■□□□□  {0, 3}                 │", hp);
                }
                else if (hp >= 50)
                {
                    Console.WriteLine(" │      HP :   ■■■■■□□□□□  {0, 3}                 │", hp);
                }
                else if (hp >= 40)
                {
                    Console.Write(" │      HP :   ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("■■■■□□□□□□  {0, 3}", hp);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("                 │");
                }
                else if (hp >= 30)
                {
                    Console.Write(" │      HP :   ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("■■■□□□□□□□  {0, 3}", hp);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("                 │");
                }
                else if (hp >= 20)
                {
                    Console.Write(" │      HP :   ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("■■□□□□□□□□  {0, 3}", hp);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("                 │");
                }
                else if (hp >= 10)
                {
                    Console.Write(" │      HP :   ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("■□□□□□□□□□  {0, 3}", hp);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("                 │");
                }
                else
                {
                    Console.Write(" │      HP :   ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("□□□□□□□□□□  {0, 3}", hp);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("                 │");
                }
                Console.WriteLine(" │                                                       │");
                Console.WriteLine(" │    COMBO:       {0, 3}                                   │", combo);
                Console.WriteLine(" │                                                       │");
                Console.WriteLine(" │    SCORE:       {0, 5}                                 │", score);
                Console.WriteLine(" │                                                       │");
                Console.WriteLine($" │    CURRENT:      {player.controls.currentPositionString} / {player.currentMedia.durationString}                        │");
                Console.WriteLine(" │                                                       │");
                Console.WriteLine(" │                                                       │");
                Console.WriteLine(" │                                                       │");
                Console.WriteLine(" └───────────────────────────────────────────────────────┘");
                if (hp <= 0)
                {
                    break;
                }
                input = new ConsoleKeyInfo(); //reset
            }
            IsAlive = false; //노래 끄기
            return score;
        }
        static void InputHandler_8key(int i, int[,] test, int choose, ref int combo, ref int hp, ref int score)
        {
            switch (input.Key)
            {
                case ConsoleKey.A:
                    //Console.WriteLine("■□□□");
                    Console.Write(" │ ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("━━━ ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("   ───    ───    ───    ───    ───    ───    ───  │");
                    if (test[choose, i] == 1)
                    {
                        combo++;
                        hp += 1;
                        score += 100;
                        if (hp >= 100)
                        {
                            hp = 100; 
                        }
                    }
                    else if (test[choose, i] == 0)
                    {
                        //Console.WriteLine("없는데 그냥 한번 쳐봄");
                    }
                    else if (test[choose, i] >= 1 && test[choose, i] <= 8)
                    {
                        combo = 0;
                        hp -= 1;
                        score += 100;
                        if (hp < 0)
                        {
                            hp = 0;
                        }
                        //Console.WriteLine("있는데 다른 노트 침  ");
                    }
                    break;
                case ConsoleKey.S:
                    //Console.WriteLine("□■□□");
                    Console.Write(" │ ───    ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("━━━━");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("   ───    ───    ───    ───    ───    ───  │");
                    if (test[choose, i] == 2)
                    {
                        combo++;
                        hp += 1;
                        score += 100;
                        if (hp >= 100)
                        {
                            hp = 100;
                        }
                    }
                    else if (test[choose, i] == 0)
                    {
                        //Console.WriteLine("없는데 그냥 한번 쳐봄");
                    }
                    else if (test[choose, i] >= 1 && test[choose, i] <= 8)
                    {
                        hp -= 1;
                        combo = 0;
                        if (hp < 0)
                        {
                            hp = 0;
                        }
                        //Console.WriteLine("있는데 다른 노트 침  ");
                    }
                    break;
                case ConsoleKey.D:
                    //Console.WriteLine("□□■□");
                    Console.Write(" │ ───    ───    ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("━━━━");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("   ───    ───    ───    ───    ───  │");
                    if (test[choose, i] == 3)
                    {
                        combo++;
                        hp += 1;
                        score += 100;
                        if (hp >= 100)
                        {
                            hp = 100;
                        }
                    }
                    else if (test[choose, i] == 0)
                    {
                        //Console.WriteLine("없는데 그냥 한번 쳐봄");
                    }
                    else if (test[choose, i] >= 1 && test[choose, i] <= 8)
                    {
                        hp -= 1;
                        combo = 0;
                        if (hp < 0)
                        {
                            hp = 0;
                        }
                        //Console.WriteLine("있는데 다른 노트 침  ");
                    }
                    break;
                case ConsoleKey.F:
                    //Console.WriteLine("□□□■");
                    Console.Write(" │ ───    ───    ───    ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("━━━━");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("   ───    ───    ───    ───  │");
                    if (test[choose, i] == 4)
                    {
                        combo++;
                        hp += 1;
                        score += 100;
                        if (hp >= 100)
                        {
                            hp = 100;
                        }
                    }
                    else if (test[choose, i] == 0)
                    {
                        //Console.WriteLine("없는데 그냥 한번 쳐봄");
                    }
                    else if (test[choose, i] >= 1 && test[choose, i] <= 8)
                    {
                        hp -= 1;
                        combo = 0;
                        if (hp < 0)
                        {
                            hp = 0;
                        }
                        //Console.WriteLine("있는데 다른 노트 침  ");
                    }
                    break;
                case ConsoleKey.H:
                    //Console.WriteLine("□□□■");
                    Console.Write(" │ ───    ───    ───    ───   ");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write(" ━━━  ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("  ───    ───    ───  │");
                    if (test[choose, i] == 5)
                    {
                        combo++;
                        hp += 1;
                        score += 100;
                        if (hp >= 100)
                        {
                            hp = 100;
                        }
                    }
                    else if (test[choose, i] == 0)
                    {
                        //Console.WriteLine("없는데 그냥 한번 쳐봄");
                    }
                    else if (test[choose, i] >= 1 && test[choose,i] <= 8)
                    {
                        hp -= 1;
                        combo = 0;
                        if (hp < 0)
                        {
                            hp = 0;
                        }
                        //Console.WriteLine("있는데 다른 노트 침  ");
                    }
                    break;
                case ConsoleKey.J:
                    //Console.WriteLine("□□□■");
                    Console.Write(" │ ───    ───    ───    ───    ───   ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(" ━━━━");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("   ───    ───  │");
                    if (test[choose, i] == 6)
                    {
                        combo++;
                        hp += 1;
                        score += 100;
                        if (hp >= 100)
                        {
                            hp = 100;
                        }
                    }
                    else if (test[choose, i] == 0)
                    {
                        //Console.WriteLine("없는데 그냥 한번 쳐봄");
                    }
                    else if (test[choose, i] >= 1 && test[choose, i] <= 8)
                    {
                        hp -= 1;
                        combo = 0;
                        if (hp < 0)
                        {
                            hp = 0;
                        }
                        //Console.WriteLine("있는데 다른 노트 침  ");
                    }
                    break;
                case ConsoleKey.K:
                    //Console.WriteLine("□□□■");
                    Console.Write(" │ ───    ───    ───    ───    ───    ───   ");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write(" ━━━  ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("  ───  │");
                    if (test[choose, i] == 7)
                    {
                        combo++;
                        hp += 1;
                        score += 100;
                        if (hp >= 100)
                        {
                            hp = 100;
                        }
                    }
                    else if (test[choose, i] == 0)
                    {
                        //Console.WriteLine("없는데 그냥 한번 쳐봄");
                    }
                    else if (test[choose, i] >= 1 && test[choose, i] <= 8)
                    {
                        hp -= 1;
                        combo = 0;
                        if (hp < 0)
                        {
                            hp = 0;
                        }
                        //Console.WriteLine("있는데 다른 노트 침  ");
                    }
                    break;
                case ConsoleKey.L:
                    //Console.WriteLine("□□□■");
                    Console.Write(" │ ───    ───    ───    ───    ───    ───    ───  ");
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("  ━━━━");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" │");
                    if (test[choose, i] == 8)
                    {
                        combo++;
                        hp += 1;
                        score += 100;
                        if (hp >= 100)
                        {
                            hp = 100;
                        }
                    }
                    else if (test[choose, i] == 0)
                    {
                        //Console.WriteLine("없는데 그냥 한번 쳐봄");
                    }
                    else if (test[choose, i] >= 1 && test[choose, i] <= 8)
                    {
                        hp -= 1;
                        combo = 0;
                        if (hp < 0)
                        {
                            hp = 0;
                        }
                        //Console.WriteLine("있는데 다른 노트 침  ");
                    }
                    break;
                default:
                    Console.WriteLine(" │ ───    ───    ───    ───    ───    ───    ───    ───  │");
                    break;
            }
        }
        static int choose_key()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("     ┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
            Console.WriteLine("     ┃                 Key      Option               ┃");
            Console.WriteLine("     ┃                                               ┃");
            Console.WriteLine("     ┃            4 Key             8 Key            ┃");
            Console.WriteLine("     ┃                                               ┃");
            Console.WriteLine("     ┃                                               ┃");
            Console.WriteLine("     ┃                                               ┃");
            Console.WriteLine("     ┃               [ Enter to Start ]              ┃");
            Console.WriteLine("     ┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
            Console.ForegroundColor = ConsoleColor.White;
            int x = 0;
            int currentX = 19;
            while (true)
            {
                Thread.Sleep(50);
                if (x == 0)
                {
                    if (input.Key == ConsoleKey.D || input.Key == ConsoleKey.RightArrow)
                    {
                        Console.SetCursorPosition(19, 11);
                        Console.Write("  ");
                        Console.SetCursorPosition(37, 11);
                        Console.Write("▲");
                        currentX = 37;
                        x = 1;
                    }
                }
                else if (x == 1)
                {
                    if (input.Key == ConsoleKey.A || input.Key == ConsoleKey.LeftArrow)
                    {
                        Console.SetCursorPosition(37, 11);
                        Console.Write("  ");
                        Console.SetCursorPosition(19, 11);
                        Console.Write("▲");
                        currentX = 19;
                        x = 0;
                    }
                }
                if (input.Key == ConsoleKey.Enter)
                {
                    break;
                }
                if (input.Key == ConsoleKey.Escape)
                {
                    return 2;
                }
                Console.SetCursorPosition(currentX, 11);
                Console.Write("△");
                Thread.Sleep(100);
                Console.SetCursorPosition(currentX, 11);
                Console.Write("▲");
                Thread.Sleep(100);
            }
            return x;
        }
    }
}
