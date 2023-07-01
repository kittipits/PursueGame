using DxLibDLL;
using MyLib;
using System;

namespace Oikake
{
    public class Game
    {
        enum State
        { 
            Title,
            Play,
            Timeover,
        }

        const int BlackNum = 5;
        const int InitailRemainingTime = 60 * 10;

        White white;
        Black[] blacks;
        int score;
        int remainingTime;

        State state;
        int count;　//改造
        int press;
        bool isPress;
        int timeoverY;
        float theta;

        public void Init()
        {
            MyRandom.Init();
            Input.Init();
            Image.Load();
            Sound.Load();
            DX.SetFontSize(60);

            Reset();
        }

        void Reset()
        {
            //位置の初期化
            white = new White();

            blacks = new Black[BlackNum];
            for (int i = 0; i < blacks.Length; i++) blacks[i] = new Black();
            score = 0;
            remainingTime = InitailRemainingTime;
            state = State.Title;

            DX.PlayMusic("BGM/title.mp3", DX.DX_PLAYTYPE_LOOP);

            count = 0;　//改造
            press = 120;
            isPress = false;
            timeoverY = Screen.Height;
            theta = 0.0f;
        }

        public void Update()
        {
            Input.Update();
            count++;　//改造
            if (isPress == true) press--;

            if (state == State.Title)
            {
                if (Input.GetButtonDown(DX.PAD_INPUT_1))
                {
                    Sound.Play(Sound.start);
                    isPress = true;
                    DX.StopMusic();
                }

                if (press <= 0)
                {
                    state = State.Play;
                    DX.PlayMusic("BGM/gameplay.mp3", DX.DX_PLAYTYPE_LOOP);
                }
            }

            else if (state == State.Play)
            {
                white.Update();

                foreach (Black black in blacks)
                {
                    black.Update();
                }

                //衝突判定
                foreach (Black black in blacks)
                {
                    if (white.x < black.x + Black.Size &&
                        white.x + White.Size > black.x &&
                        white.y < black.y + Black.Size &&
                        white.y + White.Size > black.y)
                    {
                        black.ResetPosition();
                        score += 100;
                        Sound.Play(Sound.bomb);
                    }
                }

                remainingTime -= 1;
                if (remainingTime < 0)
                {
                    remainingTime = 0;
                    state = State.Timeover;
                    Sound.Play(Sound.whistle);
                    DX.PlayMusic("BGM/ending.mp3", DX.DX_PLAYTYPE_LOOP);
                }   
            }

            else if (state == State.Timeover) 
            {
                if (Input.GetButtonDown(DX.PAD_INPUT_1))
                {
                    Reset();
                }
                theta += 0.5f;
                timeoverY -= 40;
                if (timeoverY < 160) timeoverY = 160;
            }
        }

        public void Draw()
        {
            if (state == State.Title)
            {
                DX.DrawGraph(0, 0, Image.titleBG);

                //改造
                if (isPress == false)
                {
                    if (count % 60 > 30) DX.DrawGraph(167, 430, Image.pushButtonToStart);
                }
                else if (isPress == true)
                {
                    if (count % 4 > 2) DX.DrawGraph(167, 430, Image.pushButtonToStart);
                }
            }

            else if (state == State.Play || state == State.Timeover)
            {
                DX.DrawGraph(0, 0, Image.playBG);
                white.Draw();
                foreach (Black black in blacks)
                {
                    black.Draw();
                }

                DX.DrawString(424, 24, "SCORE:" + score, DX.GetColor(0, 0, 0));
                DX.DrawString(420, 20, "SCORE:" + score, DX.GetColor(255, 255, 255));

                float sec = remainingTime / 60f;
                DX.DrawString(24, 24, "TIME:" + sec.ToString("00.00"), DX.GetColor(0, 0, 0));
                DX.DrawString(20, 20, "TIME:" + sec.ToString("00.00"), DX.GetColor(255, 255, 255));

                if (state == State.Timeover)
                {
                    DX.DrawGraph(118, timeoverY, Image.timeover);

                    if (timeoverY <= 160)
                    {
                        float y = 400 + (float)Math.Sin(theta) * 2.5f;
                        DX.DrawGraphF(73, y, Image.pushButtonToTitle);

                    }
                }
            }
        }
    }
}
