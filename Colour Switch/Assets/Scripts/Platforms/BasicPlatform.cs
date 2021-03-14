using UnityEngine;

public class BasicPlatform : Platform
{
    private bool scoreClaimed = false;

    public override void Start()
    {
        
    }

    public override void Update()
    {
        
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);

        if(collision.gameObject.tag == "Player")
        {
            if (!scoreClaimed)
            {
                if (collision.relativeVelocity.y <= 0f)
                {
                    GameManager.Instance.UpdateScoreText();
                    scoreClaimed = true;
                    AudioManager.Instance.Play("BasicPlatform");
                }
                    
            }
        }
    }
}
