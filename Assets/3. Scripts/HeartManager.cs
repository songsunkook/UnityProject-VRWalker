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
        if (!MoveCtrl.isStopped)
        {
            timeNow -= Time.deltaTime;
            image.fillAmount = timeNow / timeFull;

            if (timeNow < 0)
            {
                DIe.die = true;
            }
        }
        else
        {
            image.fillAmount = 1;
        }
    }
}
