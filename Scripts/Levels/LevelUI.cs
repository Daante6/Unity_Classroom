using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelUI : MonoBehaviour
{
    public Text levelText;
    public Image levelImage;
    private Color levelColorPanel;
    private Color levelColorText;
    
    void Start()
    {
        levelText.text = $"{SceneManager.GetActiveScene().name}";
        levelImage.gameObject.SetActive(true);
        levelText.gameObject.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeSinceLevelLoad < 2)
        {
            levelColorText = Color.black;
            levelColorText.a = Mathf.Lerp(1f, 0f, Time.timeSinceLevelLoad / 2);
            levelText.color = levelColorText;
            levelColorPanel = Color.white;
            levelColorPanel.a = Mathf.Lerp(1f, 0f, Time.timeSinceLevelLoad / 2);
            levelImage.color = levelColorPanel;
        }
        else
        {
            levelImage.gameObject.SetActive(false);
            levelText.gameObject.SetActive(false);
        }

        
    }
}
