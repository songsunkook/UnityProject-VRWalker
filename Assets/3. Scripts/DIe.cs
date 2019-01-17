using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DIe : MonoBehaviour {

    Transform trans;
    public GameObject startObject;

	// Use this for initialization
	void Start () {
        trans = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        if (trans.position.y < -3)
        {
            trans.position = new Vector3(0, 1, 0);
            MoveCtrl.isStopped = true;
            startObject.SetActive(true);
        }
	}
}
