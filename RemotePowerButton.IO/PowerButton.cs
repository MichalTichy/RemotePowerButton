using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IctBaden.RasPi.IO;

namespace RemotePowerButton.IO
{
    public class PowerButton
    {
        protected DigitalIo io;
        protected Output MotherBoardPowerBtn;
        protected Input HardwarePowerBtn;
        
        public PowerButton()
        {
            InitIO();
        }

        protected void InitIO()
        {
            io = new DigitalIo();
            if (!io.Initialize())
                throw new IOException("Cannot initialize IO");

            MotherBoardPowerBtn = io.CreateOutput(Gpio.Gpio4);
            HardwarePowerBtn = io.CreateInput(Gpio.Gpio17);
        }

        public void PressPowerBtn(int duration = 250)
        {
            lock (MotherBoardPowerBtn)
            {
                MotherBoardPowerBtn.Set(true);
                Thread.Sleep(duration);
                MotherBoardPowerBtn.Set(false);
            }
        }
    }
}
