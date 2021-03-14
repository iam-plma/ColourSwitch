using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    [SerializeField]
    private float time = 4.3f;

    void Start()
    {
        StartCoroutine(WaitToStart());
        StartCoroutine(WaitToSwitchOn());
    }

    private IEnumerator WaitToStart()
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(1);
    }

    private IEnumerator WaitToSwitchOn()
    {
        yield return new WaitForSeconds(2.3f);
        AudioManager.Instance.Play("IntroSwitch");
    }

}
