using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterProjectile : Projectile
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player.Instance.DamagePlayer();
        }
    }

    public override void SetDirection(bool facingRight)
    {
        speedY = Random.Range(-speedY, speedY);

        if (facingRight)
        {
            rigid_body.velocity = new Vector2(speedX, speedY);
        }
        else
        {
            rigid_body.velocity = new Vector2(-speedX, speedY);
        }
    }

    private void Update()
    {
        if (transform.position.x < -100f)
        {
            Destroy(this.gameObject);
        }
    }
}
