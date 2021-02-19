using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    public static ObjectPool SharedInstance;

    public List<GameObject> pooledObstacles;
    public List<GameObject> pooledCake;
    public GameObject obstacleToPool;
    public GameObject cakeToPool;
    public int amountToPool;

    void Awake() {
        SharedInstance = this;
    }

    void Start() {
        pooledObstacles = new List<GameObject>();
        pooledCake = new List<GameObject>();
        GameObject tmpObstacle;
        GameObject tmpCake;
        for(int i = 0; i < amountToPool; i++) {
            tmpObstacle = Instantiate(obstacleToPool);
            tmpObstacle.SetActive(false);
            pooledObstacles.Add(tmpObstacle);
            tmpCake = Instantiate(cakeToPool);
            tmpCake.SetActive(false);
            pooledCake.Add(tmpCake);
        }
    }

    public GameObject GetPooledObstacle() {
        for(int i = 0; i < amountToPool; i++) {
            if(pooledObstacles[i].activeInHierarchy == false) {
                return pooledObstacles[i];
            }
        }
        return null;
    }

    public GameObject GetPooledCake() {
        for(int i = 0; i < amountToPool; i++) {
            if(pooledCake[i].activeInHierarchy == false) {
                return pooledCake[i];
            }
        }
        return null;
    }

    void Update() { }
    
}
