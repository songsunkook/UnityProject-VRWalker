using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DIe : MonoBehaviour {

    //Transform firstTrans;
    Transform trans;
    public GameObject startObject;
    public static bool die = false;

    /*
    public static void Die()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject[] startObject = GameObject.FindGameObjectsWithTag("startObject");
        Debug.Log("Die");
        player.transform.position = new Vector3(0, 1, 0);
        MoveCtrl.isStopped = true;
        for (int i = 0; i < startObject.Length; i++)
        {
            startObject[i].SetActive(true);
            Debug.Log("Active");
        }
    }*/

    // Use this for initialization
    void Start () {
        trans = GetComponent<Transform>();
        //firstTrans.position = trans.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (trans.position.y < -3 || die == true)
        {
            trans.position = new Vector3(0, 1, 0);
            //trans.position = firstTrans.position;
            MoveCtrl.isStopped = true;
            startObject.SetActive(true);
            die = false;
        }
	}
}
