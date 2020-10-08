using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public void randomize()
    {
        float x = Random.Range(-5, 5);
        gameObject.transform.position = new Vector2(0, -1.4f);
        gameObject.transform.Translate(x, 0, 0);
    }
}
