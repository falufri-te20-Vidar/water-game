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
<<<<<<< Updated upstream
        float playerX = player.transform.position.x;
        float cameraX = camera.transform.position.x;
        
        if (playerX < cameraX - cameraOffset)
        {
            MoveCamera((playerX - cameraX) * cameraVelocityModifier);
        }
        else if (player.transform.position.x > camera.transform.position.x + cameraOffset)
        {
            MoveCamera((playerX - cameraX) * cameraVelocityModifier);
=======
        /*
        if (player.transform.position.x < camera.transform.position.x - cameraOffset)
        {
            
            MoveCamera();
            Debug.Log("Camera Left");
        }
        else if (player.transform.position.x > camera.transform.position.x + cameraOffset)
        {
            MoveCamera(new Vector3(cameraVelocityModifier, 0f, 0f));
            Debug.Log("Camera Right");
>>>>>>> Stashed changes
        }
        */
    }

    private void MoveCamera(float cameraSpeed)
    {
        Vector3 velocity = new Vector3(cameraSpeed, 0f, 0f);
<<<<<<< Updated upstream
        camera.transform.position += velocity;
=======
        camera.transform.position += velocity * Time.deltaTime;
>>>>>>> Stashed changes
    }
}
