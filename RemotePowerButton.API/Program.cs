using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Owin.Hosting;

namespace RemotePowerButton.API
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://*:9876/";

            // Start OWIN host 
            using (WebApp.Start<Startup>(baseAddress))
            {
                Console.WriteLine($"Running at {baseAddress}");
                Thread.Sleep(Timeout.Infinite);

            }
        }
    }
}
