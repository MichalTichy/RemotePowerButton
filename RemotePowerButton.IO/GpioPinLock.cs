using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Unosquare.RaspberryIO.Abstractions;

namespace RemotePowerButton.IO
{
    public class GpioPinLock : IDisposable
    {
        private const string LocksLocation = "/run/lock/gpio/";
        private FileStream LockStream;
        public readonly BcmPin Pin;
        private GpioPinLock(BcmPin pin,FileStream lockStream)
        {
            LockStream = lockStream;
            Pin = pin;
        }

        public static GpioPinLock ObtainLock(BcmPin pin)
        {
            if (!Directory.Exists(LocksLocation))
            {
                Debug.WriteLine($"Gpio lock folder not found. Creating new one at {LocksLocation}");

                Directory.CreateDirectory(LocksLocation);

                Debug.WriteLine($"Gpio lock folder created.");
            }

            while (true)
            {
                try
                {
                    var pinName = Enum.GetName(typeof(BcmPin), pin);

                    Debug.WriteLine($"Requesting lock for {pinName}");

                    var path = LocksLocation + pinName;
                    var lockStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read, FileShare.None);

                    Debug.WriteLine($"{pinName} locked");

                    return new GpioPinLock(pin,lockStream);
                }
                catch (IOException ex ){
                    Debug.WriteLine(ex.Message);
                    Thread.Sleep(50);
                }
            }
        }

        public void Dispose()
        {
            LockStream.Dispose();
            Debug.WriteLine($"{Enum.GetName(typeof(BcmPin), Pin)} unlocked.");

        }
    }
}