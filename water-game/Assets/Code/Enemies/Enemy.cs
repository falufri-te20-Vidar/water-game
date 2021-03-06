using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private LayerMask trashMask;

    [SerializeField] public BoxCollider2D topCollider;
    [SerializeField] public BoxCollider2D bottomCollider;

    public Animator animator;
    public bool vulnerable = true;
    private float timer;
    private bool hasPlayed = false;

    BoxCollider2D[] colliders;

    void Start()
    {
        colliders = GetComponents<BoxCollider2D>();
    }

    void FixedUpdate()
    {
        CheckForPlayerCollision();
      
        if(animator.GetBool("Splash") == true)
        {
            timer +=  Time.deltaTime;
            if(timer > 5)
            {
                hasPlayed = false;
                animator.SetBool("Splash", false);
                timer = 0f;
                this.GetComponent<EnemyMovement>().velocity = 2f;
                vulnerable = true;
                foreach (var collider in colliders)
                {
                    collider.isTrigger = false;
                }
            }
        }

    }


    public virtual void Liqify()
    {
        animator.SetBool("Splash", true);
        this.GetComponent<EnemyMovement>().velocity = 0f;
        vulnerable = false;
        foreach (var collider in colliders)
        {
            collider.isTrigger = true;
        }
        if (!hasPlayed)
        {
            FindObjectOfType<AudioManager>().Play("Squish");
            hasPlayed = true;
        }
    }



    protected virtual void CheckForPlayerCollision()
    {
        if (Player.Instance.playerCollider == null)
        {
            return;
        }

        if (bottomCollider.IsTouching(Player.Instance.playerCollider) && animator.GetBool("Splash") == false)
        {
            Player.Instance.DamagePlayer();
        }
        else if (topCollider.IsTouching(Player.Instance.playerCollider))
        {
            Liqify();
        }
    }
}
