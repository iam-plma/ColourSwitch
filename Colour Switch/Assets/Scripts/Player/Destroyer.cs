using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        LevelBuilder.Instance.TriggerSpawn();
        if (collision.gameObject.tag == "BasicPlatform")
            LevelBuilder.Instance.amount--;
        Destroy(collision.gameObject);
    }
}
