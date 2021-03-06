﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DIe : MonoBehaviour {

    //Transform firstTrans;
    Transform trans;
    public GameObject startObject;
    public GameObject reviveEffects;
    public static bool die = false;

    // Use this for initialization
    void Start () {
        trans = GetComponent<Transform>();
        for (int i = 0; i < reviveEffects.transform.childCount; i++)
            reviveEffects.transform.GetChild(i).GetComponent<ParticleSystem>().Stop();
        //firstTrans.position = trans.position;
	}
	
	// Update is called once per frame
	void Update () {
        if(trans.position.y < -3)
        {
            if(StageText.sceneName[2] != '4')
            {
                die = true;
            }
        }

        if (die == true)
        {
            die = false;
            for (int i = 0; i < reviveEffects.transform.childCount; i++)
                reviveEffects.transform.GetChild(i).GetComponent<ParticleSystem>().Play();
            trans.position = new Vector3(0, 1, 0);
            //trans.position = firstTrans.position;

            FirstTextHiding.isStarted = false;
            Debug.Log("Die");
            //HeartManager.timeNow = HeartManager.timeFull;
            HeartManager.die = true;
            MoveCtrl.isStopped = true;
            startObject.SetActive(true);
        }
	}
}
