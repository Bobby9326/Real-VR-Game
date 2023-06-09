using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 position;

    [ContextMenu("Reset Position")]

    public void ResetPosition()
    {

        transform.position = position;
    } 
}
