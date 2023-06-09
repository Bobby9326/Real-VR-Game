using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using OVR;
using UnityEngine.SocialPlatforms.Impl;

public class TriggerStart : MonoBehaviour

{
    public float clickRate = 1.0f;
    public float nextClick = 0.0f;

    GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        if (gameController == null)
        {
            GameObject _gController = GameObject.FindGameObjectWithTag("GameController") as GameObject;
            gameController = _gController.GetComponent<GameController>();
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
            gameController.getTriggerStart();
        }

        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) && Time.time > nextClick)
        {
            nextClick = Time.time + clickRate;
            PlayerPrefs.SetFloat("nextClick", nextClick);
            gameController.getTriggerStart();
        }
    }
}
