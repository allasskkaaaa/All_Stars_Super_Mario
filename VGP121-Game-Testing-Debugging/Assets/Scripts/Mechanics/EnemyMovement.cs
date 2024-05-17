using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float moveSpeed;
    public int patrolDestination;
    public float pause;
    private bool isPaused = false;

    // Update is called once per frame
    void Update()
    {
        //Check if the enemy is paused
        if (!isPaused)
        {
            //Switch enemy destination once it reaches their initial destination.
            if (patrolDestination == 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);
                if (Vector3.Distance(transform.position, patrolPoints[0].position) < 0.2f)
                {
                    StartCoroutine(PauseBeforeMoving());
                    patrolDestination = 1;
                }
            }

            if (patrolDestination == 1)
            {
                transform.position = Vector3.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);
                if (Vector3.Distance(transform.position, patrolPoints[1].position) < 0.2f)
                {
                    StartCoroutine(PauseBeforeMoving());
                    patrolDestination = 0;
                }
            }
        }
    }

    private IEnumerator PauseBeforeMoving()
    {
        isPaused = true;
        yield return new WaitForSeconds(pause);
        isPaused = false;
    }
}