using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroying : MonoBehaviour
{
    float x;
    float time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(90, MoveCtrl.yRot, 0);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > 1)
            Destroy(gameObject);
    }
}
