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

    public bool playerAlive = true;

    private void Awake()
    {
        _instance = this;
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
        deathMenu.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
