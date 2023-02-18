using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeChartEditor
{
    internal class ConveyorSensor : Module
    {


        public ConveyorSensor()
        {
        }

        public override void RunToModule(ActUtlTypeLib.ActUtlTypeClass actUtlType)
        {
            for (int j = 0; j < 6; j++)
            {
                actUtlType.WriteDeviceRandom2("X2", 1,  1);
                Thread.Sleep(1000);
                actUtlType.WriteDeviceRandom2("X2", 1,  0);
                Thread.Sleep(1000);
            }
        }
    }
}
