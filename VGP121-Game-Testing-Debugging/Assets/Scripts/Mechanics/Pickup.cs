using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public enum PickupType
    {
        RedMushroom,
        FireFlower,
        Score,
        Health
    }

    [SerializeField] private PickupType type;
    [SerializeField] private int scoreValue = 10; // Add this line to specify the score value for score pickups
    CanvasManager canvasManager;
    AudioManager audioManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController pc = collision.GetComponent<PlayerController>();
            audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

            switch (type)
            {
                case PickupType.RedMushroom:
                    audioManager.PlaySFX(audioManager.PowerUp);
                    pc.mushroomGet = true;
                    break;
                case PickupType.Score:
                    audioManager.PlaySFX(audioManager.Coin);
                    GameManager.Instance.score+= scoreValue;
                    Debug.Log("Score increased");
                    break;
                case PickupType.FireFlower:
                    audioManager.PlaySFX(audioManager.PowerUp);
                    pc.flowerGet = true;
                    break;
                case PickupType.Health:
                    GameManager.Instance.lives++;
                    break;
            }

            Destroy(gameObject);
        }
    }
}