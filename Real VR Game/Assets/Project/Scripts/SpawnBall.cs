using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    public GameObject objToSpawn;
    Vector3 previousSpawnPosition;
    public bool ready = true;
    float spawnTime = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if (ready && (Time.time > spawnTime))
        {

            GameObject temp;
            temp = (GameObject)Instantiate(objToSpawn);
            Vector3 spawnPosition = GenerateSpawnPosition();
            temp.transform.position = spawnPosition;
            previousSpawnPosition = spawnPosition;

            ready = false;
        }
    }
    private Vector3 GenerateSpawnPosition()
    {
        Vector3 spawnPosition;
        do
        {
            spawnPosition = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(1.5f, 2.5f), Random.Range(0.5f, 0.5f));
        } while (Vector3.Distance(spawnPosition, previousSpawnPosition) < 0.1f);

        return spawnPosition;
    }
    public void setReady()
    {
        ready = true;
        spawnTime = Time.time + 0.5f;
    }
}
