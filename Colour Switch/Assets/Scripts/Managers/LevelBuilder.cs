using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    private static LevelBuilder _instance;
    public static LevelBuilder Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("LevelBuilder is null");

            return _instance;
        }
    }

    [SerializeField]
    private GameObject block;
    private float yToAdd = 12.4f;
    private int count = 0;

    private void Awake()
    {
        _instance = this;
    }

    public void TriggerSpawn()
    {
        count++;
        float start = count * yToAdd - 3.1f; // count + distance between plats - (some number for property start)
        Vector3 pos = new Vector3(0, start, 0);
        GameObject tempBlock = Instantiate(block, pos, Quaternion.identity);
        tempBlock.GetComponent<Block>().Spawn(start);
    }
    

}
