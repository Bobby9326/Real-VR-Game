using System.Collections;
using System.Collections.Generic;

using System;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    [Tooltip("Object which points with Z axis. E.g. CentreEyeAnchor from OVRCameraRig")]
    public Transform rayTransform;

    [Header("Visual Elements")]
    [Tooltip("Line Renderer used to draw selection ray.")]
    public LineRenderer linePointer = null;

    [Tooltip("Visually, how far out should the ray be drawn.")]
    public float rayDrawDistance = 2.5f;

    void Update()
    {
        linePointer.enabled = (OVRInput.GetActiveController() == OVRInput.Controller.Touch);
        Ray ray = new Ray(rayTransform.position, rayTransform.forward);
        linePointer.SetPosition(0, ray.origin);
        linePointer.SetPosition(1, CalculateEnd());
    }

    private Vector3 DefaultDistance()
    {
        return rayTransform.position + (rayTransform.forward * rayDrawDistance);
    }

    private Vector3 CalculateEnd()
    {
        RaycastHit hit = CreateForwardRayCast();
        Vector3 endPos = DefaultDistance();

        if (hit.collider != null)
        {
            endPos = hit.point;
        }

        return endPos;
    }

    private RaycastHit CreateForwardRayCast()
    {
        RaycastHit hit;
        Ray ray = new Ray(rayTransform.position, rayTransform.forward);

        Physics.Raycast(ray, out hit, rayDrawDistance);
        return hit;
    }
}
