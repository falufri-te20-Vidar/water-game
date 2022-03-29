using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCode : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject camera;

    [SerializeField] private float cameraOffset;
    [SerializeField] private float cameraVelocityModifier;


    void Start()
    {
        
    }

    void FixedUpdate()
    {
        float playerX = player.transform.position.x;
        float cameraX = camera.transform.position.x;
        
        if (playerX < cameraX - cameraOffset)
        {
            MoveCamera((playerX - cameraX) * cameraVelocityModifier);
            Debug.Log("Camera Left");
        }
        else if (player.transform.position.x > camera.transform.position.x + cameraOffset)
        {
            MoveCamera((playerX - cameraX) * cameraVelocityModifier);
            Debug.Log("Camera Right");
        }
    }

    private void MoveCamera(float cameraSpeed)
    {
        Vector3 velocity = new Vector3(cameraSpeed, 0f, 0f);
        camera.transform.position += velocity;
    }
}
