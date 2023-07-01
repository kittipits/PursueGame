using DxLibDLL;

namespace Oikake
{
    public static class Image
    {
        public static int white;
        public static int black;
        public static int playBG;
        public static int titleBG;
        public static int pushButtonToStart;
        public static int timeover;
        public static int pushButtonToTitle;

        public static void Load()
        {
            white = DX.LoadGraph("Image/white.png");
            black = DX.LoadGraph("Image/black.png");
            playBG = DX.LoadGraph("Image/play_bg.png");
            titleBG = DX.LoadGraph("Image/title_bg.png"); 
            pushButtonToStart = DX.LoadGraph("Image/push_button_to_start.png"); 
            timeover = DX.LoadGraph("Image/timeover.png"); 
            pushButtonToTitle = DX.LoadGraph("Image/push_button_to_title.png"); 
        }

    }
}
