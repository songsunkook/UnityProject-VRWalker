using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    private Image image;

    private float timeNow;

    public float timeFull = 13f;

    public static bool die = false;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        timeNow = timeFull;
    }

    // Update is called once per frame
    void Update()
    {
        if (die)
        {
            timeNow = timeFull;
            die = false;
        }
        if(timeNow < 0)
        {
            DIe.die = true;
        }

        Debug.Log("isStopped = " + MoveCtrl.isStopped);
        if (!MoveCtrl.isStopped)
        {
            timeNow -= Time.deltaTime;
            image.fillAmount = timeNow / timeFull;
        }
        else
        {
            timeNow = timeFull;
            image.fillAmount = 1;
        }
    }
}
