using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.Log("Game Manager is null");

            return _instance;
        }
    }

    public int score = 0;
    public Text scoreText;

    private void Awake()
    {
        _instance = this;
    }

    public void UpdateScoreText()
    {
        score++;
        scoreText.text = "" + score;
    }


}
