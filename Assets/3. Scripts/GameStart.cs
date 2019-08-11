using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//미사용 스크립트
public class GameStart : MonoBehaviour {

    float time = 4.0f;
    int textnum;
    bool timerRun = false;
    public GameObject backButton;
    public Text text;
    public static bool active = true;
    public static bool isStart = false;

    public void StartTimer()
    {
        gameObject.SetActive(true);
        backButton.SetActive(true);
        timerRun = true;
        isStart = false;
        //Invoke("Gamestart", 3.0f);
    }

    public void StopTimer()
    {
        timerRun = false;
    }


    private void Gamestart()
    {
        MoveCtrl.isStopped = false;
        time = 4.0f;
        text.text = null;
        gameObject.SetActive(false);
        backButton.SetActive(false);
        timerRun = false;
    }

    private void Update()
    {

        if (timerRun)
        {
            time -= Time.deltaTime;
            textnum = (int)time;
            text.text = textnum.ToString();

            if (time < 1)
            {
                time = 4.0f;
                Gamestart();
                isStart = true;
            }
        }

    }

}
