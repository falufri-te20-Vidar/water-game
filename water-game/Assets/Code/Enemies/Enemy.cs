using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private LayerMask trashMask;

    [SerializeField] BoxCollider2D topCollider;
    [SerializeField] BoxCollider2D bottomCollider;

    public Animator animator;
    public bool vulnerable = true;
    private float timer;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        CheckForPlayerCollision();
        if(animator.GetBool("Splash") == true)
        {
            timer +=  Time.deltaTime;
            if(timer > 5)
            {
                animator.SetBool("Splash", false);
                timer = 0f;
                this.GetComponent<EnemyMovement>().velocity = 2f;
                vulnerable = true;
            }
        }

    }


    private void Liqify()
    {
        animator.SetBool("Splash", true);
        this.GetComponent<EnemyMovement>().velocity = 0f;
        vulnerable = false;
    }

    private void CheckForPlayerCollision()
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
