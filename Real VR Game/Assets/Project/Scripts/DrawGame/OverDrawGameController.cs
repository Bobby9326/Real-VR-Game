using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class OverDrawGameController : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMesh timeB, accuracyB;
    void Start()
    {
        timeB.text = "Your Time : " + String.Format("{0:0.00}", PlayerPrefs.GetFloat("nextClick"));
        accuracyB.text = "Accuracy : " + 0 + "%";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startGame()
    {
        SceneManager.LoadScene("DrawGame", LoadSceneMode.Single);
    }
}
