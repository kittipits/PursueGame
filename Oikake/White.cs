using DxLibDLL;
using MyLib;

namespace Oikake
{
    public class White
    {
        public const float Speed = 5f;
        public const int Size = 64;

        public float Naname = 1f;

        public float x;
        public float y;

        public White()
        {
            Reset();
        }

        public void Reset()
        {
            x = 200;
            y = 100;
        }

        public void Update()
        {
            //移動処理
            if (Input.GetButton(DX.PAD_INPUT_LEFT)) x -= (Speed * Naname);
            if (Input.GetButton(DX.PAD_INPUT_RIGHT)) x += (Speed * Naname);
            if (Input.GetButton(DX.PAD_INPUT_UP)) y -= (Speed * Naname);
            if (Input.GetButton(DX.PAD_INPUT_DOWN)) y += (Speed * Naname);

            if ((Input.GetButton(DX.PAD_INPUT_LEFT) && Input.GetButton(DX.PAD_INPUT_UP)) ||
                (Input.GetButton(DX.PAD_INPUT_LEFT) && Input.GetButton(DX.PAD_INPUT_DOWN)) ||
                (Input.GetButton(DX.PAD_INPUT_RIGHT) && Input.GetButton(DX.PAD_INPUT_UP)) ||
                (Input.GetButton(DX.PAD_INPUT_RIGHT) && Input.GetButton(DX.PAD_INPUT_DOWN)))
            {
                Naname = 1.5f;
            }
            else
            {
                Naname = 1f;
            }

            //移動制限
            if (x < 0) x = 0;
            if (x > Screen.Width - Size) x = Screen.Width - Size;
            if (y < 0) y = 0;
            if (y > Screen.Height - Size) y = Screen.Height - Size;
        }

        public void Draw()
        {
            DX.DrawGraphF(x, y, Image.white);
        }
    }
}
