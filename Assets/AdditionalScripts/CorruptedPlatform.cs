using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorruptedPlatform : MonoBehaviour
{
    private void OnCollisionEnter (Collision collision)
    {
        Debug.Log("asduajsd");
        if (collision.gameObject.name == "Player")
            Destroy(gameObject, 1f);
    }
}
