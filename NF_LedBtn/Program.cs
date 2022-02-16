using System;
using System.Diagnostics;
using System.Threading;

//�ǉ�
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
            
            //���̂悤�ɂ��L�q�\
            //GpioButton button = new(buttonPin: 39);
            
            //Led����
            led.TurnOff();

            //�C�x���g�̓o�^
            button.Press += Button_Press;

            Thread.Sleep(Timeout.Infinite);

        }

        private static void Button_Press(object sender, EventArgs e)
        {
            Debug.WriteLine("Button Pressed!");

            //LED�̏�Ԃ��擾
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
