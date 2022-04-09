using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Movable: MonoBehaviour
{
    protected NavMeshAgent agent;
    protected NavMeshPath path;
    protected int pathIndex = 0;

    protected Vector3? destination;

    [SerializeField] protected float velocity = 2.5f;

    protected virtual void Update()
    {
        Move();
    }

    public void SetDestination(Vector3 destination)
    {
        pathIndex = 0;
        path = null;
        this.destination = destination;
    }

    protected void Move()
    {
        if (destination != null)
        {
            Vector3 myPos = transform.position.IgnoreY();

            if (path == null)
            {
                path = new NavMeshPath();

                agent.CalculatePath(destination!.Value, path);
            }

            if (pathIndex < path.corners.Length)
            {
                Vector3 nextDestination = path.corners[pathIndex].IgnoreY();

                float distance = Vector3.Distance(nextDestination, myPos);

                if (distance > agent.stoppingDistance)
                {
                    Vector3 targetDestination = nextDestination - myPos;
                    Vector3 movement = Time.deltaTime * velocity * targetDestination.normalized;
                    Debug.Log(movement);
                    agent.Move(movement);

                    Vector3 rotationDirection = transform.position + movement;
                    transform.LookAt(rotationDirection);
                }
                else
                {
                    pathIndex++;
                }
            }
            else
            {
                destination = null;
            }
        }
    }
}
