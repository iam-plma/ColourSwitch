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

    public Text scoreText;

    [SerializeField]
    private Animator cameraAnim;
    [SerializeField]
    private Animator tapToPlayAnim;
    [SerializeField]
    private Animator highScoreAnim;
    [SerializeField]
    private GameObject deathMenu;
    [SerializeField]
    private Text highScore;
    [SerializeField]
    private GameObject ToLeaderboardTransition;

    public bool playerAlive = true;

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        

        if (highScore != null)
            highScore.text = "High Score: " + PlayerPrefs.GetInt("high_score", 0);
    }
    
    public void StartGame()
    {
        Debug.Log("StartGame()");
        AudioManager.Instance.Play("Switch");
        cameraAnim.SetTrigger("SetPosition");
        highScoreAnim.SetTrigger("SetPosition");
        tapToPlayAnim.SetTrigger("SetPosition");
        
    }
     
    public void UpdateScoreText()
    {
        ScoreManager.Instance.AddScore();
        scoreText.text = "" + ScoreManager.Instance.score;
    }

    public void instansiateDeathMenu()
    {
        if (PlayerPrefs.GetInt("high_score") < ScoreManager.Instance.score)
        {
            PlayerPrefs.SetInt("high_score", ScoreManager.Instance.score);
        }
        AudioManager.Instance.Stop("MainTheme");
        AudioManager.Instance.Play("SecondaryTheme");
        deathMenu.SetActive(true);  
        deathMenu.GetComponentInChildren<Text>().text = "Score: " + ScoreManager.Instance.score;
        highScore.text = "High Score: " + PlayerPrefs.GetInt("high_score", 0);
        PlayfabManager.Instance.SendLeaderboard(PlayerPrefs.GetInt("high_score", 0));

        foreach(GameObject p in GameObject.FindGameObjectsWithTag("Platform"))
        {
            p.GetComponent<Animator>().SetTrigger("TriggerFadeOut");
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
        AudioManager.Instance.Play("MainTheme");
        AudioManager.Instance.Play("Switch");
        AudioManager.Instance.Stop("SecondaryTheme");
    }

    public void LoadLeaderboard()
    {
        ToLeaderboardTransition.SetActive(true);
        AudioManager.Instance.Play("Switch");
        StartCoroutine(WaitOneSec(3));
    }

    private IEnumerator WaitOneSec(int scene)
    {
        yield return new WaitForSeconds(1);
        if(scene == 1)
            AudioManager.Instance.Play("MainTheme");
        SceneManager.LoadScene(scene);
    }

    public void Reborn()
    {
        AudioManager.Instance.Stop("SecondaryTheme");
        AudioManager.Instance.Play("Switch");
        GameObject.FindGameObjectWithTag("AdsManager").GetComponent<AdsManager>().ShowRewardedAd();
        ToLeaderboardTransition.SetActive(true);
        StartCoroutine(WaitOneSec(2));
    }
}
