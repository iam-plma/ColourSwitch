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
            Color color = new Color(0f, 255.0f, 223.0f); // blue
            sprite.sprite = blueBG;
            currentColour = true;
        }
        else if (currentColour == true)// right now blue, switch to yellow
        {
            Color color = new Color(254.0f, 255.0f, 0f);
            sprite.sprite = yellowBG;
            currentColour = false;
        }
    }
}
