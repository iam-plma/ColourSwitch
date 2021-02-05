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
        if (_instance == null)
            _instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        if (highScore != null)
            highScore.text = "High Score: " + PlayerPrefs.GetInt("high_score", 0);
    }
    
    public void StartGame()
    {
        Debug.Log("StartGame()");
        AudioManager.Instance.Play("Switch");
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
        AudioManager.Instance.Stop("MainTheme");
        AudioManager.Instance.Play("SecondaryTheme");
        deathMenu.SetActive(true);  
        deathMenu.GetComponentInChildren<Text>().text = "Score: " + score;
        highScore.text = "High Score: " + PlayerPrefs.GetInt("high_score", 0);
        PlayfabManager.Instance.SendLeaderboard(PlayerPrefs.GetInt("high_score", 0));
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
        AudioManager.Instance.Play("MainTheme");
        AudioManager.Instance.Play("Switch");
        AudioManager.Instance.Stop("SecondaryTheme");
    }

    public void LoadLeaderboard()
    {
        
        SceneManager.LoadScene(2);
        AudioManager.Instance.Play("Switch");
    }
}
