using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using Microsoft.Owin.Hosting;

namespace RemotePowerButton.API
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = ConfigurationManager.AppSettings["apiUrl"];

            // Start OWIN host 
            using (WebApp.Start<Startup>(baseAddress))
            {
                Console.WriteLine($"Running at {baseAddress}");
                Thread.Sleep(Timeout.Infinite);

            }
        }
    }
}
