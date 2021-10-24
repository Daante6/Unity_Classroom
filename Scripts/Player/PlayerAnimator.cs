using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    public Animator animator;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (playerSafespace.isCheating)
        {
            animator.SetInteger("isCheatingINT", 1);
        }
        else
        {
            animator.SetInteger("isCheatingINT", 0);
        }
        if (playerSafespace.isSafe)
        {
            animator.SetInteger("isSafeINT", 1);
        }
        else
        {
            animator.SetInteger("isSafeINT", 0);
        }
        
    }

}
