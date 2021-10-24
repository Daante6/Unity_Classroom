using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowStats : MonoBehaviour
{
    public Text showTime;
    public GameObject gameHandler;
    private void Start()
    {
        changeTextTime();
    }
    public void changeTextTime()
    {
        TimeObject timeObject = new TimeObject();
        timeObject = calculateTime.int2Time(StaticVariables.time);
        showTime.text = $"{timeObject.minutes} : {timeObject.seconds}";
        
    }
}
