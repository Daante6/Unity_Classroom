using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level11 : MonoBehaviour
{
    public GameObject Classmate;
    public GameObject Geek2;
    private float timeElapsed;
    private bool enableGeek;
    // Start is called before the first frame update
    void Start()
    {
        timeElapsed = 0f;
        enableGeek = false;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if(!enableGeek && timeElapsed > 7)
        {
            enableGeek = true;
            Classmate.SetActive(false);
            Geek2.SetActive(true);
        }
    }
}
