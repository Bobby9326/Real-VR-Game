using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using Random = UnityEngine.Random;

public class DrawGameController : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isStart = false;
    public int time = 0;
    public GameObject startScene, playScene;
    public GameObject[] boards;
    Line line;
    float timer;
    void Start()
    {
        startScene.SetActive(true);
        playScene.SetActive(false);
        PlayerPrefs.SetFloat("nextClick", Time.time);
        GameObject _gController = GameObject.FindGameObjectWithTag("Line");
        line = _gController.GetComponent<Line>();
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
    }

    public void getTriggerStart()
    {
        isStart = true;
    }

    public void getObject()
    {
        GameObject board = GameObject.FindWithTag("Board");
        Destroy(board);
        int idx = Random.Range(0, boards.Length);
        Instantiate(boards[idx]);
        line.lineRenderer.positionCount = 0;
    }
}
