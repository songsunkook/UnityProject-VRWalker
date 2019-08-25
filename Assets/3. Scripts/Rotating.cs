using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour {
    public float spinValue = 90;
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up * spinValue * Time.deltaTime);
	}
}
