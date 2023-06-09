using System.Collections;
using System.Collections.Generic;
using Oculus.Platform;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class OverController : MonoBehaviour
{
    public TextMesh scoreLB,bestScoreLB;

    void Start()
    {
        scoreLB.text = "Your Score : " + PlayerPrefs.GetInt("score");
        bestScoreLB.text = "Best Score : " + PlayerPrefs.GetInt("bestScore");
    }

    // Update is called once per frame
    public void startGame()
    {
        SceneManager.LoadScene("EasyMode", LoadSceneMode.Single);
    }
}
