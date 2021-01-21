using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mess : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 1.5f;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if(player.GetComponent<Player>().samePlatformJumpCounter > 2)
        {
            rb.velocity = new Vector2(0, speed);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            playerDeath();
        }
    }

    private void playerDeath()
    {
            
    }

}
