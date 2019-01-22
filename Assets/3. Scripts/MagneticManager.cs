using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticManager : MonoBehaviour
{
    bool pressing = false;
    float time = 0f;
    float FullChargeTime = 2f;

    public GameObject PausePanel;

    private void TouchEnter()
    {
        pressing = true;
    }

    private void TouchExit()
    {
        //if(time < FullChargeTime)
        if (pressing)
            MoveCtrl.isStopped = !MoveCtrl.isStopped;
        pressing = false;
        time = 0f;
    }

    private void Pause()
    {
        //Time.timeScale = 0f;
        PausePanel.SetActive(true);
    }

    public void PauseExit()
    {
        //Time.timeScale = 1f;
        PausePanel.SetActive(false);
    }

    private void Start()
    {
        PausePanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            TouchEnter();
        if (Input.GetMouseButtonUp(0))
            TouchExit();

        if (pressing)
        {
            time += Time.deltaTime;
            if(time > FullChargeTime)
            {
                if (PausePanel.activeSelf == true)//포즈 해제 임시방편
                    PauseExit();
                else
                    Pause();
                time = 0f;
                pressing = false;
            }
        }
    }


}
