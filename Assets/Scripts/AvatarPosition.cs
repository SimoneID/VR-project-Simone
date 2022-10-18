using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarPosition : MonoBehaviour
{
    float x;
    float y;
    float z;
    Vector3 pos;
    void Start()
    {
        x = Random.Range(-4.5f, 4.5f);
        y = 0.85f;
        z = -4.5f;
        pos = new Vector3(x, y, z);
        transform.position = pos;
    }
}
