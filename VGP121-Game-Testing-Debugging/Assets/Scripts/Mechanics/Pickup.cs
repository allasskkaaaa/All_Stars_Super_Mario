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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController pc = collision.GetComponent<PlayerController>();

            switch (type)
            {
                case PickupType.RedMushroom:
                    pc.mushroomGet = true;
                    break;
                case PickupType.Score:
                    //Increase Score
                    break;
                case PickupType.FireFlower:
                    // Handle FireFlower pickup
                    pc.flowerGet = true;
                    break;
                case PickupType.Health:
                    GameManager.instance.lives++;
                    break;
            }

            Destroy(gameObject);
        }
    }
}