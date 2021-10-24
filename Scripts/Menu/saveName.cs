using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class saveName : MonoBehaviour
{
    public InputField NameField;
    // Start is called before the first frame update
    public void ChangeName()
    {
        StaticVariables.PlayerName = NameField.text;
    }
}
