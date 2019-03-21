using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    private Image image;

    public static float timeNow;
    public static float timeFull = 8f;


    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        timeNow = timeFull;
    }

    // Update is called once per frame
    void Update()
    {
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
