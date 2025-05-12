using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerController : MonoBehaviour
{
    //Array of points (set in editor to make the conttroller universal)
    public Transform[] workerPatrolPoints;
    public int nextPoint;
    public float workerSpeed;
    public bool isWaiting;
    public float waitTime;
    private Animator animator;
    void Start()
    {
        //set speed and waittime at points
        nextPoint = 0;
        workerSpeed = 0.5f;
        waitTime = 4f;
        isWaiting = false;
        animator = GetComponent<Animator>();
        animator.SetBool("isWalking", true);
        animator.SetBool("isIdle", false);
    }

    void Update()
    {
        //If not waiting for the cooldown (wait at point)        
        if (!isWaiting)
        {
            //Set animations
            animator.SetBool("isIdle", false);
            animator.SetBool("isWalking", true);
            //move to point
            transform.position = Vector3.MoveTowards(transform.position, workerPatrolPoints[nextPoint].position,
                workerSpeed * Time.deltaTime);
            //stop walking when at point
            if (Vector3.Distance (transform.position, workerPatrolPoints[nextPoint].position) < 0.2f)
            {
                //Set animations
                animator.SetBool("isWalking", false);
                StartCoroutine(WaitAtPoint());
            }
        }

        faceNextPoint();
    }

    //Timer for waiting at point
    IEnumerator WaitAtPoint()
    {
        movetoNextPoint();
        //change aniation to wait animation at point
        animator.SetBool("isIdle", true);
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);
        isWaiting = false;
    }

    void movetoNextPoint()
    {
        nextPoint++;
        // If next point bigger than array, move to first point in array (basically looping the points)
        if (nextPoint >= workerPatrolPoints.Length)
        {
            nextPoint = 0;
        }
    }

    //Make worker face the point its going to move to
    void faceNextPoint()
    {
        Vector3 direction = workerPatrolPoints[nextPoint].position - transform.position;
        direction.y = 0;
        
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            //Rotate to look
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5f * Time.deltaTime);
        }
    }
}
