using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField]
    protected float jumpForce = 10f;

    private float minSpeed = 1.0f;
    private float maxSpeed = 4.0f;
    private float speed;

    private float minXPos = -2.35f;
    private float maxXPos = 2.35f;

    private Rigidbody2D rb;

    public PlatformType type;
    [SerializeField]
    private Sprite yellowSprite;
    [SerializeField]
    private Sprite blueSprite;

    private EdgeCollider2D edgeCollider;
    private PlatformEffector2D platformEffector;

    private Animator anim;

    public virtual void Start()
    {
        anim = GetComponent<Animator>();
        edgeCollider = GetComponent<EdgeCollider2D>();
        platformEffector = GetComponent<PlatformEffector2D>();

        int chooseType = Random.Range(0, 2);
        if (chooseType == 0)
        {
            type = PlatformType.Pink;
            Color color = GetComponent<SpriteRenderer>().color;
            GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 0);
            GetComponent<SpriteRenderer>().sprite = yellowSprite;         
        }
        else if (chooseType == 1)
        {
            type = PlatformType.Blue;
            Color color = GetComponent<SpriteRenderer>().color;
            GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 0);
            GetComponent<SpriteRenderer>().sprite = blueSprite;
        }

        rb = GetComponent<Rigidbody2D>();
        speed = Random.Range(minSpeed, maxSpeed);

        rb.velocity = new Vector2(speed, 0);
    }

    public virtual void Update()
    {
        if (transform.position.x <= minXPos)
        {
            float newSpeed = speed;
            rb.velocity = new Vector2(newSpeed, 0);
        }
        else if (transform.position.x >= maxXPos)
        {
            float newSpeed = -speed;
            rb.velocity = new Vector2(newSpeed, 0);
        }
        

        if(ColourManager.Instance.currentColor == type)
        {
            anim.SetTrigger("TriggerFadeOut");
            edgeCollider.enabled = false;
            platformEffector.enabled = false;
        }
        else if(ColourManager.Instance.currentColor != type)
        {
            anim.SetTrigger("TriggerFadeIn");
            edgeCollider.enabled = true;
            platformEffector.enabled = true;
        }
        
        if(GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>().position.y -
            GetComponent<Transform>().position.y >= 25)
        {
            Destroy(gameObject);
        }
    }

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (collision.relativeVelocity.y <= 0f)
            {
                Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    Vector2 velocity = rb.velocity;
                    velocity.y = jumpForce;
                    rb.velocity = velocity;
                }

                if (collision.gameObject.GetComponent<Player>().colliderObj == null)
                {
                    collision.gameObject.GetComponent<Player>().colliderObj = gameObject;
                    return;
                }


                if (gameObject == collision.gameObject.GetComponent<Player>().colliderObj)
                {
                    collision.gameObject.GetComponent<Player>().samePlatformJumpCounter++;
                }
                else if (gameObject != collision.gameObject.GetComponent<Player>().colliderObj)
                {
                    collision.gameObject.GetComponent<Player>().samePlatformJumpCounter = 1;
                }

                collision.gameObject.GetComponent<Player>().colliderObj = gameObject;
            }

            
        }
    }
}
