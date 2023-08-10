using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Line : MonoBehaviour
{
    // Start is called before the first frame update
    Pointer pointerVisualizerR;
    Pointer pointerVisualizerL;
    Pointer currentHand;
    internal LineRenderer lineRenderer;
    private bool isDrawing = false;
    private Vector3 prePos;
    private Vector3 prePosR;
    private Vector3 prePosL;
    public float minDistance = 0.1f;

    DrawGameController gameController;
    void Start()
    {
        if (pointerVisualizerR == null && pointerVisualizerL == null)
        {
            GameObject _gController = GameObject.FindGameObjectWithTag("RightHandAnchor") as GameObject;
            pointerVisualizerR = _gController.GetComponent<Pointer>();
            _gController = GameObject.FindGameObjectWithTag("LeftHandAnchor") as GameObject;
            pointerVisualizerL = _gController.GetComponent<Pointer>();
             _gController = GameObject.FindGameObjectWithTag("GameController") as GameObject;
            gameController = _gController.GetComponent<DrawGameController>();
        }
        lineRenderer = GetComponent<LineRenderer>();
        prePosR = pointerVisualizerR.linePointer.GetPosition(1);
        prePosL = pointerVisualizerL.linePointer.GetPosition(1);
        lineRenderer.positionCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.isStart && OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            isDrawing = true;
            prePos = pointerVisualizerR.linePointer.GetPosition(1);
            lineRenderer.positionCount = 0;
            currentHand = pointerVisualizerR;
        }
        if (gameController.isStart && OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            isDrawing = true;
            prePos = pointerVisualizerL.linePointer.GetPosition(1);
            lineRenderer.positionCount = 0;
            currentHand = pointerVisualizerL;
        }
        if (gameController.isStart && OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger))
        {
            isDrawing = false;
        }
        if (gameController.isStart && OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
            isDrawing = false;
        }
        if (isDrawing)
        {
            Vector3 curPos = currentHand.linePointer.GetPosition(1);
            curPos.z = 0.809f;
            if (Vector3.Distance(curPos, prePos) > minDistance)
            {
                lineRenderer.positionCount++;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, curPos);
                prePos = curPos;
            }
        }
    }
}
