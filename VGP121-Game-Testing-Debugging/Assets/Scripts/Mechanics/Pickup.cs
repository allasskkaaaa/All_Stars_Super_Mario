using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public enum PickupType
    {
        RedMushroom,
        FireFlower,
        Score
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
                    // Handle RedMushroom pickup
                    break;
                case PickupType.Score:
                    ScoreManager.Instance.AddScore(scoreValue);
                    break;
                case PickupType.FireFlower:
                    // Handle FireFlower pickup
                    break;
            }

            Destroy(gameObject);
        }
    }
}