using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float moveSpeed;
    public int patrolDestination;
    public float pause;
    private bool isPaused = false;
    private Vector2 patrolPoint1;
    private Vector2 patrolPoint2;

    private void Start()
    {
        patrolPoint1 = new Vector2(patrolPoints[0].transform.position.x,transform.position.y);
        patrolPoint2 = new Vector2(patrolPoints[1].transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        //Check if the enemy is paused
        if (!isPaused)
        {
            //Switch enemy destination once it reaches their initial destination.
            if (patrolDestination == 0)
            {
                
                transform.position = Vector3.MoveTowards(transform.position, patrolPoint1, moveSpeed * Time.deltaTime);
                if (Vector3.Distance(transform.position, patrolPoint1) < 0.2f)
                {
                    StartCoroutine(PauseBeforeMoving());
                    patrolDestination = 1;
                }
            }

            if (patrolDestination == 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoint2, moveSpeed * Time.deltaTime);
                if (Vector3.Distance(transform.position, patrolPoint2) < 0.2f)
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