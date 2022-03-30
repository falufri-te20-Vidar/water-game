using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    /*[SerializeField] public float SpeedModifier = 10.0f;
    public Vector3 direction;*/

    [SerializeField] protected Rigidbody2D rigid_body;

    [SerializeField] public bool facingRight;
    [SerializeField] protected float speed;
    [SerializeField] protected float rotationRate;

    // Start is called before the first frame update
    void Start()
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
