using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeSpanwer : MonoBehaviour
{
    public GameObject tubePair;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;

    public float spawnRange = 3f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnDelay);
    }

    public void Spawn()
    {
        //print("spawn new");
        Vector3 randomPos = new Vector3(transform.position.x,
                                        Random.Range(0, spawnRange),
                                        transform.position.z);
        Instantiate(tubePair, randomPos, transform.rotation);
        if (stopSpawning)
        {
            CancelInvoke("Spawn");
        }
    }
}
