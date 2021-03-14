using UnityEngine;
using UnityEngine.SceneManagement;
using Managers;

namespace UI
{
    public class TapToPlay : MonoBehaviour
    {
        private void Start()
        {
            if (AudioManager.Instance.mainMusicPlaying)
                AudioManager.Instance.Play("MainTheme");
        }
        public void StartGame()
        {
            ScoreManager.Instance.ResetScore();
            SceneManager.LoadScene(2);
        }
    }
}
