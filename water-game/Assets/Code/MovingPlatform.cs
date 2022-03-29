using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] Rigidbody2D platform;

    [SerializeField] private bool vertical;
    [SerializeField] private float amplitude;
    [SerializeField] private float frequency;

    float time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        //float offset = amplitude * Mathf.Sin(time * speed);

        float speed = amplitude * frequency * Mathf.Cos(time * frequency); // Derivatan av positionen ger hastigheten

        if (vertical == true)
        {
            //transform.position = new Vector3(transform.position.x, speed, transform.position.z);

            platform.velocity = new Vector3(0f, speed, 0f);
        }
        else
        {
            //transform.position = new Vector3(offset, transform.position.y, transform.position.z);

            platform.velocity = new Vector3(speed, 0f, 0f);
        }
    }

    
    
}
