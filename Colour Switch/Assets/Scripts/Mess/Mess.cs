﻿using System.Collections;
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
        if (GameManager.Instance.playerAlive)
        {
            if (player.GetComponent<Player>().samePlatformJumpCounter > 2)
            {
                rb.velocity = new Vector2(0, speed);
            }
            else
            {
                rb.velocity = new Vector2(0, 0);
            }
        }
        
        //Debug.Log(gameObject.GetComponent<Transform>().position.y + "       " + Camera.main.transform.position.y);
        if (gameObject.GetComponent<Transform>().position.y >= Camera.main.transform.position.y)
        {
            GameManager.Instance.instansiateDeathMenu();
            rb.velocity = new Vector2(0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.Instance.playerAlive = false;
            endGame();
            Destroy(collision.gameObject);
        }
    }

    private void endGame()
    {
        rb.velocity = new Vector2(0, speed*2);
        
    }

}