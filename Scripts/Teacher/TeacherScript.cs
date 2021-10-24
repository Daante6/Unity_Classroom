using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeacherScript : MonoBehaviour
{ 

    
    public float AwarnessMax = 200;
    public float Awarness { get; set; }

    FOV playerScript;

    public TeacherScript()
    {
        
    }


    // Start is called before the first frame update
    void Start()
    {
        Awarness = AwarnessMax;
        playerScript = GetComponent<FOV>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (playerScript.isSeen && !playerSafespace.isSafe)
        {
            Awarness -= Time.deltaTime;
            if(Awarness < 0)
            {
                Awarness = 0;
                Cheating.isCaught = true;

            }
        }
        else
        {
            Awarness += Time.deltaTime * 0.2f;
            if(Awarness > AwarnessMax)
            {
                Awarness = AwarnessMax;
            }
        }
    }
}
