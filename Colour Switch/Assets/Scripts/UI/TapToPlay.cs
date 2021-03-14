using UnityEngine;
using UnityEngine.SceneManagement;

public class TapToPlay : MonoBehaviour
{
    private void Start()
    {
        if(AudioManager.Instance.mainMusicPlaying)
            AudioManager.Instance.Play("MainTheme");
    }
    public void StartGame()
    {
        ScoreManager.Instance.ResetScore();
        SceneManager.LoadScene(2);
    }
}
