using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstTextHiding : MonoBehaviour
{
    string originalText;
    Text text;

    public static bool isStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();

        originalText = text.text;
    }

    // Update is called once per frame
    void Update()
    {
        if(isStarted)//만약 게임이 시작했으면
        {
            text.text = null;
        }
        else
        {
            text.text = originalText;
        }


    }
}
