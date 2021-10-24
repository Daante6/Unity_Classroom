using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInfoLoader : MonoBehaviour
{
    playerInfo[] playerInfos;
    private void Awake()
    {
        
    }
    void Start()
    {
        StartCoroutine(waitSecond());
    }
    void Update()
    {
        
    }
    string fixJson(string value)
    {
        value = "{\"Items\":" + value + "}";
        return value;
    }
    IEnumerator waitSecond()
    {
        yield return new WaitForSeconds(2);
        loadPlayers();
    }
    public void loadPlayers()
    {
        string s = fixJson(StaticVariables.JSON);
        playerInfos = JsonHelper.FromJson<playerInfo>(s);
        assignPlayers();
    }
    public void assignPlayers()
    {
        StaticVariables.player1Name = playerInfos[0].nick;
        StaticVariables.player2Name = playerInfos[1].nick;
        StaticVariables.player3Name = playerInfos[2].nick;
        StaticVariables.player4Name = playerInfos[3].nick;
        StaticVariables.player5Name = playerInfos[4].nick;
        StaticVariables.player1Time = playerInfos[0].time;
        StaticVariables.player2Time = playerInfos[1].time;
        StaticVariables.player3Time = playerInfos[2].time;
        StaticVariables.player4Time = playerInfos[3].time;
        StaticVariables.player5Time = playerInfos[4].time;
        StaticVariables.player1Timeobject = calculateTime.int2Time(StaticVariables.player1Time);
        StaticVariables.player2Timeobject = calculateTime.int2Time(StaticVariables.player2Time);
        StaticVariables.player3Timeobject = calculateTime.int2Time(StaticVariables.player3Time);
        StaticVariables.player4Timeobject = calculateTime.int2Time(StaticVariables.player4Time);
        StaticVariables.player5Timeobject = calculateTime.int2Time(StaticVariables.player5Time);
    }
}
