using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    

    public float velocity;
    public float margin;

    public Transform startWaypoint, endWaypoint;

    private Transform currentWaypoint;
    private bool goingRight;

    private Vector3 prevPosition;

    private void Start()
    {
        currentWaypoint = startWaypoint;
        goingRight = false;
    }

    private void Update()
    {
        var position = transform.position;

        if (position.x <= startWaypoint.position.x && goingRight == false)
        {
            goingRight = true;
            Flip();
            currentWaypoint = endWaypoint;
        }

        else if (position.x >= endWaypoint.position.x && goingRight == true)
        {
            goingRight = false;
            Flip();
            currentWaypoint = startWaypoint;
        }


        position = Vector2.MoveTowards(position, currentWaypoint.position, Time.deltaTime * velocity);

        transform.position = position;
        prevPosition = position;
    }

    private void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *=  GetSloppyVelocity(transform.position, prevPosition) > 0f ? 1f : -1f;
        transform.localScale = scale;
    }

    private float GetSloppyVelocity(Vector3 a, Vector3 b)
    {
        return b.x - a.x;
    }


    //[ContextMenu("Clean")]
    //public void CleanUp()
    //{
    //    var trash = FindObjectsOfType(typeof(EnemyMovement));

    //    if (trash.Length > 1)
    //    {
    //        foreach (var shit in trash)
    //        {
    //            Destroy(((EnemyMovement)shit).gameObject);
    //        }
    //    }
    //}
}
