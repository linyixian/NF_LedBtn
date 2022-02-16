using System;
using System.Diagnostics;
using System.Threading;

//追加
using Iot.Device.Button;
using nanoFramework.AtomMatrix;
using System.Drawing;

namespace NF_LedBtn
{
    public class Program
    {
        private static PixelController led;

        public static void Main()
        {
            led = AtomMatrix.LedMatrix;
            GpioButton button = AtomMatrix.Button;
            
            //次のようにも記述可能
            //GpioButton button = new(buttonPin: 39);
            
            //Led消灯
            led.TurnOff();

            //イベントの登録
            button.Press += Button_Press;

            Thread.Sleep(Timeout.Infinite);

        }

        private static void Button_Press(object sender, EventArgs e)
        {
            Debug.WriteLine("Button Pressed!");

            //LEDの状態を取得
            var color = led.Pixels;

            if (color[12] == Color.Green){
                led.TurnOff();
            }
            else
            {
                led.SetColor(12, Color.Green);
                led.Update();
            }
        }
    }
}
