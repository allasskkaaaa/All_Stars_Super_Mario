using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaStomp : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Weak Point"))
        {
            
            Destroy(collision.gameObject.transform.parent.gameObject);
        }
    }

    private void Start()
    {
        
    }
}
