using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private KeyCode jumpKey1;
    [SerializeField] private KeyCode jumpKey2;
    [SerializeField] private KeyCode moveLeftKey;
    [SerializeField] private KeyCode moveRightKey;

    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Rigidbody2D playerRigidBody;

    [SerializeField] private float jumpForce;
    [SerializeField] private float moveForce;
    [SerializeField] private float friction;

    [SerializeField] private float maxSpeed;

    public bool facingRight = true;

    AudioSource jumpSound;

    


    void Start()
    {
        jumpSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(jumpKey1) || Input.GetKeyDown(jumpKey2))
        {
            if (Groundcheck())
            {
                FindObjectOfType<AudioManager>().Play("PlayerJump");
                Accelerate(Vector2.up * jumpForce);
            }
            
        }

    }

    private void FixedUpdate()
    {
        Vector3 scale = transform.localScale;
        
        if (Input.GetKey(moveLeftKey))
        {
            facingRight = false;
            Accelerate(Vector2.left * moveForce);
        }

        if (Input.GetKey(moveRightKey))
        {
            facingRight = true;
            Accelerate(Vector2.right * moveForce);
        }

        if (Input.GetKey(moveLeftKey) == false && Input.GetKey(moveRightKey) == false || // Ingen knapp
            Input.GetKey(moveLeftKey) == true && Input.GetKey(moveRightKey) == true)     // Båda knappar
        {
            if (Groundcheck())
            {
                ApplyFriction();
            }
        }
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

    private void ApplyFriction()
    {
        playerRigidBody.velocity *= friction;
    }

    private void Accelerate(Vector2 acceleration)
    {
        

        playerRigidBody.velocity += acceleration;

        
        float xVel = playerRigidBody.velocity.x;
        float yVel = playerRigidBody.velocity.y;

        xVel = Mathf.Clamp(xVel, -maxSpeed, maxSpeed);
        yVel = Mathf.Clamp(yVel, -maxSpeed, maxSpeed);

        playerRigidBody.velocity = new Vector2(xVel, yVel);
        
    }


}
