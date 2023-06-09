using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TouchBall : MonoBehaviour
{

    public GameObject objToSpawn;
    GameController gameController;
    void Start()
    {
        if (gameController == null)
        {
            GameObject _gController = GameObject.FindGameObjectWithTag("GameController") as GameObject;
            gameController = _gController.GetComponent<GameController>();
        }
    }
    private void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.tag.Equals("Ball"))
        {
            
            Instantiate(objToSpawn, new Vector3(Random.Range(-0.5f, 0.5f),Random.Range(1.5f, 2.5f), Random.Range(0.5f, 0.5f)), new Quaternion());
            gameController.getScore();
            Destroy(obj.gameObject);
            
        }
    }
}
