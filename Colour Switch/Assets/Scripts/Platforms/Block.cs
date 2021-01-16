using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField]
    private float distance = 3.1f;

    private float minX;
    private float maxX;

    private float startingYPoint;
    public GameObject[] platforms;

    public void Spawn(float yPoint)
    {
        startingYPoint = yPoint;
        for (int i = 0; i < platforms.Length; i++)
        {
            Vector3 pos = new Vector3(0, startingYPoint + (distance * i), 0);
            Instantiate(platforms[i], pos, Quaternion.identity);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
