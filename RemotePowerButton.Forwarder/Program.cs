﻿using System;
using System.Threading;
using RemotePowerButton.IO;

namespace RemotePowerButton.Forwarder
{
    class Program
    {
        static void Main(string[] args)
        {
            var PowerBtn = new PowerButton();
            
            while (true)
            {
                if (PowerBtn.IsPowerButtonPressed())
                    PowerBtn.PushPowerButton();
                else
                    PowerBtn.ReleasePowerButton();

                Thread.Sleep(100);
            }
        }
    }
}