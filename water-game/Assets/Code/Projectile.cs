using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D rigid_body;

    [SerializeField] protected float speedX;
    [SerializeField] protected float speedY;
    [SerializeField] protected float rotationRate;
    [SerializeField] protected float yOffset;

    void Start()
    {
        transform.position += Vector3.up * yOffset;
    }
    public virtual void SetDirection(bool facingRight)
    {
        if (facingRight)
        {
            rigid_body.velocity = new Vector2(speedX, speedY);
        }
        else
        {
            rigid_body.velocity = new Vector2(-speedX, speedY);
        }
    }

    public void Rotate()
    {
        transform.eulerAngles += Vector3.forward * rotationRate * Time.deltaTime;
    }
}
