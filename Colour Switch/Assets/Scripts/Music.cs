using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Managers;

public class Music : MonoBehaviour
{
    [SerializeField]
    private Sprite musicOnBlack;
    [SerializeField]
    private Sprite musicOffBlack;
    [SerializeField]
    private Sprite musicOnWhite;
    [SerializeField]
    private Sprite musicOffWhite;

    void Start()
    {
        DontDestroyOnLoad(gameObject.transform.parent);
    }

    private void Update()
    {
        bool mainMusicOn = AudioManager.Instance.mainMusicPlaying;
        bool secondaryMusicOn = AudioManager.Instance.secondaryMusicPlaying;

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (mainMusicOn)
            {
                GetComponent<Image>().sprite = musicOnBlack;
            }
            else if (!mainMusicOn)
            {
                GetComponent<Image>().sprite = musicOffBlack;
            }
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (mainMusicOn)
            {
                GetComponent<Image>().sprite = musicOnBlack;
            }
            else if (!mainMusicOn)
            {
                GetComponent<Image>().sprite = musicOffBlack;
            }
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            if (secondaryMusicOn)
            {
                GetComponent<Image>().sprite = musicOnWhite;
            }
            else if (!secondaryMusicOn)
            {
                GetComponent<Image>().sprite = musicOffWhite;
            }
        }           
    }

    public void StopMusic()
    {
        AudioManager.Instance.StopMusic();
        
        Debug.Log("stopMusic");    
    }
}
