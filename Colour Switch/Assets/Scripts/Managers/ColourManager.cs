using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourManager : MonoBehaviour
{
    private static ColourManager _instance;
    public static ColourManager Instance
    {
        get
        {
            if(_instance == null)
                Debug.LogError("Colour Manager is null");

            return _instance;
        }
    }

    public GameObject yellowPlatforms;
    public GameObject bluePlatforms;
    public Background background;

    private bool currentColour = false;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {

    }

    public void SwitchColour()
    {
        background.SwitchColour();
        if (!currentColour) // right now yellow , switch to blue
        {
            yellowPlatforms.SetActive(true);
            bluePlatforms.SetActive(false);
        }
        else if (currentColour)// right now blue, switch to yellow
        {
            bluePlatforms.SetActive(true);
            yellowPlatforms.SetActive(false);
        }

        currentColour = !currentColour;

    }
}
