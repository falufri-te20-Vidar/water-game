using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBall : MonoBehaviour
{
    [SerializeField] private float SpeedModifier = 40.0f;
    public Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * Time.deltaTime * SpeedModifier;
    }

    public void SetDiretion(Vector3 Dir) {direction = Dir;}
}
