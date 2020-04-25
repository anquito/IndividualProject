using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] fireballPrefabs;
    public Vector3[] spawnLocations;
    //public GameManager gameManager;
    private float startDelay = 1.0f;
    private float spawnIntervalMin = 0.25f;
    private float spawnIntervalMax = 1.0f;
    private float randomInterval;

    private GameManager gameM;
    //public bool isFinished;
    // Start is called before the first frame update
    void Start()
    {
        gameM = GameObject.Find("Game Manager").GetComponent<GameManager>();

        float randomInterval = (Random.Range(spawnIntervalMin, spawnIntervalMax));
        //if (gameM.isFinished == false)
        //{
        //    InvokeRepeating("SpawnRandomFireball", startDelay, randomInterval);
        //}

        //else if (gameM.isFinished == true)
        //{
        //    CancelInvoke("SpawnRandomFireball");
        //}
        //InvokeRepeating("SpawnRandomFireball", startDelay, randomInterval);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameM.isFinished == false)
        {
            InvokeRepeating("SpawnRandomFireball", startDelay, randomInterval);
        }

        if (gameM.isFinished == true)
        {
            CancelInvoke("SpawnRandomFireball");
        }
    }

    void SpawnRandomFireball()
    {
        int randomFireball = Random.Range(0, fireballPrefabs.Length);
        int randomLocation = Random.Range(0, spawnLocations.Length);

        // instantiate fireball at random spawn location
        Instantiate(fireballPrefabs[randomFireball], spawnLocations[randomLocation], fireballPrefabs[randomFireball].transform.rotation);
    }
}
