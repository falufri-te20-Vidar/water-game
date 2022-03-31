using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FlipCharacter : MonoBehaviour
{
    private void Update()
    {
        var target = GetComponent<WaterShooter>();

        if (target == null)
            return;


            target.Flip();
    }

}
