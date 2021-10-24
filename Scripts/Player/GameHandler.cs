using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    Cheating cheating;

    public Text text;
    public Button button;
    public Text buttonText;
    public GameObject panel;

    private bool pause;

    public float ElapsedTime;

    private void Start()
    {
        cheating = GetComponent<Cheating>();

        Time.timeScale = 1;
        panel.SetActive(false);
        button.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
        Cheating.isCaught = false;

        ElapsedTime = 0;
    }
    public void EndLevelButton()
    {
        
        if (Cheating.isCaught)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (cheating.CheatBar >= 100)
        {
            StaticVariables.time = StaticVariables.time + (int)ElapsedTime;
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            if (SceneManager.sceneCountInBuildSettings > nextSceneIndex)
            {
                SceneManager.LoadScene(nextSceneIndex);
            }
        }

    }
    public void EndLevel()
    {
        Time.timeScale = 0;
        panel.SetActive(true);
        button.gameObject.SetActive(true);
        text.gameObject.SetActive(true);
        if (Cheating.isCaught)
        {
            text.text = "Caught!";
            buttonText.text = "Restart";
        }
        else if(cheating.CheatBar >= 100)
        {
            int tempSeconds = (StaticVariables.time + (int)ElapsedTime) % 60;
            int tempMinutes = (StaticVariables.time + (int)ElapsedTime) / 60;
            int elapsedSec = (int)ElapsedTime % 60;
            int elapsedMin = (int)ElapsedTime / 60;
            text.text = $"U passed!\n" +
                $"Time for this level: {elapsedMin}min{elapsedSec}sec\n" +
                $"Time total: {tempMinutes}min{tempSeconds}sec";
            buttonText.text = "Next Level";
        }
        if (Input.GetKeyDown("space"))
        {
            EndLevelButton();
        }
    }
    private void Update()
    {
        if(Cheating.isCaught)
        {
            EndLevel();
        }
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (Input.GetKeyDown("p") || Input.GetKeyDown("escape"))
        {
            if (pause)
            {
                pause = !pause;
                Time.timeScale = 1;
                text.gameObject.SetActive(false);
                panel.SetActive(false);
            }
            else
            {
                pause = !pause;
                Time.timeScale = 0;
                text.gameObject.SetActive(true);
                panel.SetActive(true);
                text.text = "Pause";
            }
        }
        ElapsedTime += Time.deltaTime;
    }

}
