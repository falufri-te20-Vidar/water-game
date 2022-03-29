using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBall : MonoBehaviour
{
    [SerializeField] private float SpeedModifier = 10.0f;
    public Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * Time.deltaTime * SpeedModifier;
        transform.eulerAngles += Vector3.forward * 200 * Time.deltaTime;
    }

    public void SetDirection(Vector3 Dir) {direction = Dir;}
}
