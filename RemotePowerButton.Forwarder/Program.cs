using System;
using System.Diagnostics;
using System.Threading;
using RemotePowerButton.IO;

namespace RemotePowerButton.Forwarder
{
    class Program
    {
        static void Main(string[] args)
        {
            var PowerBtn = new PowerButton();
            Console.WriteLine("Started");

            while (true)
            {
                if (PowerBtn.IsPowerButtonPressed())
                {
                    Debug.WriteLine("Power button pressed. Waiting for release.");
                    PowerBtn.PushPowerButton();
                    while (PowerBtn.IsPowerButtonPressed()) Thread.Sleep(10);

                    Debug.WriteLine("Power button released.");
                    PowerBtn.ReleasePowerButton();
                }
            }
        }
    }
}
