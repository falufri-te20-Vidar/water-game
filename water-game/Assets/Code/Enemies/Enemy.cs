using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private LayerMask trashMask;

    [SerializeField] BoxCollider2D topCollider;
    [SerializeField] BoxCollider2D bottomCollider;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        CheckForPlayerCollision();
    }


    private void Die()
    {
        Destroy(this.gameObject);
    }

    private void CheckForPlayerCollision()
    {
        if (bottomCollider.IsTouching(Player.Instance.playerCollider))
        {
            Player.Instance.DamagePlayer();
        }
        else if (topCollider.IsTouching(Player.Instance.playerCollider))
        {
            Die();
        }
    }
}
