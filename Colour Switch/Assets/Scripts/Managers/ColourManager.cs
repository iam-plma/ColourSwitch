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

    private bool currentBGColourIsBlue = false;
    private bool currentPlatformsColourIsOriginal = true;

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

        //currentBGColourIsBlue = !currentBGColourIsBlue;
        //UpdatePlatformColours();
        //Debug.Log(currentBGColourIsBlue + " " + currentPlatformsColourIsOriginal);
    }

    private void UpdatePlatformColours()
    {
        /*
        if (currentBGColourIsBlue && currentPlatformsColourIsOriginal)
        {
            yellowPlatforms.SetActive(true);
            bluePlatforms.SetActive(false);
        }
        else if (currentBGColourIsBlue && !currentPlatformsColourIsOriginal)
        {
            yellowPlatforms.SetActive(false);
            bluePlatforms.SetActive(true);
        }
        else if (!currentBGColourIsBlue && currentPlatformsColourIsOriginal)
        {
            yellowPlatforms.SetActive(false);
            bluePlatforms.SetActive(true);
        }
        else if (!currentBGColourIsBlue && !currentPlatformsColourIsOriginal)
        {
            yellowPlatforms.SetActive(true);
            bluePlatforms.SetActive(false);
        }
        */
    }

    public void SwitchPlatformsColour()
    {
        SpriteRenderer[] sr1 = yellowPlatforms.GetComponentsInChildren<SpriteRenderer>();
        SpriteRenderer[] sr2 = bluePlatforms.GetComponentsInChildren<SpriteRenderer>();

        changePlatformColours(sr1, sr2, currentPlatformsColourIsOriginal);

        currentPlatformsColourIsOriginal = !currentPlatformsColourIsOriginal;

        UpdatePlatformColours();

        Debug.Log(currentBGColourIsBlue + " " + currentPlatformsColourIsOriginal);
    }

    private void changePlatformColours(SpriteRenderer[] sr1, SpriteRenderer[] sr2, bool isDefault)
    {
        if(isDefault == true)
        {
            for (int i = 0; i < sr1.Length; i++)
            {
                sr1[i].sprite = bluePlatform; // blue
            }
            for (int i = 0; i < sr2.Length; i++)
            {
                sr2[i].sprite = yellowPlatform; // yellow
            }
        }
        else if(isDefault == false)
        {
            for (int i = 0; i < sr1.Length; i++)
            {
                sr1[i].sprite = yellowPlatform; // yellow
            }
            for (int i = 0; i < sr2.Length; i++)
            {
                sr2[i].sprite = bluePlatform; // blue
            }
        }
        
    }
}
