using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToPlay : MonoBehaviour
{
    public void Destroy()
    {
        gameObject.SetActive(false);
    }
}
