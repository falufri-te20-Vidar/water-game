using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBall : MonoBehaviour
{
    [SerializeField] private float SpeedModifier = 40.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * Time.deltaTime * SpeedModifier;
    }
}
