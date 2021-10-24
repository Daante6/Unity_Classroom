using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class Web : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(downloadScore());
    }
    void Start()
    {
        //StartCoroutine(downloadScore());
    }

    IEnumerator testConnection()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("https://dante.mangowcy.pl/Unity/Classroom/network/testConnect.php"))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);

                byte[] results = www.downloadHandler.data;
            }
        }
    }
    IEnumerator uploadScore()
    {
        WWWForm form = new WWWForm();
        form.AddField("nick", StaticVariables.PlayerName);
        form.AddField("time", StaticVariables.time);

        UnityWebRequest www = UnityWebRequest.Post("https://dante.mangowcy.pl/Unity/Classroom/network/insertScore.php", form);
        yield return www.SendWebRequest();
    }
    IEnumerator downloadScore()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("https://dante.mangowcy.pl/Unity/Classroom/network/readBest.php"))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                string jsonArray = www.downloadHandler.text;
                StaticVariables.JSON = www.downloadHandler.text;
            }
        }
    }
    public void SendButton()
    {
        StartCoroutine(uploadScore());
    }
}
