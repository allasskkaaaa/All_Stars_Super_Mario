using UnityEngine;

public class BackgroundPanner : MonoBehaviour
{
    public float panSpeed = 0.01f;  // Speed at which the background will pan
    public float panLimit = 10.0f; // The limit at which the background will reset
    public Vector3 startPosition;  // The starting position to reset to

    private void Start()
    {
        // Initialize the start position to the current position if not set
        if (startPosition == Vector3.zero)
        {
            startPosition = transform.position;
        }
    }

    void Update()
    {
        // Calculate the new position
        Vector3 newPosition = transform.position;
        newPosition.x += panSpeed * Time.deltaTime;

        // Check if the position exceeds the pan limit
        if (Mathf.Abs(newPosition.x - startPosition.x) >= panLimit)
        {
            newPosition.x = startPosition.x;
        }

        // Update the background position
        transform.position = newPosition;
    }
}
