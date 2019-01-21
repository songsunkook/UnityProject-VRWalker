using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BarFilling : MonoBehaviour {


    bool isFilling = false;
    float fillAmount = 0f;
    public float fullTime = 1.5f;
    public GameObject backbar;
    public GameObject forwardbar;
    GameObject[] Chapter = new GameObject[4];

    Image image;

    private void Start()
    {
        backbar.SetActive(false);
        forwardbar.SetActive(false);
        image = forwardbar.GetComponent<Image>();
        Chapter[0] = transform.parent.parent.GetChild(1).gameObject;
        Chapter[1] = transform.parent.parent.GetChild(2).gameObject;
        Chapter[2] = transform.parent.parent.GetChild(3).gameObject;
        Chapter[3] = transform.parent.parent.GetChild(4).gameObject;
    }

    public void StartFilling()
    {
        backbar.SetActive(true);
        forwardbar.SetActive(true);
        isFilling = true;
    }

    public void StopFilling()
    {
        backbar.SetActive(false);
        forwardbar.SetActive(false);
        isFilling = false;
        image.fillAmount = 0f;
        fillAmount = 0f;

    }


    private void Update()
    {


        if (isFilling )
        {
            fillAmount += Time.deltaTime;
            image.fillAmount = fillAmount;

            if (fillAmount > fullTime) // 로딩바가 다 차면
            {
                isFilling = false;


                if (transform.parent.name == "Menu")//메뉴라면
                {
                    Chapter[System.Convert.ToInt32(transform.name) - 1].SetActive(true);
                    transform.parent.gameObject.SetActive(false);
                }
                else if (SceneManager.GetActiveScene().name[0] == 'C')//게임룸이라면(게임룸이 아니면 씬이름 첫글자에 C 붙이지말기
                    SceneManager.LoadScene("MainMenu");
                else//스테이지선택이라면
                {
                    if (transform.name == "Odyssey")//오디세이라면
                        SceneManager.LoadScene(transform.parent.name + " Odyssey");
                    else if (transform.name == "Back")//백이라면
                    {
                        transform.parent.parent.GetChild(0).gameObject.SetActive(true);
                        transform.parent.gameObject.SetActive(false);
                    }
                    else//스테이지라면
                        SceneManager.LoadScene(transform.parent.name + " Stage " + transform.name);
                }


            }

        }
        else
        {
            backbar.SetActive(false);
            forwardbar.SetActive(false);
            image.fillAmount = 0f;
            fillAmount = 0f;
        }

    }

}
