using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preview : MonoBehaviour
{
    private bool inCollision;

    void Start()
    {
        inCollision = false;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        inCollision = true;
    }

    public bool GetCollision()
    {
        return inCollision;
    }
}
