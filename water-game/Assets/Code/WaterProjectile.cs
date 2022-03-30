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

    private void Update()
    {
        if (transform.position.x < -100f)
        {
            Destroy(this.gameObject);
        }
    }
}
