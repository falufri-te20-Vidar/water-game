using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCode : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [SerializeField] private float cameraOffset;
    [SerializeField] private float cameraVelocityModifier;


    void Start()
    {
        
    }

    void FixedUpdate()
    {
        float playerX = player.transform.position.x;
        float playerY = player.transform.position.y;

        float cameraX = transform.position.x;
        float cameraY = transform.position.y;

        float XcameraSpeed = 0f;
        float YcameraSpeed = 0f;
        
        // X movement
        if (playerX < cameraX - cameraOffset)
        {
            //MoveCamera((playerX - cameraX) * cameraVelocityModifier);
            XcameraSpeed = (playerX - cameraX) * cameraVelocityModifier;
        }
        else if (playerX > cameraX + cameraOffset)
        {
            //MoveCamera((playerX - cameraX) * cameraVelocityModifier);
            XcameraSpeed = (playerX - cameraX) * cameraVelocityModifier;
        }

        // Y movement
        if (playerY < cameraY - cameraOffset)
        {
            //MoveCamera((playerX - cameraX) * cameraVelocityModifier);
            YcameraSpeed = (playerY - cameraY) * cameraVelocityModifier;
        }
        else if (playerY > cameraY + cameraOffset)
        {
            //MoveCamera((playerX - cameraX) * cameraVelocityModifier);
            YcameraSpeed = (playerY - cameraY) * cameraVelocityModifier;
        }

        MoveCamera(XcameraSpeed, YcameraSpeed);

    }

    private void MoveCamera(float XcameraSpeed, float YcameraSpeed)
    {
        Vector3 velocity = new Vector3(XcameraSpeed, YcameraSpeed, 0f);
        transform.position += velocity;
    }
}
