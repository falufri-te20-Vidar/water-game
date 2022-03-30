using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterShooter : Enemy
{
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Rigidbody2D rigid_body;

    [SerializeField] private int jumpRate;
    [SerializeField] private float shootRate;
    [SerializeField] private float jumpSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Random.Range(0, jumpRate) == 0)
        {
            if (Groundcheck())
            {
                Jump();
            }
        }
    }

    private void Jump()
    {
        rigid_body.velocity += Vector2.up * jumpSpeed;
    }

    private bool Groundcheck()
    {
        var collisions = Physics2D.OverlapBoxAll(transform.position + new Vector3(0f, 0.1f, 0f), transform.localScale, 0f);

        foreach (var collision in collisions)
        {
            if (collision == null)
                return false;

            if (collision.IsTouchingLayers(groundMask))
            {
                return true;
            }
        }
        return false;
    }   
}
