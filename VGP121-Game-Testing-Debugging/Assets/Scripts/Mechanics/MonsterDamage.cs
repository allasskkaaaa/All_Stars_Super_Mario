using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDamage : MonoBehaviour
{
    AudioManager audioManager;
    public int damage;

    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            audioManager.PlaySFX(audioManager.damage);
            GameManager.Instance.lives -= damage;
            GameManager.Instance.PlayerInstance.cleanse();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            audioManager.PlaySFX(audioManager.EnemyDeath);
            GameManager.Instance.lives -= damage;
            GameManager.Instance.PlayerInstance.cleanse();
        }
    }
}
