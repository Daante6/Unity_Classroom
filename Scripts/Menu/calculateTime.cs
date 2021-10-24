using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class calculateTime
{
    public static TimeObject int2Time( int timeInput)
    {
        TimeObject timeObject = new TimeObject();
        if(timeInput > 59)
        {
            timeObject.seconds = timeInput % 60;
            timeInput = timeInput / 60;
            timeObject.minutes = timeInput;
        }
        else
        {
            timeObject.seconds = timeInput;
            timeObject.minutes = 0;
        }
        return timeObject;
    }
}