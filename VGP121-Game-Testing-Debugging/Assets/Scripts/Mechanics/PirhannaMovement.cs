using System.Collections;
using UnityEngine;

public class PiranhaPlant : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed at which the plant moves up and down
    public float pause = 1f; // Time to pause at each end
    public float moveDistance = 2f; // Distance the plant moves up and down

    private bool isPaused = false;
    private bool movingDown = true;
    private Animator animator;
    private Vector3 origin;
    private Vector3 targetPosition;

    void Start()
    {
        origin = transform.position;
        targetPosition = origin + Vector3.down * moveDistance;
        StartCoroutine(MovePlant());
    }

    private IEnumerator MovePlant()
    {
        while (true)
        {
            if (!isPaused)
            {
                // Move the plant
                float step = moveSpeed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

                // Check if the plant reached the target position
                if (Vector3.Distance(transform.position, targetPosition) < 0.001f)
                {
                    // Pause the plant
                    StartCoroutine(PauseBeforeMoving());
                }
            }
            yield return null;
        }
    }

    private IEnumerator PauseBeforeMoving()
    {
        isPaused = true;
        yield return new WaitForSeconds(pause);

        // Toggle direction
        movingDown = !movingDown;
        targetPosition = movingDown ? origin + Vector3.down * moveDistance : origin;
        isPaused = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.lives --;
        }
    }
}
