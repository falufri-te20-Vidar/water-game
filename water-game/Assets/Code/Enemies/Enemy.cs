using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject thisEnemy;

    [SerializeField] private LayerMask trashMask;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        CheckCollision();
    }

    private void CheckCollision()
    {
        var collisions = Physics2D.OverlapBoxAll(thisEnemy.transform.position, thisEnemy.transform.localScale, 0f);

        foreach (var collision in collisions)
        {
            if (collision.IsTouchingLayers(trashMask))
            {
                Die();
            }
        }
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }
}
