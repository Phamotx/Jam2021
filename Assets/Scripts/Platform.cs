using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    public float FallSpeed = 0;       
    
    private void Update()
    {
        transform.Translate(Vector3.down * FallSpeed * Time.deltaTime);    
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag("Bottom"))
        {
            gameObject.SetActive(false);
        }
    }
}
