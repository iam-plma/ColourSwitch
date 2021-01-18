using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            LevelBuilder.Instance.TriggerSpawn();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "BasicPlatform")
        {
            LevelBuilder.Instance.amount--;
            LevelBuilder.Instance.TriggerSpawn();
            Destroy(collision.gameObject);
        }
            
        
    }
}
