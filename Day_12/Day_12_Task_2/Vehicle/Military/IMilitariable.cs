using System;
using System.Collections.Generic;
using System.Text;

namespace Day_12_Task_2.Vehicle.Military
{
    interface IMilitariable
    {
        double ShotPerSecond { get; set; }

        int CountShotsPerMinute();

    }
}
