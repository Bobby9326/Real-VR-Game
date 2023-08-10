using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawGameTriggerOver : MonoBehaviour
{
    // Start is called before the first frame update
    public float clickRate = 1.0f;
    public float nextClick = 0.0f;

    OverDrawGameController gameController;
    void Start()
    {
        if (gameController == null)
        {
            GameObject _gController = GameObject.FindGameObjectWithTag("GameController") as GameObject;
            gameController = _gController.GetComponent<OverDrawGameController>();
        }

        nextClick = PlayerPrefs.GetFloat("nextClick");
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) && Time.time > nextClick)
        {
            nextClick = Time.time + clickRate;
            PlayerPrefs.SetFloat("nextClick", nextClick);
            gameController.startGame();
        }

        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) && Time.time > nextClick)
        {
            nextClick = Time.time + clickRate;
            PlayerPrefs.SetFloat("nextClick", nextClick);
            gameController.startGame();
        }
    }
}
