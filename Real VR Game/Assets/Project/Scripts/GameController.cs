using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour

{

    public bool isStart = false;
    public bool isFinish = false;
    public int score = 0;
    public int time = 60;
    public GameObject startScene, playScene;
    public TextMesh scoreLB, timeLB;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        startScene.SetActive(true);
        playScene.SetActive(false);
        PlayerPrefs.SetFloat("nextClick", Time.time);

    }

    // Update is called once per frame
    void Update()
    {
        if (isStart)
        {
            startScene.SetActive(false);
            playScene.SetActive(true);
        }
        else
        {
            startScene.SetActive(true);
            playScene.SetActive(false);
        }
        scoreLB.text = "Score : " + score;
        timeLB.text = "Time : " + String.Format("{0:0.00}", timer-Time.time);

        if (Time.time > timer && isStart)
        {
            isFinish = true;
        }

        if (isFinish)
        {
            StartCoroutine(ReSetLevel());
            
        }
        
    }
    IEnumerator ReSetLevel()
    {
        yield return new WaitForSeconds(0.1f);
        PlayerPrefs.SetInt("score", score);
        if (PlayerPrefs.HasKey("bestScore"))
        {
            if(PlayerPrefs.GetInt("bestScore") < score)
            {
                PlayerPrefs.SetInt("bestScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("bestScore", score);
        }
        isStart = false;
        isFinish = false;
        SceneManager.LoadScene("OverEasyScene",LoadSceneMode.Single);

    }
    public void getTriggerStart()
    {
        if (!isStart)
        {
            timer = time + Time.time;
        }
        isStart = true;
        
    }
    public void getScore()
    {
        score += 1;
    }
}
