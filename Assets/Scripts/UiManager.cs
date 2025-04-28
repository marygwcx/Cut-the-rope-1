using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    public Image[] stars;
    public Sprite starOn;

    private int index = 0;
    
    private void Awake()
    {
        if (instance == null) instance = this;
        else gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddStar()
    {
        stars[index++].sprite = starOn;
    }
}
