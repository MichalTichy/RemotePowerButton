using System;
using System.Diagnostics;
using System.Threading;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Abstractions;
using Unosquare.WiringPi;

namespace RemotePowerButton.IO
{
    public static class GpioController
    {
        static GpioController()
        {
            Pi.Init<BootstrapWiringPi>();
        }

        public static bool GetPinValue(BcmPin pinNumber)
        {
            Debug.WriteLine($"Reading value  of {Enum.GetName(typeof(BcmPin), pinNumber)}");

            var pin = Pi.Gpio[pinNumber];
            if (pin.PinMode != GpioPinDriveMode.Input)
            {
                pin.PinMode = GpioPinDriveMode.Input;
            }

            var pinValue = pin.Read();

            Debug.WriteLine($"Value of {Enum.GetName(typeof(BcmPin), pinNumber)} is {pinValue}");

            return pinValue;
        }

        public static void SetPinValue(BcmPin pinNumber, bool value, int? duration = null)
        {
            var pinName = Enum.GetName(typeof(BcmPin), pinNumber);

            Debug.WriteLine($"Setting value  of {pinName} to {value}");

            var pin = Pi.Gpio[pinNumber];
            if (pin.PinMode != GpioPinDriveMode.Output)
            {
                pin.PinMode = GpioPinDriveMode.Output;
            }

            using (GpioPinLock.ObtainLock(pinNumber))
            {
                pin.Write(value);
            }

            Debug.WriteLine($"Value of {pinName} is now {value}");

            if (duration.HasValue)
            {
                Debug.WriteLine($"Waiting for {duration}ms before setting {pinName} to {!value}.");

                Thread.Sleep(duration.Value);

                pin.Write(!value);

                Debug.WriteLine($"Value of {pinName} is now {value}");
            }
        }

    }
}
