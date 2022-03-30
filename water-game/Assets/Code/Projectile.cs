using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D rigid_body;

    [SerializeField] protected float speed;
    [SerializeField] protected float rotationRate;

    public void SetDirection(bool facingRight)
    {
        if (facingRight)
        {
            rigid_body.velocity = Vector2.right * speed;
        }
        else
        {
            rigid_body.velocity = Vector2.left * speed;
        }
    }

    public void Rotate()
    {
        transform.eulerAngles += Vector3.forward * rotationRate * Time.deltaTime;
    }
}
