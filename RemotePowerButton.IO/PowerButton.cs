using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Abstractions;
using Unosquare.WiringPi;

namespace RemotePowerButton.IO
{
    public class PowerButton
    {
        protected const BcmPin MotherBoardPowerBtn = BcmPin.Gpio04;
        protected const BcmPin HardwarePowerBtn = BcmPin.Gpio22;
        protected const BcmPin HwPowerBtnCounterPart = BcmPin.Gpio23;


        public void PressPowerButton(int duration = 1000)
        {
            GpioController.SetPinValue(MotherBoardPowerBtn,true,duration);
        }

        public bool IsPowerButtonPressed()
        {
            GpioController.SetPinValue(HwPowerBtnCounterPart,true);
            return GpioController.GetPinValue(HardwarePowerBtn);
        }

        public void ReleasePowerButton()
        {
            GpioController.SetPinValue(MotherBoardPowerBtn,false);
        }

        public void PushPowerButton()
        {
            GpioController.SetPinValue(MotherBoardPowerBtn,true);
        }
    }
}
