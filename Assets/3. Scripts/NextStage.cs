using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextStage : MonoBehaviour {

    public static void gotoNext()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        char sceneNum = sceneName[sceneName.Length - 1];

        if(sceneNum - '0' == 6)
        {
            SceneManager.LoadScene("Ch" + sceneName[2] + " Odyssey");
        }
        else
        {
            sceneName = sceneName.Remove(sceneName.Length - 1);

            SceneManager.LoadScene(sceneName + (sceneNum + 1 - 48));
        }
    }
}
