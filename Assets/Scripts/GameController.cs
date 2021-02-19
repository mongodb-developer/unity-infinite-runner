using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public float obstacleTimer = 2;
    public float timeUntilObstacle = 1;
    public float cakeTimer = 1;
    public float timeUntilCake = 1;

    void Start() { }

    void Update()
    {
        timeUntilObstacle -= Time.deltaTime;
        timeUntilCake -= Time.deltaTime;
        if(timeUntilObstacle <= 0) {
            GameObject obstacle = ObjectPool.SharedInstance.GetPooledObstacle();
            if(obstacle != null) {
                obstacle.SetActive(true);
            }
            timeUntilObstacle = obstacleTimer;
        }
        if(timeUntilCake <= 0) {
            GameObject cake = ObjectPool.SharedInstance.GetPooledCake();
            if(cake != null) {
                cake.SetActive(true);
            }
            timeUntilCake = cakeTimer;
        }
    }
}
