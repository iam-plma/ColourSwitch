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
        SceneManager.LoadScene(2);
    }
}
