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

    public virtual void Start()
    {
        edgeCollider = GetComponent<EdgeCollider2D>();
        platformEffector = GetComponent<PlatformEffector2D>();

        int chooseType = Random.Range(0, 2);
        if (chooseType == 0)
        {
            type = PlatformType.Pink;
            GetComponent<SpriteRenderer>().sprite = yellowSprite;
        }
        else if (chooseType == 1)
        {
            type = PlatformType.Blue;
            GetComponent<SpriteRenderer>().sprite = blueSprite;
        }

        rb = GetComponent<Rigidbody2D>();
        speed = Random.Range(minSpeed, maxSpeed);

        rb.velocity = new Vector2(speed, 0);
    }

    public virtual void Update()
    {
        if (transform.position.x <= minXPos)
            rb.velocity = new Vector2(speed, 0);
        else if (transform.position.x >= maxXPos)
            rb.velocity = new Vector2(-speed, 0);

        if(ColourManager.Instance.currentColor == type)
        {
            edgeCollider.enabled = false;
            platformEffector.enabled = false;
        }
        else if(ColourManager.Instance.currentColor != type)
        {
            edgeCollider.enabled = true;
            platformEffector.enabled = true;
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
            }
        }
    }
}
