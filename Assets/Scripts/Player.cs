using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    private PlayerStats _playerStats;

    public float movementSpeed;
    public Score score;

    void Start() { }

    void Update() {
        if(Input.GetKey(KeyCode.LeftArrow)) {
            transform.position += Vector3.left * movementSpeed * Time.deltaTime;
        } else if(Input.GetKey(KeyCode.RightArrow)) {
            transform.position += Vector3.right * movementSpeed * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.tag == "Obstacle") {
            score.CalculateHighScore();
            score.ResetCakes();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        } else if(collider.gameObject.tag == "Cake") {
            score.AddCakeToScore();
        }
    }

}
