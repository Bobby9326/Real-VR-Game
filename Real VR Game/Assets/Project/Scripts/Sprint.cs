using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprint : MonoBehaviour
{
    public float speed = 100f;
    void Update()
    {
        transform.Rotate(speed * Time.deltaTime / 10, speed * Time.deltaTime * 2, speed * Time.deltaTime);
    }
}
