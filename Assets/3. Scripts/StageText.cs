using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageText : MonoBehaviour
{
    Text text;
    string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStart.isStart == false)
        {

            sceneName = SceneManager.GetActiveScene().name;
            Debug.Log(sceneName);
            if (sceneName[4] == 'S')
            {
                text.text = "Chapter " + sceneName[2] + "\n" + "Stage " + sceneName[sceneName.Length - 1].ToString();
            }
            if (sceneName[4] == 'O')
            {
                text.text = "Chapter " + sceneName[2] + "\n" + "Odyssey";
            }

        }
        else
        {
            text.text = null;
        }
    }
}
