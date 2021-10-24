using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class assignLeaderboard : MonoBehaviour
{
    public Text leaderboard;
    private void Update()
    {
        if (StaticVariables.player1Time == 0)
        {
            leaderboard.text = $"Leaderboard:\nLoading";
        }
        else
        {
            leaderboard.text = $"" +
                $"Leaderboard:\n" +
                $"{StaticVariables.player1Name}: {StaticVariables.player1Timeobject.minutes}.{StaticVariables.player1Timeobject.seconds}\n" +
                $"{StaticVariables.player2Name}: {StaticVariables.player2Timeobject.minutes}.{StaticVariables.player2Timeobject.seconds}\n" +
                $"{StaticVariables.player3Name}: {StaticVariables.player3Timeobject.minutes}.{StaticVariables.player3Timeobject.seconds}\n" +
                $"{StaticVariables.player4Name}: {StaticVariables.player4Timeobject.minutes}.{StaticVariables.player4Timeobject.seconds}\n" +
                $"{StaticVariables.player5Name}: {StaticVariables.player5Timeobject.minutes}.{StaticVariables.player5Timeobject.seconds}\n";
                
        }
        
    }
}
