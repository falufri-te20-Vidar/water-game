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

    void Update()
    {
        if (player.transform.position.x > camera.transform.position.x + cameraOffset)
        {
            MoveCamera(new Vector3(cameraVelocityModifier, 0f, 0f));
            Debug.Log("Camera Right");
        }
        else if (player.transform.position.x < camera.transform.position.x - cameraOffset)
        {
            MoveCamera(new Vector3(-cameraVelocityModifier, 0f, 0f));
            Debug.Log("Camera Left");
        }
    }

    private void MoveCamera(Vector3 cameraVelocity)
    {
        camera.transform.position += cameraVelocity;
    }
}
