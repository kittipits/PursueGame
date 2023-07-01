using DxLibDLL;
using MyLib;

namespace Oikake
{
    public class Black
    {
        public const int Size = 64;

        public float x;
        public float y;

        float vx;
        float vy;

        public Black() 
        {
            ResetPosition();

            vx = MyRandom.PlusMinus(2f);
            vy = MyRandom.PlusMinus(2f);
        }

        public void Update()
        {
            x += vx;
            y += vy;

            if (x < 0) 
                x = 0; 
                vx = -vx;
            if (x > Screen.Width - Size) 
                x = Screen.Width - Size; 
                vx = -vx;
            if (y < 0) 
                y = 0; 
                vy = -vy;
            if (y > Screen.Height -  Size) 
                y = Screen.Height - Size; 
                vy = -vy;
        }

        public void Draw()
        {
            DX.DrawGraphF(x, y, Image.black);
        }

        public void ResetPosition()
        {
            x = MyRandom.Range(0, Screen.Width - Size);
            y = MyRandom.Range(0, Screen.Height - Size);
        }
    }
}
