using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBall : Projectile
{
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trash") && collision.GetComponent<Enemy>().vulnerable == true)
        {
            FindObjectOfType<AudioManager>().Play("EnemyDeath");
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
