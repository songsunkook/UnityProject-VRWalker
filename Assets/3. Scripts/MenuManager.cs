using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("1-1"))
        {

            for(int i = 1; i <= 4; i++)
            {
                for(int j = 1; j <= 7; j++)
                {
                    PlayerPrefs.SetInt(i.ToString() + "-" + j.ToString(), 0);
                }
            }

            PlayerPrefs.SetInt("1-1", 1);
        }




        if(PlayerPrefs.GetInt("1-1") == 1)
            transform.GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(false);
        else
            transform.GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(true);

        if (PlayerPrefs.GetInt("2-1") == 1)
            transform.GetChild(0).GetChild(1).GetChild(1).gameObject.SetActive(false);
        else
            transform.GetChild(0).GetChild(1).GetChild(1).gameObject.SetActive(true);

        if (PlayerPrefs.GetInt("3-1") == 1)
            transform.GetChild(0).GetChild(2).GetChild(1).gameObject.SetActive(false);
        else
            transform.GetChild(0).GetChild(2).GetChild(1).gameObject.SetActive(true);

        if (PlayerPrefs.GetInt("4-1") == 1)
            transform.GetChild(0).GetChild(3).GetChild(1).gameObject.SetActive(false);
        else
            transform.GetChild(0).GetChild(3).GetChild(1).gameObject.SetActive(true);



        for (int i = 1; i < transform.childCount; i++)
        {
            for(int j = 0; j < 7; j++)
            {
                if (PlayerPrefs.GetInt(i.ToString()+"-"+(j+1).ToString()) == 1)
                {
                    transform.GetChild(i).GetChild(j).GetChild(1).gameObject.SetActive(false);
                }
                else
                {
                    transform.GetChild(i).GetChild(j).GetChild(1).gameObject.SetActive(true);
                }
            }
        }


    }
}
