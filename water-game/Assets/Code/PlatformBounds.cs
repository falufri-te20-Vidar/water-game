using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBounds : MonoBehaviour
{
    [SerializeField] private BoxCollider2D groundBox;

    [SerializeField] private float offset;

    void Update()
    {
        float platformX = transform.localScale.x;

        float xSize = platformX - 2 * offset;
        xSize = xSize / platformX;

        float ySize = groundBox.size.y;

        groundBox.size = new Vector2(xSize, ySize);
    }
}
