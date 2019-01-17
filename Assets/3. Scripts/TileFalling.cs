using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileFalling : MonoBehaviour
{
    Transform trans;

    float time = 0f;
    float time2 = 0f;
    float fallingSpeed = 3f;
    Vector3 firstPosition;

    public float FallTime = 2f;



    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
        firstPosition = trans.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (MoveCtrl.isStopped == false)
        {
            time += Time.deltaTime;
        }
        else
        {
            time = 0;
            time2 = 0;
            trans.position = firstPosition;
            trans.GetChild(0).gameObject.SetActive(true);
            trans.GetChild(1).gameObject.SetActive(true);
        }

        if(time > FallTime)
        {
            Falling();
        }

    }

    void Falling()
    {
        time2 += Time.deltaTime;

        if (time2 < 1)
            transform.Translate(Vector3.down * fallingSpeed * Time.deltaTime);
        else
        {
            trans.GetChild(0).gameObject.SetActive(false);
            trans.GetChild(1).gameObject.SetActive(false);
        }
    }

}
