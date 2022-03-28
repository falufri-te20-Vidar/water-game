using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private KeyCode jumpKey;
    [SerializeField] private KeyCode moveLeftKey;
    [SerializeField] private KeyCode moveRightKey;

    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Rigidbody2D playerRigidBody;
    [SerializeField] private GameObject player;

    [SerializeField] private float jumpForce;
    [SerializeField] private float moveForce;



    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(jumpKey))
        {
            if (Groundcheck())
                playerRigidBody.AddForce(Vector2.up * jumpForce);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = startPos;
            playerRigidBody.velocity = Vector2.zero;
        }
            
        
    }

    private void FixedUpdate()
    {
        

        if (Input.GetKey(moveLeftKey))
        {
            playerRigidBody.AddForce(Vector2.left * moveForce);
        }

        if (Input.GetKey(moveRightKey))
        {
            playerRigidBody.AddForce(Vector2.right * moveForce);
        }

        
    }


    private bool Groundcheck()
    {
        Vector2 newSize = player.transform.localScale;
        newSize.x *= 1f;

        var collision = Physics2D.OverlapBox(player.transform.position + new Vector3(0f, -1f, 0f), newSize, 0f);

        if (collision == null)
            return false;

        if (collision.IsTouchingLayers(groundMask))
        {
            return true;
        }

        return false;
    }

}
