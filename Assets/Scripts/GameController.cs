using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public float spawnTimer = 2;
    public float spawnTimeCounter = 1;

    void Start() { }

    void Update()
    {
        spawnTimeCounter -= Time.deltaTime;
        if(spawnTimeCounter <= 0) {
            GameObject obstacle = ObjectPool.SharedInstance.GetPooledObject();
            if(obstacle != null) {
                // float randomPositionX = Random.Range(-9.0f, 9.0f);
                // float randomScaleX = Random.Range(2.0f, 6.0f);
                // obstacle.transform.position = new Vector3(randomPositionX, 5.0f, 0);
                // obstacle.transform.localScale = new Vector3(randomScaleX, 0.5f, 0);
                obstacle.SetActive(true);
            }
            spawnTimeCounter = spawnTimer;
        }
    }
}
