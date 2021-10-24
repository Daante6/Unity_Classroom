using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cheating : MonoBehaviour
{
    public float CheatBar;
    public float CheatSpeed;
    playerSafespace playerSafespace;
    public Slider progressBar;
    public Image ProgressBarColor;
    public SpriteRenderer Indicator;
    public Color IndicatorColor;
    public float IndicatorBlink = 2.0f;

    public static bool isCaught = false;

    // Start is called before the first frame update
    void Start()
    {
        playerSafespace = GetComponent<playerSafespace>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerSafespace.isCheating)
        {
            CheatBar += Time.deltaTime * CheatSpeed;
            if(CheatBar >= 98.5)
            {
                CheatBar = 100;
            }
            progressBar.value = CheatBar;
            ProgressBarColor.color = Color.Lerp(Color.yellow, Color.green, CheatBar/100);
            
        }

        if (CheatBar >= 100)
        {
            blinkIndicator();
            ProgressBarColor.color = Color.blue;
        }
        else
        {
            IndicatorColor = new Color(1.0f, 1.0f, 1.0f, 0.2f);
            Indicator.color = IndicatorColor;
        }
    }
    void blinkIndicator()
    {
        IndicatorBlink = IndicatorBlink - Time.deltaTime;
        if(IndicatorBlink <= 0.3f)
        {
            IndicatorBlink = 2.0f;
        }
        IndicatorColor = new Color(1.0f, 1.0f, 1.0f, IndicatorBlink/2);
        Indicator.color = IndicatorColor;
    }
}
