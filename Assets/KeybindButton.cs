using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class KeybindButton : MonoBehaviour
{
    [SerializeField]
    string key, defaultKeyString;
    KeyCode bindKey;
    [SerializeField]
    TMP_Text BindText;
    
    static string waitingForInputText = "Awaiting input";
    // Start is called before the first frame update
    void Start()
    {
        
        Debug.Log(KeyCode.Space.ToString());
        KeyCode defaultKey = KeyCode.A;
        object obj;
        if(Enum.TryParse(typeof(KeyCode), defaultKeyString, out obj))
        {
            defaultKey = (KeyCode) obj;
            Debug.Log(defaultKey.ToString());
        }
        else Debug.LogError("Unable to parse default key value!");
        
        updateKeyBind((KeyCode) PlayerPrefs.GetInt(key, (int) defaultKey));
        
    }

    public void changeKeyBind()
    {
        BindText.text = waitingForInputText;
    }

    void Update()
    {
        if(BindText.text == waitingForInputText)
        {
            foreach(KeyCode keycode in Enum.GetValues(typeof(KeyCode)))
            {
                if(Input.GetKey(keycode))
                {
                    updateKeyBind(keycode);
                    return;
                }
                
            }
        }
    }

    private void updateKeyBind(KeyCode newBind)
    {
        BindText.text = newBind.ToString();
        bindKey = newBind;
        PlayerPrefs.SetInt(key, (int) bindKey);
    }
}
