using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Projectiles : MonoBehaviour
{
    AudioManager audioManager;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
            Debug.Log("Destroying Projectile");
        }

        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("EnemyProj"))
        {
            Destroy(gameObject);
        }


        if (collision.gameObject.CompareTag("Weak Point") && gameObject.CompareTag("PlayerProj"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            audioManager.PlaySFX(audioManager.EnemyDeath);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && gameObject.CompareTag("PlayerProj"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    public float lifetime;

    //Speed value is set by shoot script when the player fires
    [HideInInspector]
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        if (lifetime <= 0) lifetime = 2.0f;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        Destroy(gameObject, lifetime);

    }
}
