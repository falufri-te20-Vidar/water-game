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
    [SerializeField] private GameObject player;

    [SerializeField] private float jumpForce;
    [SerializeField] private float moveForce;
    [SerializeField] private float friction;

    [SerializeField] private float maxSpeed;


    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(jumpKey1) || Input.GetKeyDown(jumpKey2))
        {
            if (Groundcheck())
                Accelerate(Vector2.up * jumpForce);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Speed: " + playerRigidBody.velocity.x);
            transform.position = startPos;
            playerRigidBody.velocity = Vector2.zero;
        }
            
        
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(moveLeftKey))
        {
            Accelerate(Vector2.left * moveForce);
        }

        if (Input.GetKey(moveRightKey))
        {
            Accelerate(Vector2.right * moveForce);
        }

        if (Input.GetKey(moveLeftKey) == false && Input.GetKey(moveRightKey) == false)
        {
            if (Groundcheck())
            {
                ApplyFriction();
            }
        }
    }

    private bool Groundcheck()
    {
        var collision = Physics2D.OverlapBox(player.transform.position + new Vector3(0f, 0.1f, 0f), player.transform.localScale, 0f);

        if (collision == null)
            return false;

        if (collision.IsTouchingLayers(groundMask))
        {
            return true;
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
