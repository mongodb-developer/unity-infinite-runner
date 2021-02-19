using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Realms;

public class Score : MonoBehaviour
{

    private Realm _realm;
    private PlayerStats _playerStats;

    public Text highScoreText;
    public Text currentScoreText;

    void Start()
    {
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
        Debug.Log(_playerStats);
        highScoreText.text = "HIGH SCORE: " + _playerStats.Score.ToString();
    }

    void OnDisable() {
        _realm.Dispose();
    }

    void Update()
    {
        currentScoreText.text = "SCORE: " + Mathf.Floor(Time.timeSinceLevelLoad).ToString();
    }

    public void CalculateHighScore() {
        if(_playerStats.Score < (int)Mathf.Floor(Time.timeSinceLevelLoad)) {
            _realm.Write(() => {
                _playerStats.Score = (int)Mathf.Floor(Time.timeSinceLevelLoad);
            });
        }
    }

}
