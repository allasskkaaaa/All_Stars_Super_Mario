using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaStomp : MonoBehaviour
{
    AudioManager audioManager;
    EnemyController enemyController;

    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        enemyController = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyController>();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (collision.gameObject.CompareTag("Weak Point"))
        {
            audioManager.PlaySFX(audioManager.EnemyDeath);
            enemyController.isDead = true;
            Destroy(collision.gameObject.transform.parent.gameObject);
        }
    }
}
