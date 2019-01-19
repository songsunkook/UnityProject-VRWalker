using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StarManager : MonoBehaviour
{

    Text text;

    public static int starCount = 0;
    int chapter;
    int starFullCount;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();

        chapter = SceneManager.GetActiveScene().name[2] - '0';

        starFullCount = chapter * 2 + 1;
    }

    // Update is called once per frame
    void Update()
    {



        text.text = starCount + " / " + starFullCount;
    }
}
