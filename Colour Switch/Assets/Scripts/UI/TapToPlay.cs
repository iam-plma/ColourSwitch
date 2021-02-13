using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TapToPlay : MonoBehaviour
{
    private void Start()
    {
        AudioManager.Instance.Play("MainTheme");
    }
    public void StartGame()
    {
        ScoreManager.Instance.score = 0;
        SceneManager.LoadScene(2);
    }
}
