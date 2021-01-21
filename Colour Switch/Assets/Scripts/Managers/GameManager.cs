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

    [HideInInspector]
    public bool gameStarted = false;

    public Animator tapToPlayAnim;
    public Animator cameraAnim;

    private void Awake()
    {

        _instance = this;
        Time.timeScale = 0;
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        gameStarted = true;
        GameObject.FindGameObjectWithTag("TapToPlay").SetActive(false);
    }

    public void UpdateScoreText()
    {
        score++;
        scoreText.text = "" + score;
    }


}
