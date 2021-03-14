using UnityEngine;

public class LeaderboardRaw : MonoBehaviour
{
    void Update()
    {
        if (gameObject.transform.position.y < -2046)
            Destroy(gameObject);
    }
}
