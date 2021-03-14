using UnityEngine;

public class Background : MonoBehaviour
{
    private SpriteRenderer sprite;

    [SerializeField]
    private Sprite blueBG;
    [SerializeField]
    private Sprite pinkBG;

    private bool currentColour = false;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>(); 
    }

    public void SwitchColour()
    {
        if (currentColour == false)// right now pink, switch to blue
        {
            sprite.sprite = blueBG;
            currentColour = true;
        }
        else if (currentColour == true)// right now blue, switch to pink
        {
            sprite.sprite = pinkBG;
            currentColour = false;
        }
    }
}
