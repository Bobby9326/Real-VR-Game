using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawGameTriggerStart : MonoBehaviour
{
    // Start is called before the first frame update
    public float clickRate = 1.0f;
    public float nextClick = 0.0f;

    DrawGameController gameController;
    void Start()
    {
        if (gameController == null)
        {
            GameObject _gController = GameObject.FindGameObjectWithTag("GameController") as GameObject;
            gameController = _gController.GetComponent<DrawGameController>();
        }

        nextClick = PlayerPrefs.GetFloat("nextClick");
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameController.isStart && OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) && Time.time > nextClick)
        {
            nextClick = Time.time + clickRate;
            PlayerPrefs.SetFloat("nextClick", nextClick);
            gameController.getTriggerStart();
        }

        if (!gameController.isStart && OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) && Time.time > nextClick)
        {
            nextClick = Time.time + clickRate;
            PlayerPrefs.SetFloat("nextClick", nextClick);
            gameController.getTriggerStart();
        }
        if (OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger) && Time.time > nextClick && gameController.isStart)
        {
            Debug.Log("Insert1");
            nextClick = Time.time + clickRate;
            PlayerPrefs.SetFloat("nextClick", nextClick);
            gameController.getObject();
        }

        if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger) && Time.time > nextClick && gameController.isStart)
        {
            Debug.Log("Insert2");
            nextClick = Time.time + clickRate;
            PlayerPrefs.SetFloat("nextClick", nextClick);
            gameController.getObject();
        }
    }
}
