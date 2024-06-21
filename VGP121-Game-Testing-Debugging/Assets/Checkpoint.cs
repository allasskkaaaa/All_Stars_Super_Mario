using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Transform checkpoint;

    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        GameManager.Instance.UpdateCheckpoint(checkpoint);
    }
}
