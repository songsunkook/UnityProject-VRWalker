using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarFillingRemake : MonoBehaviour
{
    public GameObject backbar;
    public GameObject forwardbar;


    Image image;
    bool isFilling = false;

    public void StartFilling()
    {
        isFilling = true;
    }

    public void StopFilling()
    {
        isFilling = false;
        image.fillAmount = 0f;
    }



    // Start is called before the first frame update
    void Start()
    {
        image = forwardbar.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFilling == true)
        {
            image.fillAmount += Time.deltaTime;
            if(image.fillAmount == 1)
            {

            }
        }
        
    }
}
