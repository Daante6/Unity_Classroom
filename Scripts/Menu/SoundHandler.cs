using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundHandler : MonoBehaviour
{
    public Sprite mute;
    public Sprite unmute;
    public bool isMute;
    public Image image;
    
    public void muteUnmuteButton()
    {
        if (isMute)
        {
            image.sprite = mute;
            isMute = !isMute;
        }
        else
        {
            image.sprite = unmute;
            isMute = !isMute;
        }
    }
}
