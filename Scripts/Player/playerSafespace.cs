using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSafespace : MonoBehaviour
{
    public static bool isSafe;
    public static bool isCheating;

    Cheating cheating;
    GameHandler gameHandler;
    // Start is called before the first frame update
    void Start()
    {
        cheating = GetComponent<Cheating>();
        gameHandler = GetComponent<GameHandler>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isSafe = false;
        isCheating = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "SafeSpace")
        {
            isSafe = true;
        }
        if (collision.tag == "CheatSpace")
        {
            isCheating = true;
        }
    }
    private void Update()
    {
        if (isSafe && cheating.CheatBar >= 100)
        {
            gameHandler.EndLevel();
        }
    }
}
