using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Realms;

public class Score : MonoBehaviour {

    private Realm _realm;
    private PlayerStats _playerStats;

    public Text highScoreText;
    public Text currentScoreText;
    public Text cakeText;

    void Start() {
        _realm = Realm.GetInstance();
        _playerStats = _realm.Find<PlayerStats>("nraboy");
        if(_playerStats is null) {
            _realm.Write(() => {
                _playerStats = _realm.Find<PlayerStats>("nraboy");
                if(_playerStats is null) {
                    _playerStats = _realm.Add(new PlayerStats("nraboy"));
                }
            });
        }
        highScoreText.text = "HIGH SCORE: " + _playerStats.Score.ToString();
    }

    void OnDisable() {
        _realm.Dispose();
    }

    void Update() {
        currentScoreText.text = "SCORE: " + (Mathf.Floor(Time.timeSinceLevelLoad) + _playerStats.Cake).ToString();
        cakeText.text = "CAKE: " + _playerStats.Cake.ToString();
    }

    public void CalculateHighScore() {
        if(_playerStats.Score < (int)(Mathf.Floor(Time.timeSinceLevelLoad) + _playerStats.Cake)) {
            _realm.Write(() => {
                _playerStats.Score = (int)(Mathf.Floor(Time.timeSinceLevelLoad) + _playerStats.Cake);
            });
        }
    }

    public void AddCakeToScore() {
        _realm.Write(() => {
            _playerStats.Cake.Increment(1);
        });
    }

    public void ResetCakes() {
        _realm.Write(() => {
            _playerStats.Cake = 0;
        });
    }

}
