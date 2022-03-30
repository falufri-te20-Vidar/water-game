using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterProjectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigid_body;

    [SerializeField] bool facingLeft;
    [SerializeField] float speed;



    // Start is called before the first frame update
    void Start()
    {
        if (facingLeft)
        {
            rigid_body.velocity = Vector2.left * speed;
        }
        else
        {
            rigid_body.velocity = Vector2.right * speed;
        }
        
    }



}
