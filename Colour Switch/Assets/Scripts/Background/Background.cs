using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private SpriteRenderer sprite;

    [SerializeField]
    private Sprite blueBG;
    [SerializeField]
    private Sprite yellowBG;

    private bool currentColour = false;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>(); 
    }

    public void SwitchColour()
    {
        if (currentColour == false)// right now yellow, switch to blue
        {
            sprite.sprite = blueBG;
            currentColour = true;
        }
        else if (currentColour == true)// right now blue, switch to yellow
        {
            sprite.sprite = yellowBG;
            currentColour = false;
        }
    }
}
