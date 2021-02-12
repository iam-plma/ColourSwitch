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

    [HideInInspector]
    public PlatformType currentColor = PlatformType.Pink;

    public GameObject yellowPlatforms;
    public GameObject bluePlatforms;
    public Sprite yellowPlatform;
    public Sprite bluePlatform;
    public Background background;

    private void Awake()
    {
        _instance = this;
    }

    public void SwitchBGColour()
    {
        if (currentColor == PlatformType.Pink)
            currentColor = PlatformType.Blue;
        else if (currentColor == PlatformType.Blue)
            currentColor = PlatformType.Pink;

        background.SwitchColour();
    }
}
