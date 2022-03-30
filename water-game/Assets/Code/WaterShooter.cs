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
        CheckForPlayerCollision();
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

    protected override void CheckForPlayerCollision()
    {
        if (Player.Instance.playerCollider == null)
        {
            return;
        }

        if (bottomCollider.IsTouching(Player.Instance.playerCollider))
        {
            Player.Instance.DamagePlayer();
        }
        else if (topCollider.IsTouching(Player.Instance.playerCollider))
        {
            Liqify();
        }
    }

    public override void Liqify()
    {
        CheckLiquify();
    }
}
