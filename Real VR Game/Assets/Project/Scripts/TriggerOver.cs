using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using OVR;

public class TriggerOver : MonoBehaviour
{
    public float clickRate = 1.0f;
    public float nextClick = 0.0f;

    OverDrawGameController overController;
    // Start is called before the first frame update
    void Start()
    {
        if (overController == null)
        {
            GameObject _gController = GameObject.FindGameObjectWithTag("GameController") as GameObject;
            overController = _gController.GetComponent<OverDrawGameController>();
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
            overController.startGame();
        }

        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) && Time.time > nextClick)
        {
            nextClick = Time.time + clickRate;
            PlayerPrefs.SetFloat("nextClick", nextClick);
            overController.startGame();
        }
    }
}
