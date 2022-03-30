using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterProjectile : Projectile
{
    [SerializeField] private Rigidbody2D rigid_body;

    [SerializeField] bool facingLeft;
    [SerializeField] float speed;

    void Update()
    {
        Rotate();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //Damage player
        }
    }


}
