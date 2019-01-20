﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StarManager : MonoBehaviour
{

    Text text;

    int chapter;

    public Text starText;
    public GameObject clearText;
    public GameObject clearEffect;

    public static int starCount = 0;
    public static int starFullCount;
    public static bool isClear = false;


    public static void GetStar(GameObject star, GameObject starEffect)
    {
        starCount++;
        Instantiate(starEffect, star.transform.position, Quaternion.identity);
        Destroy(star);
        Destroy(starEffect, 1f);

        if (starCount == starFullCount)
        {
            isClear = true;
        }
    }


    void backtoMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Start is called before the first frame update
    void Start()
    {
        text = starText.GetComponent<Text>();

        clearText.SetActive(false);
        clearEffect.SetActive(false);

        chapter = SceneManager.GetActiveScene().name[2] - '0';

        starFullCount = chapter * 2 + 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (isClear)
        {
            clearText.SetActive(true);
            clearEffect.SetActive(true);
            Invoke("backtoMenu", 5f);
            isClear = false;
        }


        text.text = starCount + " / " + starFullCount;
    }
}
