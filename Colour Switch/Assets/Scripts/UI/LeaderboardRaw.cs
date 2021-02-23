using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardRaw : MonoBehaviour
{
    void Update()
    {
        if (gameObject.transform.position.y < -2046)
            Destroy(gameObject);
    }
}
