using System;
using System.Diagnostics;
using System.IO;
using System.Security.AccessControl;
using System.Threading;
using Unosquare.RaspberryIO.Abstractions;

namespace RemotePowerButton.IO
{
    public class GpioPinLock : IDisposable
    {
        private const string LocksLocation = "/run/lock/gpio/";
        private FileStream LockStream;
        public readonly BcmPin Pin;
        private Mutex mutex;

        private GpioPinLock(BcmPin pin,FileStream lockStream)
        {
            LockStream = lockStream;
            Pin = pin;
            mutex = new Mutex(false, "test");
            mutex.WaitOne();
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

                    var path = CreateLockFilePath(pin);
                    var lockStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite,FileShare.None);
                    lockStream.Lock(0, 0);

                    Debug.WriteLine($"{pinName} locked");

                    return new GpioPinLock(pin,lockStream);
                }
                catch (IOException ex )
                {
                    Debug.WriteLine(ex.Message);
                    Thread.Sleep(50);
                }

            }
        }

        private static string CreateLockFilePath(BcmPin pin)
        {
            return LocksLocation + Enum.GetName(typeof(BcmPin), pin);
        }

        public void Dispose()
        {
            LockStream.Unlock(0,0);
            LockStream.Close();
            File.Delete(CreateLockFilePath(Pin));

            Debug.WriteLine($"{Enum.GetName(typeof(BcmPin), Pin)} unlocked.");
        }
    }
}