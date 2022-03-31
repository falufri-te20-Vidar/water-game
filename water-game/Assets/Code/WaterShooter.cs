using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterShooter : Enemy
{
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Rigidbody2D rigid_body;
    [SerializeField] private GameObject waterProjectile;

    [SerializeField] private int jumpRate;
    [SerializeField] private int shootRate;
    [SerializeField] private float jumpSpeed;

    public bool facingRight;


    private void Start()
    {
        Flip();
    }

    void FixedUpdate()
    {
        CheckForPlayerCollision();
        if (Random.Range(0, jumpRate) == 0 && Groundcheck())
        {
            Jump();
        }
        if (Random.Range(0, shootRate) == 0)
        {
            Shoot();
        }
    }
    

    public void Flip()
    {
        //if (facingRight)
        //{
            //transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 1f);
            
        //}

        transform.eulerAngles = Vector3.up * (facingRight ? 0f : 180f);
    }

    private void Shoot()
    {
        GameObject go = Instantiate(waterProjectile, transform.position, Quaternion.identity, null);
        
        if (facingRight)
        {
            go.GetComponent<WaterProjectile>().SetDirection(true);
        }
        else
        {
            go.GetComponent<WaterProjectile>().SetDirection(false);
        }

        FindObjectOfType<AudioManager>().Play("Shoot");

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
        Destroy(gameObject);
    }
}
