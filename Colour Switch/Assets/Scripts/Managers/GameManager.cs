using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    [SerializeField]
    private Animator cameraAnim;
    [SerializeField]
    private Animator tapToPlayAnim;
    [SerializeField]
    private GameObject deathMenu;
    [SerializeField]
    private Text highScore;

    public bool playerAlive = true;

    private void Awake()
    {
        _instance = this;
        highScore.text = "High Score: " + PlayerPrefs.GetInt("high_score", 0);
    }

    public void StartGame()
    {
        Debug.Log("StartGame()");
        cameraAnim.SetTrigger("SetPosition");
        tapToPlayAnim.SetTrigger("SetPosition");

        
        
    }

    public void UpdateScoreText()
    {
        score++;
        scoreText.text = "" + score;
    }

    public void instansiateDeathMenu()
    {
        if (PlayerPrefs.GetInt("high_score") < score)
        {
            PlayerPrefs.SetInt("high_score", score);
        }
        deathMenu.SetActive(true);   
        deathMenu.GetComponentInChildren<Text>().text = "Score: " + score;
        highScore.text = "High Score: " + PlayerPrefs.GetInt("high_score", 0);
        PlayfabManager.Instance.SendLeaderboard(PlayerPrefs.GetInt("high_score", 0));
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);

    }
}
