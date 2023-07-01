using DxLibDLL;

namespace Oikake
{
    internal class Sound
    {
        public static int bomb;
        public static int whistle;
        public static int start;

        public static void Load()
        {
            bomb = DX.LoadSoundMem("SE/bomb.wav");
            whistle = DX.LoadSoundMem("SE/whistle.ogg");
            start = DX.LoadSoundMem("SE/start.ogg");
        }

        public static void Play(int handle)
        {
            DX.PlaySoundMem(handle, DX.DX_PLAYTYPE_BACK);
        }
    }
}
